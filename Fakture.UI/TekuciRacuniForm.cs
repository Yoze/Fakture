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
    public partial class TekuciRacuniForm : Form
    {

        private int? TekuciId;
        private int? KupacId;
        public FirmeTR TekuciRacun { get; set; }        


        public TekuciRacuniForm(int? _tekuciId, int? _kupacID)
        {
            InitializeComponent();

            // This is a handy trick to prevent implicit validation of our controls when they lose focus.
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            
            TekuciId = _tekuciId;
            KupacId = _kupacID;

        }


        private void TekuciRacuniForm_Load(object sender, EventArgs e)
        {

            if (TekuciId == null)
            {
                // novi TR
                FirmeTR noviTR = new FirmeTR() { FirmePodaciId = KupacId};

                TekuciRacun = noviTR;

                Mapiraj_ModelNaKontrole(TekuciRacun);
            }
            else
            {
                // izmena TR
                using (FaktureModel db = new FaktureModel())
                {
                    var postojeciTR = db.FirmeTR
                        .Where(x => x.ID == TekuciId)
                        .SingleOrDefault();
                    if (postojeciTR == null)
                    {
                        MessageBox.Show("Tekući račun ne postoji u evidenciji","Greška");
                        Close();
                        return;
                    }
                    TekuciRacun = postojeciTR;                    
                }
                Mapiraj_ModelNaKontrole(TekuciRacun);
            }
        }



        private void Mapiraj_ModelNaKontrole(FirmeTR _tekuciRacun)
        {
            textTRId.Text = _tekuciRacun.ID.ToString();
            textKupacId.Text = _tekuciRacun.FirmePodaciId.ToString();
            textBrojTR.Text = _tekuciRacun.BrojTR;
            textBanka.Text = _tekuciRacun.NazivBanke;
            // check podrazumevani tr
            // text beleska, ako treba

        }

        private FirmeTR Mapiraj_KontroleNaModel(FirmeTR _tekuciRacun)
        {
            _tekuciRacun.ID = Convert.ToInt32( textTRId.Text);
            _tekuciRacun.FirmePodaciId = Convert.ToInt32(textKupacId.Text);
            _tekuciRacun.BrojTR = textBrojTR.Text;
            _tekuciRacun.NazivBanke = textBanka.Text;
            _tekuciRacun.Podrazumevani = false;
            _tekuciRacun.Beleska = string.Empty;

            return _tekuciRacun;
        }

        private void SnimanjePodatakaTR()
        {
            // NOVI TR - dodavanj novog
            if (TekuciRacun.ID == 0)
            {
                using (FaktureModel db = new FaktureModel())
                {
                    // postojeće podatke o kupcu iz propertija TekuciRacun update-ujem podacima iz kontrola 
                    TekuciRacun = Mapiraj_KontroleNaModel(TekuciRacun);

                    try
                    {
                        db.FirmeTR.Add(TekuciRacun);
                        db.SaveChanges();
                        MessageBox.Show("Podaci o tekućem računu su snimljeni.","Tekući račun");
                        Close();
                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška prilikom snimanja podataka!", "Greška");
                        return;
                    }
                }
            }


            // POSTOJEĆI TR - update postojećeg
            if (TekuciRacun.ID > 0)
            {
                // 1. korak
                using (FaktureModel db = new FaktureModel())
                {
                    TekuciRacun = db.FirmeTR
                        .Where(x => x.ID == TekuciRacun.ID)
                        .SingleOrDefault();
                }

                // 2.korak
                if (TekuciRacun != null)
                {
                    // postojeće podatke o kupcu iz propertija TekuciRacun update-ujem podacima iz kontrola
                    TekuciRacun = Mapiraj_KontroleNaModel(TekuciRacun);
                }

                //3.korak
                using (FaktureModel db = new FaktureModel())
                {
                    try
                    {
                        db.Entry(TekuciRacun).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show("Izmene su snimljene.", "Snimanje podataka");
                        Close();
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


        private void ValidacijaUnosaBrojaTR(object sender, KeyPressEventArgs e)
        {
            // dozvoljava samo unos brojeva i crte i backspace
            // ascii codes
            // 46 .
            // 44 ,
            // 8 backspace
            // 45 -

            TextBox _sender = (TextBox)sender;

            char ch = e.KeyChar;

            //if (ch == 45 && _sender.Text.IndexOf('-') != -1)
            //{
            //    e.Handled = true;
            //    return;
            //}

            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }


        }


        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                SnimanjePodatakaTR(); 
                Close();
            }
            else
            {
                MessageBox.Show("Morate popuniti obeležena polja.", "Greška kod unosa");
            }
            
        }

        private void textBrojTR_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace( textBrojTR.Text)))
            {
                cancel = false;
            }
            else
            {
                cancel = true;
                errorProviderTR.SetError(textBrojTR, "Upišite broj TR.");
            }
            e.Cancel = cancel;
        }

        private void textBrojTR_Validated(object sender, EventArgs e)
        {
            errorProviderTR.SetError(textBrojTR, string.Empty);
        }

        private void textBanka_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textBanka.Text)))
            {
                cancel = false;
            }
            else
            {
                cancel = true;
                errorProviderTR.SetError(textBanka, "Upišite naziv banke.");
            }
            e.Cancel = cancel;
        }

        private void textBanka_Validated(object sender, EventArgs e)
        {
            errorProviderTR.SetError(textBanka, string.Empty);
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
