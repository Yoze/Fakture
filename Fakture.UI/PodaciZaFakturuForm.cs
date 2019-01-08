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
    public partial class PodaciZaFakturuForm : Form
    {
        private int? kupacId;
        public static int KupacId_ZaOstaleForme { get; set; }
        public FirmePodaci PodaciOKupcu { get; set; } // ovde se nalazi novi odn. postojeći kupac

        public PodaciZaFakturuForm(int? _kupacId)
        {
            InitializeComponent();

            // This is a handy trick to prevent implicit validation of our controls when they lose focus.
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;

            kupacId = _kupacId;
        }


        private void PodaciZaFakturuForm_Load(object sender, EventArgs e)
        {
            /* 
             - Na osnovu kupacId kreira se novi ili traži postojeći zapis.
             - PodaciOKupcu sadrže podatak o postojećem ili novom kupcu
             - Mapiraj_ModelNaKontrole ispisuje podatke na formi o novom/postojećem zapisu.
             - Mapiraj_KontroleNaModel kao argument dobija novi/postojeći zapis
             i update-uje ga podacima iz kontrola na formi.
             - SnimanjePodataka na osnovu PodaciOKupcu vrši upis novog ili update zapisa
             */

            if (kupacId == null)
            {
                FirmePodaci noviKupac = new FirmePodaci() { Kategorija = "K" }; // K - kupac
                Text = "Podaci o kupcu";
                labelNaslov.Text = "Unos podataka";
                checObveznikPdv.Visible = false;
                labelPDVNapomena.Visible = false;
                linkDodajTR.Enabled = false;
                contextListaTR.Enabled = false;

                PodaciOKupcu = noviKupac;

                Mapiraj_ModelNaKontrole(PodaciOKupcu);
            }
            else
            {
                Text = "Podaci o kupcu";
                labelNaslov.Text = "Izmena podataka";
                checObveznikPdv.Visible = false;
                labelPDVNapomena.Visible = false;

                using (FaktureModel db = new FaktureModel())
                {
                    var postojeciKupac = db.FirmePodaci
                        .Where(x => x.Id == kupacId)
                        .SingleOrDefault();

                    if (postojeciKupac == null)
                    {
                        MessageBox.Show("Kupac ne postoji u evidenciji.", "Greška");
                        Close();
                        return;
                    }

                    if (postojeciKupac.Kategorija == "P") // P - prodavac
                    {
                        Text = "Izdavaoc fakture";
                        labelNaslov.Text = "Podaci o izdavaocu fakture";
                        checObveznikPdv.Visible = true;
                        labelPDVNapomena.Visible = true;
                        groupTR.Visible = true;
                    }

                    PodaciOKupcu = postojeciKupac;

                    Mapiraj_ModelNaKontrole(PodaciOKupcu);
                }
            }

            GetListaTekucihRacuna(PodaciOKupcu.Id);

            textNazivPrviRed.Focus();
            textNazivPrviRed.SelectAll();


        }


        private void Mapiraj_ModelNaKontrole(FirmePodaci _podaciOKupcu)
        {
            // ispis podataka u kontrole

            textKorisnikId.Text = _podaciOKupcu.Id.ToString();
            textNazivPrviRed.Text = _podaciOKupcu.NazivPrviRed;
            textNazivDrugiRed.Text = _podaciOKupcu.NazivDrugiRed;
            textAdresa.Text = _podaciOKupcu.Adresa;
            textPostanskiBroj.Text = _podaciOKupcu.PostBroj;
            textMesto.Text = _podaciOKupcu.Mesto;
            textTelefon.Text = _podaciOKupcu.Telefon;
            textFax.Text = _podaciOKupcu.Fax;
            textEmail.Text = _podaciOKupcu.Email;
            textPIB.Text = _podaciOKupcu.PIB;
            textMB.Text = _podaciOKupcu.MB;
            checObveznikPdv.Checked = _podaciOKupcu.ObveznikPDV;
            textBeleska.Text = _podaciOKupcu.Beleska;
            textKategorija.Text = _podaciOKupcu.Kategorija;
        }

        private FirmePodaci Mapiraj_KontroleNaModel(FirmePodaci _podaciOKupcu)
        {
            // podaci iz kontrola u model

            _podaciOKupcu.Id = Convert.ToInt32(textKorisnikId.Text);
            _podaciOKupcu.NazivPrviRed = textNazivPrviRed.Text;
            _podaciOKupcu.NazivDrugiRed = textNazivDrugiRed.Text;
            _podaciOKupcu.Adresa = textAdresa.Text;
            _podaciOKupcu.PostBroj = textPostanskiBroj.Text;
            _podaciOKupcu.Mesto = textMesto.Text;
            _podaciOKupcu.Telefon = textTelefon.Text;
            _podaciOKupcu.Fax = textFax.Text;
            _podaciOKupcu.Email = textEmail.Text;
            _podaciOKupcu.PIB = textPIB.Text;
            _podaciOKupcu.MB = textMB.Text;
            _podaciOKupcu.ObveznikPDV = checObveznikPdv.Checked;
            _podaciOKupcu.Beleska = textBeleska.Text;
            _podaciOKupcu.Kategorija = textKategorija.Text;

            return _podaciOKupcu;

        }


        private void SnimanjePodataka()
        {
            // NOVI KUPAC - snimanje novog
            if (PodaciOKupcu.Id == 0)
            {

                using (FaktureModel db = new FaktureModel())
                {
                    // postojeće podatke o kupcu iz propertija PodaciOKupcu update-ujem podacima iz kontrola 
                    PodaciOKupcu = Mapiraj_KontroleNaModel(PodaciOKupcu);

                    try
                    {
                        db.FirmePodaci.Add(PodaciOKupcu);
                        db.SaveChanges();

                        MessageBox.Show("Novi kupac je snimljen u evidenciju.", "Snimanje podataka");
                        linkDodajTR.Enabled = true;
                        KupacId_ZaOstaleForme = PodaciOKupcu.Id;

                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška prilikom snimanja podataka!", "Greška");
                        return;
                    }
                }
            }

            // POSTOJEĆI KUPAC - update postojećeg
            if (PodaciOKupcu.Id > 0)
            {
                //MessageBox.Show("id > 0  " + PodaciOKupcu.Id);               

                // 1. korak
                using (FaktureModel db = new FaktureModel())
                {
                    PodaciOKupcu = db.FirmePodaci
                        .Where(x => x.Id == PodaciOKupcu.Id)
                        .SingleOrDefault();
                }

                // 2. korak
                if (PodaciOKupcu != null)
                {
                    // postojeće podatke o kupcu iz propertija PodaciOKupcu update-ujem podacima iz kontrola
                    PodaciOKupcu = Mapiraj_KontroleNaModel(PodaciOKupcu);
                }
                else
                {
                    MessageBox.Show("Kupac ne postoji u bazi.", "Greška");
                    return;
                }

                // 3. korak
                using (FaktureModel db = new FaktureModel())
                {
                    try
                    {
                        db.Entry(PodaciOKupcu).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        KupacId_ZaOstaleForme = PodaciOKupcu.Id;
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


        private void ValidacijaUnosaBrojeva(object sender, KeyPressEventArgs e)
        {
            // dozvoljava samo unos brojeva i backspace
            // ascii codes
            // 46 .
            // 44 ,
            // 8 backspace

            TextBox _sender = (TextBox)sender;

            char ch = e.KeyChar;

            //if (ch == 44 && _sender.Text.IndexOf(',') != -1)
            //{
            //    e.Handled = true;
            //    return;
            //}

            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }

        }



        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkTR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TekuciRacuniForm noviTekuciRacun = new TekuciRacuniForm(null, PodaciOKupcu.Id);
            noviTekuciRacun.ShowDialog();

            GetListaTekucihRacuna(PodaciOKupcu.Id);
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            // VALIDACIJA
            // 1. u konstruktor posle InitializeComponent() obavezno treba dodati AutoValidate = Disable
            // 2. pre snimanja ide if uslov ispod

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                SnimanjePodataka();
                Close();
            }
            else
            {
                MessageBox.Show("Morate popuniti obeležena polja.", "Greška kod unosa");
            }
            
        }



        // TEKUĆI RAČUNI
        private void GetListaTekucihRacuna(int? kupacId)
        {
            using (FaktureModel db = new FaktureModel())
            {
                List<ListaZaPrikazTR> listaTRPrikaz = new List<ListaZaPrikazTR>();

                var listaTR = db.FirmeTR
                    .Where(x => x.FirmePodaciId == kupacId)
                    .ToList();

                foreach (var item in listaTR)
                {
                    ListaZaPrikazTR trItem = new ListaZaPrikazTR()
                    {
                        ID = item.ID,
                        BrojNazivBanke = item.BrojTR + "  " + item.NazivBanke
                    };
                    listaTRPrikaz.Add(trItem);
                }

                listBoxTekucRacuni.DataSource = listaTRPrikaz;
                listBoxTekucRacuni.DisplayMember = "BrojNazivBanke";
                listBoxTekucRacuni.ValueMember = "ID";

                // kontekstni meni
                contextListaTR.Enabled = true;
            }

        }



        private void izmeniTRToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ListaZaPrikazTR izabraniTR = (ListaZaPrikazTR)listBoxTekucRacuni.SelectedItem;
            TekuciRacuniForm izmeniTR = new TekuciRacuniForm(izabraniTR.ID, PodaciOKupcu.Id);
            izmeniTR.ShowDialog();

            GetListaTekucihRacuna(PodaciOKupcu.Id);
        }


        private void obrišiTRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaZaPrikazTR izabraniTR = (ListaZaPrikazTR)listBoxTekucRacuni.SelectedItem;

            BrisanjeTR(izabraniTR.ID);
            GetListaTekucihRacuna(PodaciOKupcu.Id);
        }


        private void BrisanjeTR(int? _tekuciRacunId)
        {
            FirmeTR tekuciRacunZaBrisanje;

            using (FaktureModel db = new FaktureModel())
            {
                tekuciRacunZaBrisanje = db.FirmeTR
                    .Where(x => x.ID == _tekuciRacunId)
                    .First();

                if (tekuciRacunZaBrisanje != null)
                {
                    DialogResult dr =
                        MessageBox.Show("Odabrani tekući račun će biti obrisan!\r\nDa li želite da nastavite?", "Brisanje TR", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            db.Entry(tekuciRacunZaBrisanje).State = System.Data.Entity.EntityState.Deleted;
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
                    return;
                }
            }

        }


        /*  V A L I D A C I J A */
        private void textNazivPrviRed_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textNazivPrviRed.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderKupci.SetError(textNazivPrviRed, "Obavezan podatak! Morate upisati naziv.");
            }
            e.Cancel = cancel;
        }

        private void textNazivPrviRed_Validated(object sender, EventArgs e)
        {
            errorProviderKupci.SetError(textNazivPrviRed, string.Empty);
        }

        private void textAdresa_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textAdresa.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderKupci.SetError(textAdresa, "Obavezan podatak! Morate upisati adresu.");
            }
            e.Cancel = cancel;
        }

        private void textAdresa_Validated(object sender, EventArgs e)
        {
            errorProviderKupci.SetError(textAdresa, string.Empty);
        }

        private void textMesto_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textMesto.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderKupci.SetError(textMesto, "Obavezan podatak! Morate upisati mesto.");
            }
            e.Cancel = cancel;
        }

        private void textMesto_Validated(object sender, EventArgs e)
        {
            errorProviderKupci.SetError(textMesto, string.Empty);
        }

        private void textPIB_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textPIB.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderKupci.SetError(textPIB, "Obavezan podatak! Morate upisati PIB.");
            }
            e.Cancel = cancel;
        }

        private void textPIB_Validated(object sender, EventArgs e)
        {
            errorProviderKupci.SetError(textPIB, string.Empty);
        }

        private void listBoxTekucRacuni_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (PodaciOKupcu.Kategorija == "P")
            {
                if (!(listBoxTekucRacuni.Items.Count == 0))
                {
                    // prolazi validaciju
                    cancel = false;
                }
                else
                {
                    // ne prolazi validaciju
                    cancel = true;
                    errorProviderKupci.SetError(listBoxTekucRacuni, "Obavezan podatak! Morate upisati tekući račun.");
                }
                e.Cancel = cancel;
            }
            else return;
            
        }

        private void listBoxTekucRacuni_Validated(object sender, EventArgs e)
        {
            errorProviderKupci.SetError(listBoxTekucRacuni, string.Empty);
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





    class ListaZaPrikazTR
    {
        // prikaz broja TR i banke u listBox kontroli
        public int ID { get; set; }
        public string BrojNazivBanke { get; set; }

    }
}
