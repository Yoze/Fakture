using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Fakture.Model;
using IspisBrojaSlovimaSR;
using System.Drawing.Printing;

namespace Fakture.UI
{
    public partial class StampanjeFakture : Form
    {

        private List<ListaStavkiFaktureView> ListaStavkiFakture { get; set; }
        private ListaFakturaView ZaglavljeFakture { get; set; } 

        private FirmePodaci IzdavaocFakture { get; set; }
        private FirmePodaci PrimalacFakture { get; set; }

        public decimal TotalZaUplatu { get; set; }

        private int fakturaId;

        public StampanjeFakture(int _fakturaId)
        {
            InitializeComponent();

            fakturaId = _fakturaId;
        }

       

        private void StampanjeFakture_Load(object sender, EventArgs e)
        {

            UcitajPodatkeFakture(fakturaId);

            // Faktura - zaglavlje, stavke, izdavaoc
            ListaFakturaViewBindingSource.DataSource = ZaglavljeFakture;
            ListaStavkiFaktureViewBindingSource.DataSource = ListaStavkiFakture;
            FirmePodaciBindingSource.DataSource = IzdavaocFakture;

            // Poreski rekapitular
            PoreskiRekapitularZaReport poreskiRekapitular = new PoreskiRekapitularZaReport(ListaStavkiFakture);
            PoreskiRekapitularZaReportBindingSource.DataSource = poreskiRekapitular;


            // Ispis totala slovima - izračunavanje ukupne sume za uplatu, 
            // rezultat se šalje kao argument za ispis broja slovima
            TotalZaUplatu = decimal.Zero;
            foreach (var item in ListaStavkiFakture)
            {
                TotalZaUplatu += item.VrednostSaPDV;
            }
            IspisBrojaSlovimaRSD brojSlovima = new IspisBrojaSlovimaRSD(TotalZaUplatu);
            IspisBrojaSlovimaRSDBindingSource.DataSource = brojSlovima;


            // default layout
            reportViewerFaktura.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewerFaktura.ZoomMode = ZoomMode.PageWidth;
            //reportViewerFaktura.ZoomMode = ZoomMode.Percent;
            //reportViewerFaktura.ZoomPercent = 150;
            reportViewerFaktura.PrinterSettings.Copies = 2;


            // ne diraj ovo
            reportViewerFaktura.RefreshReport();
                        
        }




        private void UcitajPodatkeFakture(int fakturaId)
        {
            using (FaktureModel db = new FaktureModel())
            {
                ZaglavljeFakture = db.ListaFakturaView
                    .Where(x => x.ID == fakturaId)
                    .SingleOrDefault();

                ListaStavkiFakture = db.ListaStavkiFaktureView
                    .Where(x => x.FakturaId == fakturaId)
                    .ToList();

                IzdavaocFakture = db.FirmePodaci
                    .Where(x => x.Kategorija == "P")
                    .SingleOrDefault();                
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
