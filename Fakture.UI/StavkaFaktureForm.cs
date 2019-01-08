using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakture.Model;

namespace Fakture.UI
{
    public partial class StavkaFaktureForm : Form
    {
        private int? stavkaFaktureId { get; set; }
        private int? fakturaId { get; set; }
        public int IdOdabraneVrsteStavkeFakture { get; set; } //
        private FaktureStavke StavkaFakture { get; set; } // pojed. stavka 
        public VrsteStavkiRacuna VrstaStavkeRacuna { get; set; } // pojedinačana stavka, sadrži podatke za JM i poresku stopu
        private List<VrsteStavkiRacuna> ListaVrstaStavkiRacuna { get; set; } // lista vrsta, za combo
        private decimal CenaSaPDVomTemp { get; set; } // izračunata cena za prikaz ako je uključeno check cena sa pdv

        private decimal koefStopePDV; // koeficijent za računanje pdv-a



        public StavkaFaktureForm(int? _stavkaFaktureId, int? _fakturaId)
        {
            InitializeComponent();

            // This is a handy trick to prevent implicit validation of our controls when they lose focus.
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;


            stavkaFaktureId = _stavkaFaktureId;
            fakturaId = _fakturaId;

        }


        private void StavkaFakture_Load(object sender, EventArgs e)
        {
            /* 
             - Na osnovu stavkaFaktureId kreira se novi ili traži postojeći zapis.
             - StavkaFakture sadrži podatak o postojećoj ili novoj stavki
             - Mapiraj_ModelNaKontrole ispisuje podatke na formi o novom/postojećem zapisu.
             - Mapiraj_KontroleNaModel kao argument dobija novi/postojeći zapis
             i update-uje ga podacima iz kontrola na formi.
             - SnimanjePodataka na osnovu StavkaFakture vrši upis novog ili update zapisa
             */


            // povezivanje radio btn sa textbox enable/disable text box
            //textCenaBezPDV.DataBindings.Add("Enabled", radioBEZPDV, "Checked");
            //textCenaSaPDV.DataBindings.Add("Enabled", radioSAPDV, "Checked");

            PuniComboBoxove();

            /* NOVA STAVKA */
            if (stavkaFaktureId == null)
            {
                FaktureStavke novaStavkaFakture = new FaktureStavke()
                {
                    FakturaId = fakturaId,
                    CheckBoxCenaSaPDV = false,
                    CenaBezPDV = decimal.Zero,
                    Kolicina = decimal.Zero,
                    Rabat = decimal.Zero,
                    StopaPDV = 0,
                    VrstaStavkeRacunaId = comboNazivStavke.SelectedIndex
                };

                labelNaslov.Text = "Nova stavka računa";
                comboNazivStavke.SelectedIndex = -1;

                StavkaFakture = novaStavkaFakture;
                CenaSaPDVomTemp = decimal.Zero;
                koefStopePDV = decimal.Zero;
                VrstaStavkeRacuna = null;

                Mapiraj_ModelNakontrole(StavkaFakture);

            }
            /* POSTOJEĆA STAVKA */
            else
            {
                // setovanje kontrola za unos, aktivne su nakon izbora stavke fakture
                textDodatniOpis.Enabled = true;
                textKolicina.Enabled = true;
                textCenaBezPDV.Enabled = true;
                textRabat.Enabled = true;
                checkBoxCenaSaPDV.Enabled = true;

                labelNaslov.Text = "Izmena stavke računa";
                linkIzmeniStavku.Enabled = true;
                linkObrisiVrstuStavke.Enabled = true;

                using (FaktureModel db = new FaktureModel())
                {

                    var _stavkaFakture = db.FaktureStavke
                        .Where(x => x.ID == stavkaFaktureId)
                        .SingleOrDefault();

                    if (_stavkaFakture == null)
                    {
                        MessageBox.Show("Stavka ne postoji u evidenciji.", "Greška");
                        Close();
                        return;
                    }

                    // sadrži stopu pdv i JM za izabranu stavku fakture         
                    VrstaStavkeRacuna = db.VrsteStavkiRacuna
                        .Where(x => x.ID == _stavkaFakture.VrstaStavkeRacunaId)
                        .SingleOrDefault();

                    StavkaFakture = _stavkaFakture;

                    ///* kalkulacija koef stope pdv-a  */
                    //decimal _stopaPDV = Convert.ToDecimal(VrstaStavkeRacuna.StopaPDV);
                    //decimal _koefStopePDV = 1 + (_stopaPDV / 100);
                    //koefStopePDV = Convert.ToDecimal(_koefStopePDV);

                    KalkulacijaKoefStopePDVa();

                    CenaSaPDVomTemp = StavkaFakture.CenaBezPDV * koefStopePDV;




                    Mapiraj_ModelNakontrole(StavkaFakture);

                    NapraviPoreskuRekapitulaciju();
                }
            }

        }

        private void KalkulacijaKoefStopePDVa()
        {
            /* kalkulacija koef stope pdv-a  */
            decimal _stopaPDV = Convert.ToDecimal(VrstaStavkeRacuna.StopaPDV);
            decimal _koefStopePDV = 1 + (_stopaPDV / 100);
            koefStopePDV = Convert.ToDecimal(_koefStopePDV);
        }


        private void Mapiraj_ModelNakontrole(FaktureStavke _stavkaFakture)
        {
            //decimal koefStopePDV = decimal.Zero;

            //if (VrstaStavkeRacuna != null)
            //{
            //    // kalkulacije za prikaz cene sa ili bez pdv
            //    decimal _stopaPDV = Convert.ToDecimal(VrstaStavkeRacuna.StopaPDV);
            //    decimal _koefStopePDV = 1 + (_stopaPDV / 100);
            //    koefStopePDV = Convert.ToDecimal(_koefStopePDV);
            //}


            textStavkaID.Text = _stavkaFakture.ID.ToString();
            textFakturaId.Text = _stavkaFakture.FakturaId.ToString();
            comboNazivStavke.SelectedValue = (int)_stavkaFakture.VrstaStavkeRacunaId;

            textJedinicaMere.Text =
                (VrstaStavkeRacuna == null) ? string.Empty : VrstaStavkeRacuna.JedinicaMere.ToString();

            textDodatniOpis.Text = _stavkaFakture.VrstaStavkeDodOpis;
            textKolicina.Text = _stavkaFakture.Kolicina.ToString("N2");

            checkBoxCenaSaPDV.Checked = _stavkaFakture.CheckBoxCenaSaPDV;
            if (checkBoxCenaSaPDV.Checked == true)
            {
                //textCenaBezPDV.Text = _stavkaFakture.CenaBezPDV.ToString("N2");

                if (koefStopePDV != 0)
                {
                    //textCenaBezPDV.Text =
                    //    (_stavkaFakture.CenaBezPDV / koefStopePDV).ToString("N2");

                    textCenaBezPDV.Text =
                        CenaSaPDVomTemp.ToString("N2");
                }
                else
                {
                    textCenaBezPDV.Text = decimal.Zero.ToString("N2");
                }
            }
            else
            {

                textCenaBezPDV.Text = _stavkaFakture.CenaBezPDV.ToString("N2");

                //textCenaBezPDV.Text = _stavkaFakture.CenaBezPDV.ToString("N2");
            }


            textRabat.Text = _stavkaFakture.Rabat.ToString("N2");
            textStopaPDV.Text =
                (VrstaStavkeRacuna == null) ? 0.ToString() : VrstaStavkeRacuna.StopaPDV.ToString();

        }


        private FaktureStavke Mapiraj_KontroleNaModel(FaktureStavke _stavkaFakture)
        {
            //decimal koefStopePDV = decimal.Zero;

            //if (VrstaStavkeRacuna != null)
            //{
            //    // kalkulacije za prikaz cene sa ili bez pdv
            //    decimal _stopaPDV = Convert.ToDecimal(VrstaStavkeRacuna.StopaPDV);
            //    decimal _koefStopePDV = 1 + (_stopaPDV / 100);
            //    koefStopePDV = Convert.ToDecimal(_koefStopePDV);
            //}

            _stavkaFakture.ID = Convert.ToInt32(textStavkaID.Text);
            _stavkaFakture.FakturaId = Convert.ToInt32(textFakturaId.Text);
            _stavkaFakture.VrstaStavkeRacunaId = (int)comboNazivStavke.SelectedValue;
            _stavkaFakture.VrstaStavkeDodOpis = textDodatniOpis.Text;
            _stavkaFakture.Kolicina = Convert.ToDecimal(textKolicina.Text);

            _stavkaFakture.CheckBoxCenaSaPDV = checkBoxCenaSaPDV.Checked;
            if (checkBoxCenaSaPDV.Checked == true)
            {
                _stavkaFakture.CenaBezPDV =
                Convert.ToDecimal(textCenaBezPDV.Text) / koefStopePDV;

            }
            else
            {
                _stavkaFakture.CenaBezPDV = Convert.ToDecimal(textCenaBezPDV.Text);
            }


            _stavkaFakture.Rabat = Convert.ToDecimal(textRabat.Text);
            _stavkaFakture.StopaPDV = Convert.ToInt32(textStopaPDV.Text);

            _stavkaFakture.VrednostBezPDV = Convert.ToDecimal(textVrednostBezPDV.Text);
            _stavkaFakture.IznosRabata = Convert.ToDecimal(textIznosRabata.Text);
            _stavkaFakture.OsnovicaPDV = Convert.ToDecimal(textPoreskaOsnovica.Text);
            _stavkaFakture.IznosPDV = Convert.ToDecimal(textIznosPDVa.Text);
            _stavkaFakture.VrednostSaPDV = Convert.ToDecimal(textVrednostSaPDV.Text);

            return _stavkaFakture;
        }



        private void ConvertTextToDecimal(object sender, EventArgs e)
        {
            // konverzija teksta iz textboxova u decimal
            // konverzija za količinu, cenaBezPDV, cenuSaPDV i rabat
            TextBox _sender = (TextBox)sender;

            string _senderName = _sender.Name;

            decimal result;

            if (string.IsNullOrWhiteSpace(_sender.Text) || string.IsNullOrEmpty(_sender.Text))
            {
                result = 0m;
                _sender.Text = result.ToString();
                return;
            }
            else
            {
                bool isNumeric = decimal.TryParse(_sender.Text, out result);

                switch (_senderName)
                {
                    case "textKolicina":
                        StavkaFakture.Kolicina = result;
                        NapraviPoreskuRekapitulaciju();
                        break;


                    case "textCenaBezPDV":
                        {
                            //decimal _stopaPDV = Convert.ToDecimal(VrstaStavkeRacuna.StopaPDV);
                            //decimal _koefStopePDV = 1 + (_stopaPDV / 100);
                            //koefStopePDV = Convert.ToDecimal(_koefStopePDV);

                            if (checkBoxCenaSaPDV.Checked == true)
                            {
                                CenaSaPDVomTemp = result;
                                StavkaFakture.CenaBezPDV = result / koefStopePDV;
                            }
                            else
                            {
                                CenaSaPDVomTemp = result * koefStopePDV;
                                StavkaFakture.CenaBezPDV = result;
                            }

                            //StavkaFakture.CenaBezPDV = result;
                            NapraviPoreskuRekapitulaciju();
                            break;
                        }




                    case "textRabat":
                        {
                            if (result > 100 || result < 0)
                            {
                                MessageBox.Show("Vrednost rabata mora biti između 0 i 100.", "Rabat");
                                textRabat.Focus();
                                textRabat.SelectAll();
                                break;
                            }
                            StavkaFakture.Rabat = result;
                            NapraviPoreskuRekapitulaciju();
                            break;
                        }

                }
            }

            //NapraviPoreskuRekapitulaciju();

        }



        private void checkBoxCenaSaPDV_CheckedChanged(object sender, EventArgs e)
        {
            //decimal koefStopePDV = decimal.Zero;

            //if (VrstaStavkeRacuna != null)
            //{
            //    decimal _stopaPDV = Convert.ToDecimal(VrstaStavkeRacuna.StopaPDV);
            //    decimal _koefStopePDV = 1 + (_stopaPDV / 100);
            //    koefStopePDV = Convert.ToDecimal(_koefStopePDV);
            //}


            //// upisana cena je sa uračunatim pdv-om
            //if (checkBoxCenaSaPDV.Checked == true)
            //{
            //    //StavkaFakture.CenaBezPDV =
            //    //    Convert.ToDecimal(textCenaBezPDV.Text) / koefStopePDV;

            //    StavkaFakture.CenaBezPDV = Convert.ToDecimal(textCenaBezPDV.Text) / koefStopePDV;

            //    textCenaBezPDV.Text = (StavkaFakture.CenaBezPDV * koefStopePDV).ToString("N2");

            //    //MessageBox.Show("sa pdv-om");
            //}

            //// upisana cena je bez uračunatog pdv-a
            //if (checkBoxCenaSaPDV.Checked == false)
            //{

            //    textCenaBezPDV.Text = StavkaFakture.CenaBezPDV.ToString("N2");

            //    //MessageBox.Show("bez pdv-a");
            //}


            if (checkBoxCenaSaPDV.Checked == true)
            {
                textCenaBezPDV.Text = CenaSaPDVomTemp.ToString("N2");
            }
            else
            {
                textCenaBezPDV.Text = StavkaFakture.CenaBezPDV.ToString("N2");
            }


            NapraviPoreskuRekapitulaciju();
        }



        private void NapraviPoreskuRekapitulaciju()
        {

            /* KALKULACIJE */
            // vrednost bez pdv (cena bez pdv * količina)
            // iznos rabata ((cena bez pdv * kolicina) * (100 - rabatProc)/100)
            // osnovica za pdv ((cena bez pdv * količina) - rabat)
            // iznos pdv (((cena bez pdv * količina) - rabat) + stopa pdv) - ((cena bez pdv * količina) - rabat)
            // vrednost sa pdv (((cena bez pdv * količina) - rabat) + stopa pdv)


            // konverzija iz int u decimal zbog kalkulacije pdv-a  
            decimal stopaPDV = decimal.Zero;
            if (VrstaStavkeRacuna != null)
            {
                decimal _stopaPDV = VrstaStavkeRacuna.StopaPDV;
                stopaPDV = (_stopaPDV / 100);
            }



            textVrednostBezPDV.Text =
                (StavkaFakture.CenaBezPDV * StavkaFakture.Kolicina).ToString("N2");

            textIznosRabata.Text =
                ((StavkaFakture.CenaBezPDV * StavkaFakture.Kolicina) -
                ((StavkaFakture.CenaBezPDV * StavkaFakture.Kolicina) * (100 - StavkaFakture.Rabat) / 100)).ToString("N2");

            textPoreskaOsnovica.Text =
                ((StavkaFakture.CenaBezPDV * StavkaFakture.Kolicina * (100 - StavkaFakture.Rabat) / 100)).ToString("N2");

            StavkaFakture.StopaPDV = (int)stopaPDV;

            textIznosPDVa.Text =
               (((StavkaFakture.CenaBezPDV * StavkaFakture.Kolicina * ((100 - StavkaFakture.Rabat) / 100))) * stopaPDV).ToString("N2");


            textVrednostSaPDV.Text =
                 (((StavkaFakture.CenaBezPDV * StavkaFakture.Kolicina * (100 - StavkaFakture.Rabat) / 100)) +
                 ((((StavkaFakture.CenaBezPDV * StavkaFakture.Kolicina * (100 - StavkaFakture.Rabat) / 100)) * stopaPDV))).ToString("N2");


        }


        //public static string DoDecimalFormat(decimal myNumber)
        //{
        //    var s = string.Format("{0:0.00}", myNumber);

        //    return s;

        //    //if (s.EndsWith("00"))
        //    //{
        //    //    return ((int)myNumber).ToString();
        //    //}
        //    //else
        //    //{
        //    //    return s;
        //    //}
        //}


        private void ValidacijaUnosaDecimalnihBrojeva(object sender, KeyPressEventArgs e)
        {
            // dozvoljava samo unos brojeva i tačke i backspace
            // ascii codes
            // 46 .
            // 44 ,
            // 8 backspace

            TextBox _sender = (TextBox)sender;

            char ch = e.KeyChar;

            if (ch == 44 && _sender.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }

        }


        private void PuniComboBoxove(int _selectedIndex = -1)
        {

            using (FaktureModel db = new FaktureModel())
            {
                ListaVrstaStavkiRacuna = db.VrsteStavkiRacuna.ToList();
            }

            comboNazivStavke.DataSource = ListaVrstaStavkiRacuna;
            comboNazivStavke.DisplayMember = "NazivVrsteStavke";
            comboNazivStavke.ValueMember = "ID";
            comboNazivStavke.SelectedIndex = _selectedIndex; // default, ništa nije selektovano

        }


        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkNovaStavka_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StavkaFaktureDefForm stavkaFaktureDef = new StavkaFaktureDefForm(null);

            stavkaFaktureDef.ShowDialog();

            PuniComboBoxove();

            comboNazivStavke.SelectedValue = StavkaFaktureDefForm.novaVrstaStavkeRacunaId;

            // ponovno učitavanje stavki liste i selekcija na novom zapisu
            OsveziPrikazVrsteStavke(StavkaFaktureDefForm.novaVrstaStavkeRacunaId);


        }

        private void comboNazivStavke_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IdOdabraneVrsteStavkeFakture = (int)comboNazivStavke.SelectedValue;

            if (IdOdabraneVrsteStavkeFakture > 0)
            {
                OsveziPrikazVrsteStavke(IdOdabraneVrsteStavkeFakture);
            }
            else return;

        }



        private void OsveziPrikazVrsteStavke(int _idOdabraneVrsteStavkeFakture)
        {
            // osvežava se prikaz JM i poreske stope izabrane stavke 
            // na osnovu id-a odabrane stavke; ako je id = 0 onda ništa

            IdOdabraneVrsteStavkeFakture = _idOdabraneVrsteStavkeFakture;

            if (IdOdabraneVrsteStavkeFakture > 0)
            {
                textJedinicaMere.Text = ListaVrstaStavkiRacuna
                .Where(x => x.ID == IdOdabraneVrsteStavkeFakture)
                .Select(v => v.JedinicaMere)
                .SingleOrDefault();

                textStopaPDV.Text = ListaVrstaStavkiRacuna
                    .Where(x => x.ID == IdOdabraneVrsteStavkeFakture)
                    .Select(v => v.StopaPDV)
                    .SingleOrDefault()
                    .ToString();

                // izabrana stavka se dodeljuje propertiju VrstaStavkeRacuna odakle se uzima stopa PDV za kalkulacije
                VrstaStavkeRacuna = ListaVrstaStavkiRacuna
                    .Where(x => x.ID == IdOdabraneVrsteStavkeFakture)
                    .SingleOrDefault();

                // uključivanje kontrola za unos nakon izbora stavke
                textDodatniOpis.Enabled = true;
                textKolicina.Enabled = true;
                textCenaBezPDV.Enabled = true;
                checkBoxCenaSaPDV.Enabled = true;
                textRabat.Enabled = true;

                linkIzmeniStavku.Enabled = true;
                linkObrisiVrstuStavke.Enabled = true;

                KalkulacijaKoefStopePDVa();

                NapraviPoreskuRekapitulaciju();

                textDodatniOpis.Focus();
                textDodatniOpis.SelectAll();
            }
            else
            {
                // nijedna stavka nije odabrana
                textDodatniOpis.Enabled = false;
                textKolicina.Enabled = false;
                textCenaBezPDV.Enabled = false;
                checkBoxCenaSaPDV.Enabled = false;
                textRabat.Enabled = false;

                linkIzmeniStavku.Enabled = false;
                linkObrisiVrstuStavke.Enabled = false;
                return;
            }


        }


        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                SnimanjeStavkeFakture();
                Close();
            }
            else
            {
                MessageBox.Show("Morate popuniti obeležena polja.", "Greška kod unosa");
            }

        }

        private void SnimanjeStavkeFakture()
        {
            // NOVA STAVKA
            if (StavkaFakture.ID == 0)
            {
                using (FaktureModel db = new FaktureModel())
                {
                    StavkaFakture = Mapiraj_KontroleNaModel(StavkaFakture);

                    try
                    {
                        db.FaktureStavke.Add(StavkaFakture);
                        db.SaveChanges();

                        //MessageBox.Show("Stavka računa je snimljena.", "Snimanje podataka");
                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška prilikom snimanja podataka!", "Greška");
                        return;
                    }
                }
            }

            // POSTOJEĆA STAVKA
            if (StavkaFakture.ID > 0)
            {
                // 1. korak
                using (FaktureModel db = new FaktureModel())
                {
                    StavkaFakture = db.FaktureStavke
                        .Where(x => x.ID == StavkaFakture.ID)
                        .SingleOrDefault();
                }

                // 2. korak
                if (StavkaFakture != null)
                {
                    StavkaFakture = Mapiraj_KontroleNaModel(StavkaFakture);
                }
                else
                {
                    MessageBox.Show("Stavka ne postoji u bazi.", "Greška");
                    return;
                }

                // 3. korak
                using (FaktureModel db = new FaktureModel())
                {
                    try
                    {
                        db.Entry(StavkaFakture).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        //MessageBox.Show("Izmene su snimljene.", "Snimanje podataka");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška prilikom snimanja podataka!", "Greška");
                        return;
                    }
                }
            }


        }


        /* VALIDACIJA KONTROLA */
        private void comboNazivStavke_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(comboNazivStavke.SelectedIndex == -1))
            {
                cancel = false;
            }
            else
            {
                cancel = true;
                errorProviderStavkaFakture.SetError(comboNazivStavke, "Morate odabrati stavku fakture ili kreirati novu.");
            }
            e.Cancel = cancel;
        }

        private void comboNazivStavke_Validated(object sender, EventArgs e)
        {
            errorProviderStavkaFakture.SetError(comboNazivStavke, string.Empty);
        }

        private void textKolicina_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(textKolicina.Text == "0"))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderStavkaFakture.SetError(textKolicina, "Količina ne može biti nula.");
            }
            e.Cancel = cancel;
        }

        private void textKolicina_Validated(object sender, EventArgs e)
        {
            errorProviderStavkaFakture.SetError(textKolicina, string.Empty);
        }

        private void textCenaBezPDV_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (!(textKolicina.Text == "0"))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderStavkaFakture.SetError(textCenaBezPDV, "Cena ne može biti nula.");
            }
            e.Cancel = cancel;
        }

        private void textCenaBezPDV_Validated(object sender, EventArgs e)
        {
            errorProviderStavkaFakture.SetError(textCenaBezPDV, string.Empty);
        }

        private void textKolicina_Enter(object sender, EventArgs e)
        {
            textKolicina.SelectAll();
        }

        private void textCenaBezPDV_Enter(object sender, EventArgs e)
        {
            textCenaBezPDV.SelectAll();
        }

        private void textRabat_Enter(object sender, EventArgs e)
        {
            textRabat.SelectAll();
        }

        private void linkIzmeniStavku_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int odabranaStavkaId = (int)comboNazivStavke.SelectedValue;
            IdOdabraneVrsteStavkeFakture = odabranaStavkaId;

            if (IdOdabraneVrsteStavkeFakture > 0)
            {
                StavkaFaktureDefForm izmeniOdabranuStavku = new StavkaFaktureDefForm(odabranaStavkaId);
                izmeniOdabranuStavku.ShowDialog();

                PuniComboBoxove();

                comboNazivStavke.SelectedValue = odabranaStavkaId;

                // ponovno učitavanje stavki liste i selekcija na izmenjenom zapisu
                OsveziPrikazVrsteStavke(odabranaStavkaId);
            }
            else return;

        }

        private void linkObrisiVrstuStavke_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            IdOdabraneVrsteStavkeFakture = (int)comboNazivStavke.SelectedValue;
            if (IdOdabraneVrsteStavkeFakture > 0)
            {
                int result = ObrisiVrstuStavkeFakture(IdOdabraneVrsteStavkeFakture);

                if (result > 0)
                {
                    PuniComboBoxove();

                    OsveziPrikazVrsteStavke(0);
                }
                else return;
            }
            else return;


        }


        private int ObrisiVrstuStavkeFakture(int _vrstaStavkeId)
        {

            Model.VrsteStavkiRacuna vrstaStavkeZaBrisanje;

            int result = 0; // broj zapisa nad kojima je izvršena operacija


            using (FaktureModel db = new FaktureModel())
            {
                vrstaStavkeZaBrisanje = db.VrsteStavkiRacuna
                    .Where(x => x.ID == _vrstaStavkeId)
                    .SingleOrDefault();

                if (vrstaStavkeZaBrisanje != null)
                {
                    DialogResult dr =
                        MessageBox.Show("Odabrana vrsta stavke će biti obrisana!\r\nDa li želite da nastavite sa brisanjem?",
                        "Brisanje podataka", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            db.Entry(vrstaStavkeZaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                            result = db.SaveChanges();

                            if (result > 0)
                            {
                                MessageBox.Show("Podaci su uspešno obrisani.", "Brisanje podataka");
                                return result;
                            }
                            else return result;

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Greška prilikom brisanja podataka.", "Brisanje podataka");
                            return result;
                        }
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    MessageBox.Show("Greška prilikom brisanja podataka.", "Brisanje podataka");
                    return result;
                }
            }
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
        }


    }


}
