using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakture.Model;
using System.Configuration;


namespace Fakture.UI
{
    public partial class OdabirKorisnikaForm : Form
    {
        public OdabirKorisnikaForm()
        {
            InitializeComponent();
        }

        /* Na osnovu odabranog korisnika bira se konkcioni string
         koji se piše u globalnu varijablu OdabraniKonekcioniString 
         Ime konekcionog stringa: FaktureConn_imebaze  */

        private void btnMilan_Click(object sender, EventArgs e)
        {
            AktivniKonekcioniString.OdabraniKonekcioniString =
                ConfigurationManager.ConnectionStrings["FaktureConnMilan"].ConnectionString;

            lblConn.Text = AktivniKonekcioniString.OdabraniKonekcioniString;

            MainWindow main = new MainWindow();
            main.ShowDialog();      
                  
            
        }

        private void btnDamir_Click(object sender, EventArgs e)
        {
            AktivniKonekcioniString.OdabraniKonekcioniString =
                ConfigurationManager.ConnectionStrings["FaktureConnDamir"].ConnectionString;

            lblConn.Text = AktivniKonekcioniString.OdabraniKonekcioniString;

            MainWindow main = new MainWindow();
            main.ShowDialog();
        }

        private void btnBata_Click(object sender, EventArgs e)
        {
            AktivniKonekcioniString.OdabraniKonekcioniString =
               ConfigurationManager.ConnectionStrings["FaktureConnBata"].ConnectionString;

            lblConn.Text = AktivniKonekcioniString.OdabraniKonekcioniString;

            MainWindow main = new MainWindow();
            main.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
