using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakture.Model;
using System.Data.Entity.Validation;

namespace Fakture.UI
{
    public partial class FakturaForm : Form
    {
        private int? fakturaZaglavljeId;
        public Model.Fakture FakturaZaglavlje { get; set; }
        private List<FirmePodaci> ListaKupaca { get; set; } // lista svih kupaca

        private List<ListaStavkiFaktureView> ListaStavkiFakture { get; set; } // lista stavki fakture
        private FirmePodaci OdabraniKupac { get; set; } // podaci o kupcu odabranom iz combobox-a

        private int IndeksOdabraneStavkeFakture { get; set; }


        public FakturaForm(int? _fakturaZaglavljeId)
        {
            InitializeComponent();

            // This is a handy trick to prevent implicit validation of our controls when they lose focus.
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;

            fakturaZaglavljeId = _fakturaZaglavljeId;
        }


        private void Faktura_Load(object sender, EventArgs e)
        {
            PuniComboTekicihRacuna();

            UcitajListuKupacaZaCombobox(); // lista kupaca za combo box

            CreateEditZaglavljeFakture();

        }


        private void CreateEditZaglavljeFakture()
        {

            /* 
              - Na osnovu fakturaZaglavljeId kreira se novi ili traži postojeći zapis.
              - FakturaZaglavlje sadrže podatak o postojećem ili novom kupcu
              - Mapiraj_ModelNaKontrole ispisuje podatke na formi o novom/postojećem zapisu.
              - Mapiraj_KontroleNaModel kao argument dobija novi/postojeći zapis
              i update-uje ga podacima iz kontrola na formi.
              - SnimanjePodataka na osnovu FakturaZaglavlje vrši upis novog ili update zapisa
              */


            /* NOVA FAKTURA */
            if (fakturaZaglavljeId == null)
            {
                // default TR prodavca MORA
                comboTR.SelectedIndex = 0;

                Model.Fakture novaFakturaZaglavlje = new Model.Fakture()
                {
                    BrojRN = GenerisiNoviBrojRacuna(), // max 20 chars
                    DatumIzdavanjaRN = DateTime.Now.Date,
                    DatumPrometa = DateTime.Now.Date,
                    DatumPrometaDO = DateTime.Now.Date,
                    TRProdavcaId = (int)comboTR.SelectedValue,
                    NacinPlacanja = "Virmanski",
                    RokPlacanja = 1,
                    KupacId = comboKupac.SelectedIndex
                };

                labelNASLOV.Text = "Novi račun";
                
                btnStavkaFakture.Visible = false;
                buttonStampa.Visible = false;
                contextMenuStavkeFakture.Enabled = false;

                // ispis poreske rekapitulacije
                labelVrednostBezPDV.Text = string.Empty;
                labelIznosRabata.Text = string.Empty;
                labelPoreskaOsnovica.Text = string.Empty;
                labelIznosPDV.Text = string.Empty;
                labelVrednostSaPDV.Text = string.Empty;

                FakturaZaglavlje = novaFakturaZaglavlje;

                IspisiNazivKupca(FakturaZaglavlje.ID);

                Mapiraj_ModelNaKontrole(FakturaZaglavlje);
            }

            else
            {
                /* POSTOJEĆA FAKTURA  */
                labelNASLOV.Text = "Izmena računa";
                btnStavkaFakture.Visible = true;
                buttonStampa.Visible = true;
                linkIzmeniKupca.Enabled = true;

                using (FaktureModel db = new FaktureModel())
                {
                    var postojecaFaktura = db.Fakture
                        .Where(x => x.ID == fakturaZaglavljeId)
                        .SingleOrDefault();

                    if (postojecaFaktura == null)
                    {
                        MessageBox.Show("Faktura ne postoji u evidenciji.", "Greška");
                        Close();
                        return;
                    }

                    FakturaZaglavlje = postojecaFaktura;

                    Mapiraj_ModelNaKontrole(FakturaZaglavlje);
                    PopuniListuStavkiFakture();                    
                    IspisiNazivKupca(FakturaZaglavlje.KupacId);
                }

            }
        }



        private void Mapiraj_ModelNaKontrole(Model.Fakture _fakturaZaglavlje)
        {
            // ispis podataka u kontrole

            textFakturaId.Text = _fakturaZaglavlje.ID.ToString();
            labelBrojRN.Text = _fakturaZaglavlje.BrojRN;
            comboTR.SelectedValue = _fakturaZaglavlje.TRProdavcaId;
            datumIzdavanja.Value = _fakturaZaglavlje.DatumIzdavanjaRN;
            textMestoIzdavanja.Text = _fakturaZaglavlje.MestoIzdavanjaRN;
            datumPrometa.Value = _fakturaZaglavlje.DatumPrometa;
            if (_fakturaZaglavlje.DatumPrometaDO == null)
            {
                datumPrometaDO.Value = _fakturaZaglavlje.DatumPrometa;
            }
            else
            {
                datumPrometaDO.Value = (DateTime)_fakturaZaglavlje.DatumPrometaDO;
            }
            textMestoPrometa.Text = _fakturaZaglavlje.MestoPrometa;
            comboNacinPlacanja.SelectedItem = _fakturaZaglavlje.NacinPlacanja.ToString();
            comboRokPlacanja.SelectedItem = _fakturaZaglavlje.RokPlacanja.ToString();
            textBrojFI.Text = _fakturaZaglavlje.BrojFI;
            comboKupac.SelectedValue = _fakturaZaglavlje.KupacId;
            textNapomena.Text = _fakturaZaglavlje.Napomena;

            // dodati kontrole za prevoznika
            textFakturuIzdao.Text = _fakturaZaglavlje.FakturuIzdao;
            textImePrevoznika.Text = _fakturaZaglavlje.PrevozImePrezime;
            textRegBrojVozila.Text = _fakturaZaglavlje.PrevozRegBrojVozila;
            // početni datum prevoza
            if (_fakturaZaglavlje.PrevozDatumOd == null)
            {
                datumPrevozOd.Value = _fakturaZaglavlje.DatumPrometa;
            }
            else
            {
                datumPrevozOd.Value = (DateTime)_fakturaZaglavlje.PrevozDatumOd;
            }
            // krajnji datum prevoza
            if (_fakturaZaglavlje.PrevozDatumDo == null)
            {
                if (_fakturaZaglavlje.DatumPrometaDO == null)
                {
                    datumPrevozDo.Value = _fakturaZaglavlje.DatumPrometa;
                }
                else
                {
                    datumPrevozDo.Value = (DateTime)_fakturaZaglavlje.DatumPrometaDO;
                }
            }
            else
            {
                datumPrevozDo.Value = (DateTime)_fakturaZaglavlje.PrevozDatumDo;
            }
                        
        }


        private Model.Fakture Mapiraj_KontroleNaModel(Model.Fakture _fakturaZaglavlje)
        {
            // podaci iz kontrola u model

            _fakturaZaglavlje.ID = Convert.ToInt32(textFakturaId.Text);
            _fakturaZaglavlje.BrojRN = labelBrojRN.Text;
            _fakturaZaglavlje.TRProdavcaId = (int)comboTR.SelectedValue;
            _fakturaZaglavlje.DatumIzdavanjaRN = datumIzdavanja.Value;
            _fakturaZaglavlje.MestoIzdavanjaRN = textMestoIzdavanja.Text;
            _fakturaZaglavlje.DatumPrometa = datumPrometa.Value;
            _fakturaZaglavlje.DatumPrometaDO = datumPrometaDO.Value;
            _fakturaZaglavlje.MestoPrometa = textMestoPrometa.Text;
            _fakturaZaglavlje.NacinPlacanja = comboNacinPlacanja.SelectedItem.ToString();
            _fakturaZaglavlje.RokPlacanja = Convert.ToInt32(comboRokPlacanja.SelectedItem);
            _fakturaZaglavlje.BrojFI = textBrojFI.Text;
            _fakturaZaglavlje.KupacId = (int)comboKupac.SelectedValue;
            _fakturaZaglavlje.Napomena = textNapomena.Text;
           
            _fakturaZaglavlje.FakturuIzdao = textFakturuIzdao.Text;
            _fakturaZaglavlje.PrevozImePrezime = textImePrevoznika.Text;
            _fakturaZaglavlje.PrevozRegBrojVozila = textRegBrojVozila.Text;
            _fakturaZaglavlje.PrevozDatumOd = datumPrevozOd.Value;
            _fakturaZaglavlje.PrevozDatumDo = datumPrevozDo.Value;


            return _fakturaZaglavlje;
        }


        private void PopuniListuStavkiFakture()
        {

            using (FaktureModel db = new FaktureModel())
            {
                var _listaStavkiFakture = db.ListaStavkiFaktureView
                    .Where(x => x.FakturaId == FakturaZaglavlje.ID)
                    .ToList();

                ListaStavkiFakture = _listaStavkiFakture;

                
            }
            // enable kontekstni meni
            contextMenuStavkeFakture.Enabled = true;

            // enable print button
            if (ListaStavkiFakture.Count > 0)
            {
                groupBoxStavkeRN.Text = "Stavke računa - UKUPNO " + ListaStavkiFakture.Count;
                buttonStampa.Enabled = true;
            }

            var bindingListaStavkiFakture = new BindingList<ListaStavkiFaktureView>(ListaStavkiFakture);
            var dgStavkeFaktureSource = new BindingSource(bindingListaStavkiFakture, null);

            dgvStavkeRacuna.DataSource = dgStavkeFaktureSource;

            dgvStavkeRacuna.Columns["ID"].Visible = false;

            dgvStavkeRacuna.Columns["FakturaId"].Visible = false;

            dgvStavkeRacuna.Columns["NazivVrsteStavke"].Visible = true;
            dgvStavkeRacuna.Columns["NazivVrsteStavke"].HeaderText = "Naziv stavke";
            dgvStavkeRacuna.Columns["NazivVrsteStavke"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;


            dgvStavkeRacuna.Columns["VrstaStavkeDodOpis"].Visible = true;
            dgvStavkeRacuna.Columns["VrstaStavkeDodOpis"].HeaderText = "Opis stavke";
            dgvStavkeRacuna.Columns["VrstaStavkeDodOpis"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvStavkeRacuna.Columns["JedinicaMere"].Visible = true;
            dgvStavkeRacuna.Columns["JedinicaMere"].HeaderText = "Jed. mere";
            dgvStavkeRacuna.Columns["JedinicaMere"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvStavkeRacuna.Columns["Kolicina"].Visible = true;
            dgvStavkeRacuna.Columns["Kolicina"].HeaderText = "Količina";
            dgvStavkeRacuna.Columns["Kolicina"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvStavkeRacuna.Columns["CenaBezPDV"].Visible = true;
            dgvStavkeRacuna.Columns["CenaBezPDV"].HeaderText = "Cena bez PDV";
            dgvStavkeRacuna.Columns["CenaBezPDV"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvStavkeRacuna.Columns["VrednostBezPDV"].Visible = true;
            dgvStavkeRacuna.Columns["VrednostBezPDV"].HeaderText = "Vrednost bez PDV";
            dgvStavkeRacuna.Columns["VrednostBezPDV"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvStavkeRacuna.Columns["Rabat"].Visible = true;
            dgvStavkeRacuna.Columns["Rabat"].HeaderText = "Rabat %";
            dgvStavkeRacuna.Columns["Rabat"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvStavkeRacuna.Columns["IznosRabata"].Visible = true;
            dgvStavkeRacuna.Columns["IznosRabata"].HeaderText = "Iznos rabata";
            dgvStavkeRacuna.Columns["IznosRabata"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvStavkeRacuna.Columns["OsnovicaPDV"].Visible = true;
            dgvStavkeRacuna.Columns["OsnovicaPDV"].HeaderText = "Poreska osnovica";
            dgvStavkeRacuna.Columns["OsnovicaPDV"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvStavkeRacuna.Columns["StopaPDV"].Visible = true;
            dgvStavkeRacuna.Columns["StopaPDV"].HeaderText = "Stopa PDV %";
            dgvStavkeRacuna.Columns["OsnovicaPDV"].DefaultCellStyle.Alignment =
               DataGridViewContentAlignment.MiddleRight;

            dgvStavkeRacuna.Columns["IznosPDV"].Visible = true;
            dgvStavkeRacuna.Columns["IznosPDV"].HeaderText = "Iznos PDV";
            dgvStavkeRacuna.Columns["IznosPDV"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvStavkeRacuna.Columns["VrednostSaPDV"].Visible = true;
            dgvStavkeRacuna.Columns["VrednostSaPDV"].HeaderText = "Vrednost sa PDV";
            dgvStavkeRacuna.Columns["VrednostSaPDV"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;


            dgvStavkeRacuna.AutoResizeColumns();

            NapraviPoreskuRekapitulaciju(ListaStavkiFakture);

        }


        private void NapraviPoreskuRekapitulaciju(List<ListaStavkiFaktureView> _listaStavkiFakture)
        {
            decimal vrednostBezPDV = decimal.Zero;
            decimal iznosRabata = decimal.Zero;
            decimal poreskaOsnovica = decimal.Zero;
            decimal iznosPDV = decimal.Zero;
            decimal vrednostSaPDV = decimal.Zero;


            foreach (var item in _listaStavkiFakture)
            {
                vrednostBezPDV += item.VrednostBezPDV;
                iznosRabata += item.IznosRabata;
                poreskaOsnovica += item.OsnovicaPDV;
                iznosPDV += item.IznosPDV;
                vrednostSaPDV += item.VrednostSaPDV;
            }

            
            labelVrednostBezPDV.Text = vrednostBezPDV.ToString("N2");

            labelIznosRabata.Text = iznosRabata.ToString("N2");
            labelPoreskaOsnovica.Text = poreskaOsnovica.ToString("N2");
            labelIznosPDV.Text = iznosPDV.ToString("N2");
            labelVrednostSaPDV.Text = vrednostSaPDV.ToString("N2");

        }

        
        private void SnimanjeZaglavljaFakture()
        {

            // NOVA FAKTURA
            if (FakturaZaglavlje.ID == 0)
            {
                using (FaktureModel db = new FaktureModel())
                {
                    // postojeće podatke o kupcu iz propertija PodaciOKupcu update-ujem podacima iz kontrola 
                    FakturaZaglavlje = Mapiraj_KontroleNaModel(FakturaZaglavlje);

                    try
                    {
                        db.Fakture.Add(FakturaZaglavlje);
                        int result = db.SaveChanges();

                        if (result > 0)
                        {
                            // nakon snimanja novi id se dodeljuje FaktureZaglavlje i fakturaZaglavljeId
                            int noviFaktiraZaglavljeId = FakturaZaglavlje.ID;
                            FakturaZaglavlje.ID = noviFaktiraZaglavljeId;
                            fakturaZaglavljeId = FakturaZaglavlje.ID;

                            // ovde se učitava tek snimljeni zapis sa novim ID kako bi se mogao ažurirati - update
                            CreateEditZaglavljeFakture();

                            MessageBox.Show("Novi račun je snimljen u evidenciju.\r\nMožete dodati stavke.", "Snimanje podataka");
                            btnStavkaFakture.Visible = true;
                            buttonStampa.Visible = true;
                            return;
                        }
                    }
                    catch (Exception xcp)
                    {
                        //MessageBox.Show(xcp.ToString());
                        MessageBox.Show("Greška prilikom snimanja podataka!\r\n" + xcp.ToString() , "Greška");
                        return;
                    }
                    
                }
            }


            // POSTOJEĆA FAKTURA
            if (FakturaZaglavlje.ID > 0)
            {
                // 1. korak
                using (FaktureModel db = new FaktureModel())
                {
                    FakturaZaglavlje = db.Fakture
                        .Where(x => x.ID == FakturaZaglavlje.ID)
                        .SingleOrDefault();
                }

                // 2. korak
                if (FakturaZaglavlje != null)
                {
                    // postojeće podatke o fakturi iz propertija FakturaZaglavlje update-ujem podacima iz kontrola
                    FakturaZaglavlje = Mapiraj_KontroleNaModel(FakturaZaglavlje);
                }
                else
                {
                    MessageBox.Show("Račun ne postoji u bazi.", "Greška");
                    return;
                }

                // 3. korak
                using (FaktureModel db = new FaktureModel())
                {
                    try
                    {
                        db.Entry(FakturaZaglavlje).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show("Izmene su snimljene.", "Snimanje podataka");
                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška prilikom snimanja podataka!", "Greška");
                        return;
                    }
                }
            }

        }

        private void BrisanjeStavkeFakture(int? _stavkaFaktureId)
        {

            FaktureStavke stavkaFaktureZaBrisanje;

            using (FaktureModel db = new FaktureModel())
            {
                stavkaFaktureZaBrisanje = db.FaktureStavke
                    .Where(x => x.ID == _stavkaFaktureId)
                    .SingleOrDefault();

                if (stavkaFaktureZaBrisanje != null)
                {
                    DialogResult dr =
                        MessageBox.Show("Stavka računa će biti obrisana!\r\nDa li želite da nastavite?", "Brisanje stavke računa", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            db.Entry(stavkaFaktureZaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();

                            MessageBox.Show("Podaci su uspešno obrisani.", "Brisanje podataka");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Greška prilikom brisanja podataka.", "Brisanje podataka");
                            return;
                        }
                    }
                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Podatak ne postoji u bazi.", "Greška");
                }
            }

            PopuniListuStavkiFakture();
        }

        
        private void btnStavkaFakture_Click(object sender, EventArgs e)
        {
            DodajNovuStavkuFakture();
        }

        private void DodajNovuStavkuFakture()
        {
            StavkaFaktureForm stavkaFakture = new StavkaFaktureForm(null, FakturaZaglavlje.ID);
            stavkaFakture.labelNaslov.Text = "Dodavanje stavke računa";
            stavkaFakture.ShowDialog();

            PopuniListuStavkiFakture();
        }


        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

     
        
        private string GenerisiNoviBrojRacuna()
        {
            List<string> listaBrojevaIzdatihRacuna = null;

            using (FaktureModel db = new FaktureModel())
            {
                // lista brojeva RN za tekuću godinu
                listaBrojevaIzdatihRacuna = new List<string>(db.Fakture
                    .Where(x => x.DatumIzdavanjaRN.Year == DateTime.Now.Year)
                    .Select(r => r.BrojRN)
                    .ToList());
            }

            int sufiksBrojaRN;
            List<int> listaSufiksaBrojevaRacuna = new List<int>();

            foreach (string brojRacuna in listaBrojevaIzdatihRacuna)
            {
                string poslednjaDvaBrojaRacuna = brojRacuna.Substring(brojRacuna.Length - 3);

                if (int.TryParse(poslednjaDvaBrojaRacuna, out sufiksBrojaRN))
                    listaSufiksaBrojevaRacuna.Add(sufiksBrojaRN);

                else continue;
            }

            int pocetniBrojRN = 1;
            string zadnjeCifreBrojaRN = string.Empty;

            if (listaSufiksaBrojevaRacuna.Count > 0)
                zadnjeCifreBrojaRN = (listaSufiksaBrojevaRacuna.Max() + 1).ToString("000");

            else
                zadnjeCifreBrojaRN = pocetniBrojRN.ToString("000");

            string noviBrojRacuna = "RN-" + DateTime.Now.Year + "-" + zadnjeCifreBrojaRN;
            return noviBrojRacuna;
        }



        private void PuniComboTekicihRacuna()
        {

            using (FaktureModel db = new FaktureModel())
            {
                // Lista tekućih računa prodavca
                List<FirmeTR> listaTRProdavaca = new List<FirmeTR>();
                var prodavacId = db.FirmePodaci
                    .Where(x => x.Kategorija == "P")
                    .Select(k => k.Id)
                    .First();
                listaTRProdavaca = db.FirmeTR
                    .Where(p => p.FirmePodaciId == prodavacId)
                    .ToList();
                comboTR.DataSource = listaTRProdavaca;
                comboTR.DisplayMember = "BrojTR";
                comboTR.ValueMember = "ID";

            }
        }

        
        private void UcitajListuKupacaZaCombobox(int _selectedItem = 0)
        {
            using (FaktureModel db = new FaktureModel())
            {
                ListaKupaca = db.FirmePodaci
                    .Where(x => x.Kategorija == "K")
                    .ToList();
            }

            comboKupac.DataSource = ListaKupaca;
            comboKupac.DisplayMember = "NazivPrviRed";
            comboKupac.ValueMember = "Id";            
            comboKupac.SelectedItem = _selectedItem;
        }

        private void IspisiNazivKupca(int? idKupca)
        {
            if (idKupca == null || idKupca == 0)
            {
                labelNaziv.Text = string.Empty;
                labelNazivDrugiRed.Text = string.Empty;
                labelAdresa.Text = string.Empty;
                labelPTTMesto.Text = string.Empty;
                labelPIB.Text = string.Empty;
            }
            else
            {
                OdabraniKupac = ListaKupaca
                    .Where(k => k.Id == idKupca)
                    .SingleOrDefault();

                labelNaziv.Text = OdabraniKupac.NazivPrviRed;
                labelNazivDrugiRed.Text = OdabraniKupac.NazivDrugiRed;
                labelAdresa.Text = OdabraniKupac.Adresa;
                labelPTTMesto.Text = OdabraniKupac.PostBroj + " " + OdabraniKupac.Mesto;
                labelPIB.Text = "PIB " + OdabraniKupac.PIB;

            }
        }



        private void btnSnimiFakturu_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                // MessageBox.Show("unos je ok");
                SnimanjeZaglavljaFakture();
                btnStavkaFakture.Visible = true;
            }
            else
            {
                MessageBox.Show("Morate popuniti obeležena polja.", "Greška kod unosa");
            }


        }

        private void DGVStavkeRacuna_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ListaStavkiFaktureView selektovanaStavkaFakture = (ListaStavkiFaktureView)dgvStavkeRacuna.CurrentRow.DataBoundItem;
            if (selektovanaStavkaFakture == null)
            {
                return;
            }

            MessageBox.Show(selektovanaStavkaFakture.ID.ToString());

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // izmena stavke   
            if (dgvStavkeRacuna.CurrentRow == null)
            {
                MessageBox.Show("Odaberi stavku");
                return;
            }
            else
            {
                ListaStavkiFaktureView selektovanaStavkaFakture = (ListaStavkiFaktureView)dgvStavkeRacuna.CurrentRow.DataBoundItem;

                // indeks odabranog zapisa
                IndeksOdabraneStavkeFakture = dgvStavkeRacuna.CurrentCell.RowIndex;

                if (selektovanaStavkaFakture == null)
                {
                    return;
                }
                StavkaFaktureForm stavkaFakture = new StavkaFaktureForm(selektovanaStavkaFakture.ID, FakturaZaglavlje.ID);
                stavkaFakture.ShowDialog();

                PopuniListuStavkiFakture();

                // vraćanje na odabrani zapis nakon editovanja
                dgvStavkeRacuna.CurrentCell = dgvStavkeRacuna.Rows[IndeksOdabraneStavkeFakture].Cells[2];
            }
            
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // brisanje stavke fakture
            if (dgvStavkeRacuna.CurrentRow == null)
            {
                MessageBox.Show("Odaberi stavku");
                return;
            }
            else
            {
                ListaStavkiFaktureView selektovanaStavkaFakture = (ListaStavkiFaktureView)dgvStavkeRacuna.CurrentRow.DataBoundItem;

                BrisanjeStavkeFakture(selektovanaStavkaFakture.ID);

                PopuniListuStavkiFakture();
            }
          
        }


        private void comboKupac_SelectionChangeCommitted(object sender, EventArgs e)
        {

            int idkupca = (int)comboKupac.SelectedValue;

            IspisiNazivKupca(idkupca);

            linkIzmeniKupca.Enabled = true;


        }

        /* VALIDACIJA KONTROLA  */

        private void textMestoIzdavanja_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textMestoIzdavanja.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderFakturaZaglavlje.SetError(textMestoIzdavanja, "Upišite mesto izdavanja računa.");
            }
            e.Cancel = cancel;

        }

        private void textMestoIzdavanja_Validated(object sender, EventArgs e)
        {
            // Validacija je uspešna, brisanje poruke o greški
            errorProviderFakturaZaglavlje.SetError(textMestoIzdavanja, string.Empty);
        }

        private void textMestoPrometa_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textMestoPrometa.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderFakturaZaglavlje.SetError(textMestoPrometa, "Upišite mesto prometa.");
            }
            e.Cancel = cancel;
        }

        private void textMestoPrometa_Validated(object sender, EventArgs e)
        {
            // Validacija je uspešna, brisanje poruke o greški
            errorProviderFakturaZaglavlje.SetError(textMestoPrometa, string.Empty);
        }

        private void datumPrometaDO_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(datumPrometaDO.Value < datumPrometa.Value))
            {
                cancel = false;
            }
            else
            {
                cancel = true;
                errorProviderFakturaZaglavlje.SetError(datumPrometaDO, "Krajnji datum je manji od početnog.");
            }
            e.Cancel = cancel;
        }

        private void datumPrometaDO_Validated(object sender, EventArgs e)
        {
            errorProviderFakturaZaglavlje.SetError(datumPrometaDO, string.Empty);
        }

        private void datumPrometa_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(datumPrometa.Value > datumPrometaDO.Value))
            {
                cancel = false;
            }
            else
            {
                cancel = true;
                errorProviderFakturaZaglavlje.SetError(datumPrometa, "Početni datum je veći od krajnjeg.");
            }
            e.Cancel = cancel;
        }

        private void datumPrometa_Validated(object sender, EventArgs e)
        {
            errorProviderFakturaZaglavlje.SetError(datumPrometa, string.Empty);
        }

        private void comboKupac_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(comboKupac.SelectedIndex == -1))
            {
                cancel = false;
            }
            else
            {
                cancel = true;
                errorProviderFakturaZaglavlje.SetError(comboKupac, "Odabrerite kupca.");
            }
            e.Cancel = cancel;
        }

        private void comboKupac_Validated(object sender, EventArgs e)
        {
            errorProviderFakturaZaglavlje.SetError(comboKupac, string.Empty);
        }

        private void textFakturuIzdao_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textFakturuIzdao.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderFakturaZaglavlje.SetError(textFakturuIzdao, "Upišite ime i prezime izdavaoca fakture.");
            }
            e.Cancel = cancel;
        }

        private void textFakturuIzdao_Validated(object sender, EventArgs e)
        {
            errorProviderFakturaZaglavlje.SetError(textFakturuIzdao, string.Empty);
        }

        private void FakturaForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            int brojStavkiFakture = dgvStavkeRacuna.RowCount;


            if (FakturaZaglavlje.ID > 0 && brojStavkiFakture == 0)
            {
                // služi za brisanje snimljenog zaglavlja ukoliko se odustane od daljeg unosa
                // i ako nema stavku fakture, obaveštava se korisnik

                using (FaktureModel db = new FaktureModel())
                {

                    FakturaZaglavlje = db.Fakture
                        .Where(x => x.ID == FakturaZaglavlje.ID)
                        .SingleOrDefault();

                    if (FakturaZaglavlje != null)
                    {
                        DialogResult dr =
                            MessageBox.Show("Stavke računa nisu dodate, a račun neće biti snimljen u evidenciju.\r\n \r\nDa li želite da nastavite sa zatvaranjem?", "Račun", MessageBoxButtons.YesNo);


                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                db.Entry(FakturaZaglavlje).State = System.Data.Entity.EntityState.Deleted;
                                db.SaveChanges();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Greška!", "Račun");
                                return;
                            }
                        }
                        if (dr == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Podatak ne postoji u bazi!", "Brisanje zaglavlja računa.");
                        return;
                    }

                }
            }

        }

        private void linkIzmeniKupca_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // EDIT KUPCA SA FAKTURE ZAGLAVLJE

            FirmePodaci izabaraniKupac = (FirmePodaci)comboKupac.SelectedItem;

            if (izabaraniKupac != null)
            {
                PodaciZaFakturuForm izmeniPodatkeOKupcu = new PodaciZaFakturuForm(izabaraniKupac.Id);
                izmeniPodatkeOKupcu.ShowDialog();
                UcitajListuKupacaZaCombobox();
                comboKupac.SelectedValue = izabaraniKupac.Id;
                IspisiNazivKupca(izabaraniKupac.Id);
            }
            else
            {
                MessageBox.Show("Kupac ne postoji u evidenciji", "Greška");
                return;
            }
            
        }

        private void linkNoviKupac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // NOVI KUPAC SA FAKTURE ZAGLAVLJE

            PodaciZaFakturuForm noviKupac = new PodaciZaFakturuForm(null);
            noviKupac.ShowDialog();

            UcitajListuKupacaZaCombobox();
            comboKupac.SelectedValue = PodaciZaFakturuForm.KupacId_ZaOstaleForme;
            IspisiNazivKupca(PodaciZaFakturuForm.KupacId_ZaOstaleForme);
            linkIzmeniKupca.Enabled = true;

        }

        private void buttonStampa_Click(object sender, EventArgs e)
        {
           
            StampanjeFakture stampanjeFakture = new StampanjeFakture(FakturaZaglavlje.ID);
                        

            stampanjeFakture.ShowDialog();
        }

        private void Enter_NextControl(object sender, KeyEventArgs e)
        {

            /* prelazak na iduću kontrolu pomoću <enter> i close sa <esc> */


            Control nextControl;

            if (e.KeyCode == Keys.Enter)
            {
                nextControl = GetNextControl(ActiveControl, !e.Shift);
                if (nextControl == null)
                {
                    nextControl = GetNextControl(null, true);
                }
                nextControl.Focus();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }


            if(e.KeyCode == Keys.Insert)
            {
                DodajNovuStavkuFakture();
            }


        }

        private void datumPrometa_Leave(object sender, EventArgs e)
        {
            datumPrevozOd.Value = datumPrometa.Value;
        }

        private void datumPrometaDO_Leave(object sender, EventArgs e)
        {
            datumPrevozDo.Value = datumPrometaDO.Value;
        }
    }
}
