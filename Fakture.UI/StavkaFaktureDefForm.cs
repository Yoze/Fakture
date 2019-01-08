using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakture.Model;
using ControlDirtyTrackerWinforms;

namespace Fakture.UI
{
    public partial class StavkaFaktureDefForm : Form
    {

        public VrsteStavkiRacuna VrstaStavkeRacunaDef { get; set; }
        private int? vrstaStavkeRacunaId;

        private StartControlDirtyTracker _dirtyTracker;

        public static int novaVrstaStavkeRacunaId { get; set; } // id novog zapisa nakon snimanja

        public StavkaFaktureDefForm(int? _vrstaStavkeRacunaId)
        {
            InitializeComponent();

            // This is a handy trick to prevent implicit validation of our controls when they lose focus.
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;

            vrstaStavkeRacunaId = _vrstaStavkeRacunaId;
        }

        private void StavkaFaktureDefForm_Load(object sender, EventArgs e)
        {

            CreateEditVrstaStavkeFakture();

            _dirtyTracker = new StartControlDirtyTracker(this);
             
        }

        private void CreateEditVrstaStavkeFakture()
        {
            // NOVA VRSTA STAVKE
            if (vrstaStavkeRacunaId == null)
            {
                Model.VrsteStavkiRacuna novaVrstaStavkeRacuna = new VrsteStavkiRacuna();

                labelNaslov.Text = "Nova vrsta stavke računa";

                VrstaStavkeRacunaDef = novaVrstaStavkeRacuna;

                Mapiraj_ModelNaKontrole(VrstaStavkeRacunaDef);

            }

            // POSTOJEĆA VRSTA STAVKE
            else
            {
                labelNaslov.Text = "Izmena vrste stavke računa";

                using (FaktureModel db = new FaktureModel())
                {
                    var postojecaVrstaStavkeRacuna = db.VrsteStavkiRacuna
                        .Where(x => x.ID == vrstaStavkeRacunaId)
                        .SingleOrDefault();

                    if (postojecaVrstaStavkeRacuna == null)
                    {
                        MessageBox.Show("Vrsta stavke ne postoji u evidenciji.", "Greška");
                        Close();
                        return;
                    }

                    VrstaStavkeRacunaDef = postojecaVrstaStavkeRacuna;

                    Mapiraj_ModelNaKontrole(VrstaStavkeRacunaDef);
                }
            }

            textNazivUsluge.Focus();
            textNazivUsluge.SelectAll();

        }



        private void Mapiraj_ModelNaKontrole(VrsteStavkiRacuna _vrstaStavkeRacunaDef)
        {
            textVrstaStavkeId.Text = _vrstaStavkeRacunaDef.ID.ToString();
            textNazivUsluge.Text = _vrstaStavkeRacunaDef.NazivVrsteStavke;
            textJedinicaMere.Text = _vrstaStavkeRacunaDef.JedinicaMere;
            comboStopaPDV.SelectedItem = _vrstaStavkeRacunaDef.StopaPDV.ToString();

        }

        private VrsteStavkiRacuna Mapiraj_KontroleNaModel(VrsteStavkiRacuna _vrstaStavkeRacunaDef)
        {
            _vrstaStavkeRacunaDef.ID = Convert.ToInt32( textVrstaStavkeId.Text);
            _vrstaStavkeRacunaDef.NazivVrsteStavke = textNazivUsluge.Text;
            _vrstaStavkeRacunaDef.JedinicaMere = textJedinicaMere.Text;
            _vrstaStavkeRacunaDef.StopaPDV = Convert.ToInt32(comboStopaPDV.SelectedItem);

            return _vrstaStavkeRacunaDef;
        }


        private int SnimanjeVrsteStavkeFakture()
        {
            int rezultatSnimanja = 0;

            // NOVA VRSTA STAVKE
            if (VrstaStavkeRacunaDef.ID == 0)
            {
                using (FaktureModel db = new FaktureModel())
                {
                    VrstaStavkeRacunaDef = Mapiraj_KontroleNaModel(VrstaStavkeRacunaDef);

                    try
                    {
                        db.VrsteStavkiRacuna.Add(VrstaStavkeRacunaDef);
                        rezultatSnimanja = db.SaveChanges();

                        if (rezultatSnimanja > 0)
                        {
                            MessageBox.Show("Nova vrsta stavke je snimljena.", "Vrsta stavke računa");
                            novaVrstaStavkeRacunaId = VrstaStavkeRacunaDef.ID;
                            //_dirtyTracker.MarkAsClean();
                            Close();
                            return rezultatSnimanja;
                        }
                        else return rezultatSnimanja;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška prilikom snimanja podataka!", "Greška");
                        return rezultatSnimanja;
                    }
                }
            }


            // POSTOJEĆA VRSTA STAVKE - update postojećeg
            if (VrstaStavkeRacunaDef.ID > 0)
            {
                // 1. korak
                using (FaktureModel db = new FaktureModel())
                {
                    VrstaStavkeRacunaDef = db.VrsteStavkiRacuna
                        .Where(x => x.ID == VrstaStavkeRacunaDef.ID)
                        .SingleOrDefault();
                }

                // 2. korak
                if (VrstaStavkeRacunaDef != null)
                {
                    VrstaStavkeRacunaDef = Mapiraj_KontroleNaModel(VrstaStavkeRacunaDef);
                }
                else return rezultatSnimanja;


                // 3. korak
                using (FaktureModel db = new FaktureModel())
                {
                    try
                    {
                        db.Entry(VrstaStavkeRacunaDef).State = System.Data.Entity.EntityState.Modified;
                        rezultatSnimanja = db.SaveChanges();

                        if (rezultatSnimanja > 0)
                        {
                            MessageBox.Show("Izmene su snimljene.", "Snimanje podataka");                            
                            Close();
                            return rezultatSnimanja;
                        }
                        else return rezultatSnimanja;

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška prilikom snimanja podataka!", "Greška");
                        return rezultatSnimanja;
                    }
                }
            }
            else return rezultatSnimanja;
            
        }
          


        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /* VALIDACIJA KONTROLA  */
        private void textNazivUsluge_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textNazivUsluge.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderVrstaStavkeFak.SetError(textNazivUsluge, "Upisati naziv nove vrste stavke.");
            }
            e.Cancel = cancel;
        }

        private void textNazivUsluge_Validated(object sender, EventArgs e)
        {
            errorProviderVrstaStavkeFak.SetError(textNazivUsluge, string.Empty);
        }

        private void textJedinicaMere_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(textJedinicaMere.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderVrstaStavkeFak.SetError(textJedinicaMere, "Upisati jedinicu mere.");
            }
            e.Cancel = cancel;
        }

        private void textJedinicaMere_Validated(object sender, EventArgs e)
        {
            errorProviderVrstaStavkeFak.SetError(textJedinicaMere, string.Empty);
        }

        private void comboStopaPDV_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(comboStopaPDV.SelectedIndex == -1))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderVrstaStavkeFak.SetError(comboStopaPDV, "Odabrati poresku stopu.");
            }
            e.Cancel = cancel;
        }

        private void comboStopaPDV_Validated(object sender, EventArgs e)
        {
            errorProviderVrstaStavkeFak.SetError(comboStopaPDV, string.Empty);
        }

        private void buttonSnimi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {                
                SnimanjeVrsteStavkeFakture();                
            }
            else
            {
                MessageBox.Show("Morate popuniti obeležena polja.", "Greška kod unosa");
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



        private void StavkaFaktureDefForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_dirtyTracker.IsDirty)
            //{
            //    DialogResult dr = MessageBox.Show("Da li želite da snimite izmene?", "Snimanje izmena", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    switch (dr)
            //    {
            //        case DialogResult.Yes:
            //            if (ValidateChildren(ValidationConstraints.Enabled))
            //            {
            //                int result = SnimanjeVrsteStavkeFakture();
            //                if (result > 0)
            //                    _dirtyTracker.MarkAsClean();

            //                else
            //                    MessageBox.Show("Izmene nisu snimljene!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            else
            //            {
            //                MessageBox.Show("Morate popuniti obeležena polja.", "Greška kod unosa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            }
            //            break;
            //        case DialogResult.No:
            //            //_dirtyTracker.MarkAsClean();
            //            break;
            //    }
            //}
        }



    }
}
