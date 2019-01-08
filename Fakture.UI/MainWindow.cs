using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakture.UI;
using Fakture.Model;
using System.Threading;

namespace Fakture.UI
{
    public partial class MainWindow : Form
    {
        // prikaz tbirnih podataka
        private decimal VrednostBezPDVaTotal { get; set; }
        private decimal IznosRabataTotal { get; set; }
        private decimal OsnovicaZaPDVTotal { get; set; } // vrednostBezPDV - IznosRabata
        private decimal IznosPDVTotal { get; set; }
        private decimal VrednostSaPDVTotal { get; set; }        
        
        private int ukupanBrojStavkiPrikazaTotal { get; set; }

        // liste
        public List<ListaFakturaView> ListaFaktura { get; set; }
        public List<ListaKupacaView> ListaKupaca { get; set; }

        // koriste se za povratak na odabrani zapis nakon refresh-a liste
        private int IndeksOdabraneFakture { get; set; } 
        private int IndeksOdabranogKupca { get; set; }

        // početni datum filtera faktura
        private DateTime NajmanjiDatumIzdateFakture { get; set; }

        private LoadingForm loadingForm;

        public static int currentYear = DateTime.Now.Year;


        public MainWindow()
        {
            InitializeComponent();
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            // učitavanje podataka se vrši u drugoj niti
            // kroz bg worker i metodu UcitajPodatkeZaFormu        

            lblVrednostBezPDV.Text = string.Empty;
            lblIznosRabata.Text = string.Empty;
            lblOsnovicaPDV.Text = string.Empty;
            lblIznosPDV.Text = string.Empty;
            lblVrednostSaPDV.Text = string.Empty;
            lblBrojStavki.Text = string.Empty;

            bgWorkerUcitavanjePodataka.RunWorkerAsync();

            PokreniLoadingForm();

            // ovo mora poslednje - setovanja kontrola na default
            labelNaslovnaLinija.Text = IspisiNaslovnuLiniju();
            datePocetniDatum.Value = NajmanjiDatumIzdateFakture;
            dateKrajnjiDatum.Value = DateTime.Now.Date;

            VrednostBezPDVaTotal = decimal.Zero;
            IznosRabataTotal = decimal.Zero;
            OsnovicaZaPDVTotal = decimal.Zero;
            IznosPDVTotal = decimal.Zero;
            VrednostSaPDVTotal = decimal.Zero;
            ukupanBrojStavkiPrikazaTotal = 0;

        }





        private void ResetujFilterFaktura()
        {
            datePocetniDatum.Value = NajmanjiDatumIzdateFakture;
            dateKrajnjiDatum.Value = DateTime.Now.Date;

            comboListaKupaca.SelectedIndex = -1;

            UcitajListuFaktura(currentYear);
            PrikaziListuFaktura();

            //FilterListeFaktura(datePocetniDatum.Value, dateKrajnjiDatum.Value, null);

            linkPonistiFilter.Visible = false;

        }

        private void PokreniLoadingForm()
        {
            loadingForm = new LoadingForm();
            loadingForm.ShowDialog();
        }


        private int UcitajPodatkeZaFormu()
        {
            // ovde se kroz bgworker vrši učitavanje svih podataka za formu
            try
            {
                UcitajListuFaktura(currentYear);

                UcitajListuKupaca();

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        private void UcitajComboListaKupaca()
        {
            comboListaKupaca.DataSource = ListaKupaca;
            comboListaKupaca.DisplayMember = "NazivPrviRed";
            comboListaKupaca.ValueMember = "Id";
            comboListaKupaca.SelectedIndex = -1;
        }


        private void FilterListeFaktura(DateTime pocetniDatum, DateTime krajnjiDatum, int? kupacId)
        {
            using (FaktureModel db = new FaktureModel())
            {
                switch (kupacId)
                {
                    case null:
                        ListaFaktura = db.ListaFakturaView
                            .Where(x => x.DatumIzdavanjaRN >= pocetniDatum && x.DatumIzdavanjaRN <= krajnjiDatum)
                            .ToList();
                        break;
                    default:
                        ListaFaktura = db.ListaFakturaView
                            .Where(
                            x => x.DatumIzdavanjaRN >= pocetniDatum &&
                            x.DatumIzdavanjaRN <= krajnjiDatum &&
                            x.KupacId == kupacId
                            )
                            .ToList();
                        break;
                }
            }

            PrikaziListuFaktura();
            linkPonistiFilter.Visible = true;
        }


        private string IspisiNaslovnuLiniju()
        {
            string naslovnaLinija = string.Empty;

            using (FaktureModel db = new FaktureModel())
            {
                naslovnaLinija = db.FirmePodaci
                    .Where(x => x.Kategorija == "P")
                    .Select(v => v.NazivPrviRed + " " + v.NazivDrugiRed)
                    .SingleOrDefault()
                    .ToString();
            }

            return naslovnaLinija;
        }



        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private void podaciOFirmiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // PRODAVAC - kategorija 'P'

            int izdavaocFaktureId;

            using (FaktureModel db = new FaktureModel())
            {
                izdavaocFaktureId = db.FirmePodaci
                    .Where(x => x.Kategorija == "P")
                    .Select(x => x.Id)
                    .First();
            }

            PodaciZaFakturuForm podaciIzdavaocaFakture = new PodaciZaFakturuForm(izdavaocFaktureId);

            podaciIzdavaocaFakture.ShowDialog();
        }

        

        public void UcitajListuFaktura(int godina)
        {
            using (FaktureModel db = new FaktureModel())
            {
                ListaFaktura = db.ListaFakturaView
                    .Where(x => x.DatumIzdavanjaRN.Year == godina)
                    .OrderByDescending(d => d.DatumIzdavanjaRN)
                    .ToList();

                if (ListaFaktura.Count == 0)
                {
                    NajmanjiDatumIzdateFakture = DateTime.Now.Date;
                }
                else
                {
                    // koristi se kao početni datum za filtriranje podataka 
                    var najmanjiDatumIzdateFakture = db.ListaFakturaView
                        .Min(x => x.DatumIzdavanjaRN);

                    NajmanjiDatumIzdateFakture = najmanjiDatumIzdateFakture;
                }
                
            } 
        }



        private void PrikaziListuFaktura()
        {
            if (ListaFaktura != null)
            {

                // Bind your DataGridView to a BindingList<T> instead

                var bindingListaFakturaView = new BindingList<ListaFakturaView>(ListaFaktura);
                var dataGridSource = new BindingSource(bindingListaFakturaView, null);

                dgvListaRacuna.DataSource = dataGridSource;

                dgvListaRacuna.Columns["ID"].Visible = false;

                dgvListaRacuna.Columns["BrojRN"].Visible = true;
                dgvListaRacuna.Columns["BrojRN"].HeaderText = "Broj računa";
                dgvListaRacuna.Columns["BrojRN"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;


                dgvListaRacuna.Columns["DatumIzdavanjaRN"].Visible = true;
                dgvListaRacuna.Columns["DatumIzdavanjaRN"].HeaderText = "Datum izdavanja";
                dgvListaRacuna.Columns["DatumIzdavanjaRN"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                dgvListaRacuna.Columns["MestoIzdavanjaRN"].Visible = true;
                dgvListaRacuna.Columns["MestoIzdavanjaRN"].HeaderText = "Mesto izdavanja";
                dgvListaRacuna.Columns["MestoIzdavanjaRN"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                dgvListaRacuna.Columns["DatumPrometa"].Visible = true;
                dgvListaRacuna.Columns["DatumPrometa"].HeaderText = "Promet od";
                dgvListaRacuna.Columns["DatumPrometa"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                dgvListaRacuna.Columns["DatumPrometaDO"].Visible = true;
                dgvListaRacuna.Columns["DatumPrometaDO"].HeaderText = "Promet do";
                dgvListaRacuna.Columns["DatumPrometaDO"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                dgvListaRacuna.Columns["MestoPrometa"].Visible = true;
                dgvListaRacuna.Columns["MestoPrometa"].HeaderText = "Mesto prometa";
                dgvListaRacuna.Columns["MestoPrometa"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                dgvListaRacuna.Columns["NazivPrviRed"].Visible = true;
                dgvListaRacuna.Columns["NazivPrviRed"].HeaderText = "Kupac";
                dgvListaRacuna.Columns["NazivPrviRed"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

                dgvListaRacuna.Columns["NazivDrugiRed"].Visible = false;
                dgvListaRacuna.Columns["NazivDrugiRed"].HeaderText = "kupca";
                dgvListaRacuna.Columns["NazivDrugiRed"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

                dgvListaRacuna.Columns["Adresa"].Visible = false;
                dgvListaRacuna.Columns["PostBroj"].Visible = false;

                dgvListaRacuna.Columns["Mesto"].Visible = false;
                dgvListaRacuna.Columns["Mesto"].HeaderText = "Mesto";
                dgvListaRacuna.Columns["Mesto"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                /* IZNOSI DECIMAL */
                dgvListaRacuna.Columns["VrednostBezPDVa"].Visible = true;
                dgvListaRacuna.Columns["VrednostBezPDVa"].HeaderText = "Vrednost bez PDV";
                dgvListaRacuna.Columns["VrednostBezPDVa"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
                dgvListaRacuna.Columns["VrednostBezPDVa"].DefaultCellStyle.Format = "N2";

                dgvListaRacuna.Columns["IznosRabata"].Visible = true;
                dgvListaRacuna.Columns["IznosRabata"].HeaderText = "Rabat";
                dgvListaRacuna.Columns["IznosRabata"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
                dgvListaRacuna.Columns["IznosRabata"].DefaultCellStyle.Format = "N2";

                dgvListaRacuna.Columns["OsnovicaZaPDV"].Visible = true;
                dgvListaRacuna.Columns["OsnovicaZaPDV"].HeaderText = "Osnovica PDV";
                dgvListaRacuna.Columns["OsnovicaZaPDV"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
                dgvListaRacuna.Columns["OsnovicaZaPDV"].DefaultCellStyle.Format = "N2";


                dgvListaRacuna.Columns["IznosPDVa"].Visible = true;
                dgvListaRacuna.Columns["IznosPDVa"].HeaderText = "Iznos PDV";
                dgvListaRacuna.Columns["IznosPDVa"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
                dgvListaRacuna.Columns["IznosPDVa"].DefaultCellStyle.Format = "N2";

                dgvListaRacuna.Columns["VrednostSaPDV"].Visible = true;
                dgvListaRacuna.Columns["VrednostSaPDV"].HeaderText = "Vrednost sa PDV";
                dgvListaRacuna.Columns["VrednostSaPDV"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
                dgvListaRacuna.Columns["VrednostSaPDV"].DefaultCellStyle.Format = "N2";

                dgvListaRacuna.Columns["PIB"].Visible = false;

                dgvListaRacuna.Columns["Telefon"].Visible = false;
                dgvListaRacuna.Columns["Telefon"].HeaderText = "Telefon";
                dgvListaRacuna.Columns["Telefon"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                dgvListaRacuna.Columns["BrojTR"].Visible = false;
                dgvListaRacuna.Columns["NazivBanke"].Visible = false;

                dgvListaRacuna.Columns["RokPlacanja"].Visible = true;
                dgvListaRacuna.Columns["RokPlacanja"].HeaderText = "Valuta";
                dgvListaRacuna.Columns["RokPlacanja"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                dgvListaRacuna.Columns["NacinPlacanja"].Visible = false;
                dgvListaRacuna.Columns["FakturuIzdao"].Visible = false;
                dgvListaRacuna.Columns["PrevozDatumOd"].Visible = false;
                dgvListaRacuna.Columns["PrevozDatumDo"].Visible = false;

                dgvListaRacuna.Columns["PrevozImePrezime"].Visible = true;
                dgvListaRacuna.Columns["PrevozImePrezime"].HeaderText = "Prevoznik";
                dgvListaRacuna.Columns["PrevozImePrezime"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                dgvListaRacuna.Columns["PrevozRegBrojVozila"].Visible = true;
                dgvListaRacuna.Columns["PrevozRegBrojVozila"].HeaderText = "Reg.broj";
                dgvListaRacuna.Columns["PrevozRegBrojVozila"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                dgvListaRacuna.Columns["Napomena"].Visible = true;
                dgvListaRacuna.Columns["Napomena"].HeaderText = "Napomena";
                dgvListaRacuna.Columns["Napomena"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

                dgvListaRacuna.Columns["KupacId"].Visible = false;

                dgvListaRacuna.Columns["BrojFI"].Visible = true;
                dgvListaRacuna.Columns["BrojFI"].HeaderText = "Broj FI";

                dgvListaRacuna.AutoResizeColumns();


                // Zbirne kalkulacije
                VrednostBezPDVaTotal = decimal.Zero;
                IznosRabataTotal = decimal.Zero;
                OsnovicaZaPDVTotal = decimal.Zero;
                IznosPDVTotal = decimal.Zero;
                VrednostSaPDVTotal = decimal.Zero;
                ukupanBrojStavkiPrikazaTotal = 0;

                foreach (var item in ListaFaktura)
                {
                    VrednostBezPDVaTotal += Convert.ToDecimal(item.VrednostBezPDVa);
                    IznosRabataTotal += Convert.ToDecimal(item.IznosRabata);
                    OsnovicaZaPDVTotal += Convert.ToDecimal(item.OsnovicaZaPDV);
                    IznosPDVTotal += Convert.ToDecimal(item.IznosPDVa);
                    VrednostSaPDVTotal += Convert.ToDecimal(item.VrednostSaPDV);
                    ukupanBrojStavkiPrikazaTotal++;
                }

                lblVrednostBezPDV.Text = VrednostBezPDVaTotal.ToString("N2");
                lblIznosRabata.Text = IznosRabataTotal.ToString("N2");
                lblOsnovicaPDV.Text = OsnovicaZaPDVTotal.ToString("N2");
                lblIznosPDV.Text = IznosPDVTotal.ToString("N2");
                lblVrednostSaPDV.Text = VrednostSaPDVTotal.ToString("N2");
                lblBrojStavki.Text = "Broj stavki: " + ukupanBrojStavkiPrikazaTotal.ToString();
                
            }
            else
            {
                return;
            }
        }





        private int ObrisiIzabranuFakturu(int _fakturaId)
        {

            Model.Fakture fakturaZaBrisanje;

            int result = 0;

            using (FaktureModel db = new FaktureModel())
            {
                fakturaZaBrisanje = db.Fakture
                    .Where(x => x.ID == _fakturaId)
                    .SingleOrDefault();
                
                if (fakturaZaBrisanje != null)
                {
                    DialogResult dr =
                        MessageBox.Show("Odabrani račun će biti obrisan!\r\nDa li želite da nastavite sa brisanjem?", "Brisanje računa", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            db.Entry(fakturaZaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                            result = db.SaveChanges();

                            if (result > 0)
                            {
                                MessageBox.Show("Podaci su uspešno obrisani.", "Brisanje podataka");
                                return result;
                            }
                            return result;

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Greška prilikom brisanja podataka.", "Brisanje podataka");
                            return result;
                        }
                    }
                    if (dr == DialogResult.No)
                    {
                        return result;
                    }
                    return result;
                }
                else
                {
                    MessageBox.Show("Podatak ne postoji u bazi.", "Greška");
                    return result;
                }
            }
        }


        private void btnNoviRacun_Click(object sender, EventArgs e)
        {           
            FakturaForm novaFaktura = new FakturaForm(null);

            novaFaktura.ShowDialog();
            UcitajListuFaktura(currentYear);
            PrikaziListuFaktura();           
        }


        private void dgvListaRacuna_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // IZMENA FAKTURE 
            if (dgvListaRacuna.CurrentRow == null)
            {
                MessageBox.Show("Odaberi stavku");
                return;
            }
            else
            {
                // selektovani red -> objekat kolekcije
                ListaFakturaView selektovaniRed = (ListaFakturaView)dgvListaRacuna.CurrentRow.DataBoundItem;

                // indeks odabranog zapisa
                IndeksOdabraneFakture = dgvListaRacuna.CurrentCell.RowIndex;

                FakturaForm novaFaktura = new FakturaForm(selektovaniRed.ID);

                novaFaktura.ShowDialog();
                UcitajListuFaktura(currentYear);
                PrikaziListuFaktura();

                // vraćanje na odabrani zapis nakon editovanja
                dgvListaRacuna.CurrentCell = dgvListaRacuna.Rows[IndeksOdabraneFakture].Cells[1];
            }
        }


        // kontekstni meni
        private void contextMenuItemIzmeni_Click(object sender, EventArgs e)
        {
            IzmeniPodatkeFakture();
        }

        private void IzmeniPodatkeFakture()
        {
            // IZMENA FAKTURE 
            if (dgvListaRacuna.CurrentRow == null)
            {
                MessageBox.Show("Odaberi stavku");
                return;
            }
            else
            {
                ListaFakturaView selektovaniRed = (ListaFakturaView)dgvListaRacuna.CurrentRow.DataBoundItem;

                // indeks odabranog zapisa
                IndeksOdabraneFakture = dgvListaRacuna.CurrentCell.RowIndex;

                FakturaForm novaFaktura = new FakturaForm(selektovaniRed.ID);

                novaFaktura.ShowDialog();
                UcitajListuFaktura(currentYear);
                PrikaziListuFaktura();

                // vraćanje na odabrani zapis nakon editovanja
                dgvListaRacuna.CurrentCell = dgvListaRacuna.Rows[IndeksOdabraneFakture].Cells[1];
            }
        }



        private void MenuItemObrisiRacun_Click(object sender, EventArgs e)
        {
            ObrisiRacun();
        }

        private void ObrisiRacun()
        {
            // BRISANJE FAKTURE - MAIN WINDOW
            if (dgvListaRacuna.CurrentRow == null)
            {
                MessageBox.Show("Odaberi stavku");
                return;
            }
            else
            {
                ListaFakturaView selektovaniRed = (ListaFakturaView)dgvListaRacuna.CurrentRow.DataBoundItem;

                // indeks odabranog zapisa
                IndeksOdabraneFakture = dgvListaRacuna.CurrentCell.RowIndex;

                int rezultatBrisanja = ObrisiIzabranuFakturu(selektovaniRed.ID);

                switch (rezultatBrisanja)
                {
                    case 0: // NIJE OBRISANA
                        // vraćanje na odabrani zapis nakon štampanja
                        dgvListaRacuna.CurrentCell = dgvListaRacuna.Rows[IndeksOdabraneFakture].Cells[1];
                        break;

                    default:
                        UcitajListuFaktura(currentYear);
                        PrikaziListuFaktura();
                        break;
                }

            }
        }

        private void contextMenuItemStampaj_Click(object sender, EventArgs e)
        {
            StampajRacun();
        }


        private void StampajRacun()
        {
            if (dgvListaRacuna.CurrentRow == null)
            {
                MessageBox.Show("Odaberi stavku");
                return;
            }
            else
            {
                ListaFakturaView selektovaniRed = (ListaFakturaView)dgvListaRacuna.CurrentRow.DataBoundItem;

                // indeks odabranog zapisa
                IndeksOdabraneFakture = dgvListaRacuna.CurrentCell.RowIndex;

                StampanjeFakture stampanjeFakture = new StampanjeFakture(selektovaniRed.ID);

                stampanjeFakture.ShowDialog();
                UcitajListuFaktura(currentYear);
                PrikaziListuFaktura();

                // vraćanje na odabrani zapis nakon štampanja
                dgvListaRacuna.CurrentCell = dgvListaRacuna.Rows[IndeksOdabraneFakture].Cells[1];
            }

        }


        private void btnStampaj_Click(object sender, EventArgs e)
        {
            StampajRacun();
        }



        /* K U P C I */

        public void UcitajListuKupaca()
        {

            using (FaktureModel db = new FaktureModel())
            {
                ListaKupaca = db.ListaKupacaView
                    .ToList();
            }
            var bindingListaKupacaView = new BindingList<ListaKupacaView>(ListaKupaca);
            var dataGridSource = new BindingSource(bindingListaKupacaView, null);

            dgvListaKupaca.DataSource = dataGridSource;
            dgvListaKupaca.AutoResizeColumns();
            
        }


        private void IzmeniPodatkeKupca()
        {
            if (dgvListaKupaca.CurrentRow == null)
            {
                MessageBox.Show("Odaberi kupca");
                return;
            }
            else
            {
                ListaKupacaView kupacZaBrisanje = (ListaKupacaView)dgvListaKupaca.CurrentRow.DataBoundItem;

                // indeks odabranog kupca
                IndeksOdabranogKupca = dgvListaKupaca.CurrentCell.RowIndex;

                PodaciZaFakturuForm izmenaPodatakaOKupcuForm = new PodaciZaFakturuForm(kupacZaBrisanje.Id);

                izmenaPodatakaOKupcuForm.ShowDialog();
                UcitajListuKupaca();

                // vraćanje na odabranog kupca
                dgvListaKupaca.CurrentCell = dgvListaKupaca.Rows[IndeksOdabranogKupca].Cells[1];

            }
        }



        private void BrisanjePodatakaKupca(int kupacId)
        {
            FirmePodaci kupacZaBrisanje;

            using (FaktureModel db = new FaktureModel())
            {
                kupacZaBrisanje = db.FirmePodaci
                    .Where(x => x.Id == kupacId)
                    .SingleOrDefault();

                if (kupacZaBrisanje != null)
                {
                    DialogResult dr = MessageBox.Show("PAŽNJA !!!\r\n\r\nSvi podaci o kupcu će biti obrisani, uključujući i izdate račune!\r\nOperacija je bespovratna!\r\n\r\nDa li želite da nastavite sa brisanjem?", "Brisanje podataka", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            db.Entry(kupacZaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();

                            MessageBox.Show("Podaci su uspešno obrisani.", "Brisanje podataka");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Greška prilikom brisanja podataka.", "Brisanje podataka");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Greška prilikom brisanja podataka.\r\nKupac ne postoji u bazi!", "Brisanje podataka");
                    return;
                }
            }

        }

        private void btnNoviKupac_Click(object sender, EventArgs e)
        {
            PodaciZaFakturuForm noviKupacForm = new PodaciZaFakturuForm(null);

            noviKupacForm.ShowDialog();

            UcitajListuKupaca();

            UcitajComboListaKupaca();
        }

        private void btnObrisiKupca_Click(object sender, EventArgs e)
        {
            ObrisiKupca();
            UcitajComboListaKupaca();
        }

        private void ObrisiKupca()
        {
            if (dgvListaKupaca.CurrentRow == null)
            {
                MessageBox.Show("Odaberi stavku");
                return;
            }
            else
            {
                ListaKupacaView kupacZaBrisanje = (ListaKupacaView)dgvListaKupaca.CurrentRow.DataBoundItem;

                BrisanjePodatakaKupca(kupacZaBrisanje.Id);
                UcitajListuKupaca();
            }
        }

        private void btnIzmeniPodatke_Click(object sender, EventArgs e)
        {
            IzmeniPodatkeKupca();
        }





        private void bgWorkerUcitavanjePodataka_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            e.Result = UcitajPodatkeZaFormu();

        }

        private void bgWorkerUcitavanjePodataka_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                loadingForm.Close();
                PrikaziListuFaktura();
                UcitajComboListaKupaca();
            }
        }

        private void btnDetaljiIzmenaRN_Click(object sender, EventArgs e)
        {
            IzmeniPodatkeFakture();
        }

        private void btnBrisanjeRN_Click(object sender, EventArgs e)
        {
            ObrisiRacun();
        }

        private void btnFilterFaktura_Click(object sender, EventArgs e)
        {
            int? kupacId;

            if (comboListaKupaca.SelectedValue == null)
            {
                kupacId = null;
            }
            else
            {
                kupacId = (int)comboListaKupaca.SelectedValue;
            }            

            FilterListeFaktura(datePocetniDatum.Value, dateKrajnjiDatum.Value, kupacId);

        }

        private void linkPonistiFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetujFilterFaktura();
        }

        private void oNamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ONama kontakForm = new ONama();
            kontakForm.ShowDialog();
        }

        private void btn2017_Click(object sender, EventArgs e)
        {
            // lista faktura za 2017
            currentYear = 2017;
            UcitajListuFaktura(currentYear);
            PrikaziListuFaktura();
        }

        private void btn2018_Click(object sender, EventArgs e)
        {
            // lista faktura za 2018 godinu
            currentYear = 2018;
            UcitajListuFaktura(currentYear);
            PrikaziListuFaktura();
        }

        private void btn2019filter_Click(object sender, EventArgs e)
        {
            // lista faktura za 2018 godinu
            currentYear = DateTime.Now.Year;
            UcitajListuFaktura(currentYear);
            PrikaziListuFaktura();
        }
    }
}
