namespace Fakture.UI
{
    partial class StampanjeFakture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ListaStavkiFaktureViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ListaFakturaViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FirmePodaciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PoreskiRekapitularZaReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IspisBrojaSlovimaRSDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewerFaktura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNaslovnaLinija = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ListaStavkiFaktureViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaFakturaViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmePodaciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PoreskiRekapitularZaReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IspisBrojaSlovimaRSDBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaStavkiFaktureViewBindingSource
            // 
            this.ListaStavkiFaktureViewBindingSource.DataSource = typeof(Fakture.Model.ListaStavkiFaktureView);
            // 
            // ListaFakturaViewBindingSource
            // 
            this.ListaFakturaViewBindingSource.DataSource = typeof(Fakture.Model.ListaFakturaView);
            // 
            // FirmePodaciBindingSource
            // 
            this.FirmePodaciBindingSource.DataSource = typeof(Fakture.Model.FirmePodaci);
            // 
            // PoreskiRekapitularZaReportBindingSource
            // 
            this.PoreskiRekapitularZaReportBindingSource.DataSource = typeof(Fakture.Model.PoreskiRekapitularZaReport);
            // 
            // IspisBrojaSlovimaRSDBindingSource
            // 
            this.IspisBrojaSlovimaRSDBindingSource.DataSource = typeof(IspisBrojaSlovimaSR.IspisBrojaSlovimaRSD);
            // 
            // reportViewerFaktura
            // 
            this.reportViewerFaktura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerFaktura.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource1.Name = "StavkeFaktureDSet";
            reportDataSource1.Value = this.ListaStavkiFaktureViewBindingSource;
            reportDataSource2.Name = "ZaglavljeDSet";
            reportDataSource2.Value = this.ListaFakturaViewBindingSource;
            reportDataSource3.Name = "IzdavaocFaktureDSet";
            reportDataSource3.Value = this.FirmePodaciBindingSource;
            reportDataSource4.Name = "PoreskaRekapitulacijaDSet";
            reportDataSource4.Value = this.PoreskiRekapitularZaReportBindingSource;
            reportDataSource5.Name = "BrojSlovimaDSet";
            reportDataSource5.Value = this.IspisBrojaSlovimaRSDBindingSource;
            this.reportViewerFaktura.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerFaktura.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerFaktura.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewerFaktura.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewerFaktura.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewerFaktura.LocalReport.DisplayName = "Faktura";
            this.reportViewerFaktura.LocalReport.ReportEmbeddedResource = "Fakture.UI.FakturaPrint.rdlc";
            this.reportViewerFaktura.Location = new System.Drawing.Point(20, 80);
            this.reportViewerFaktura.Margin = new System.Windows.Forms.Padding(20);
            this.reportViewerFaktura.Name = "reportViewerFaktura";
            this.reportViewerFaktura.ShowBackButton = false;
            this.reportViewerFaktura.ShowContextMenu = false;
            this.reportViewerFaktura.ShowDocumentMapButton = false;
            this.reportViewerFaktura.ShowExportButton = false;
            this.reportViewerFaktura.ShowFindControls = false;
            this.reportViewerFaktura.ShowPromptAreaButton = false;
            this.reportViewerFaktura.ShowRefreshButton = false;
            this.reportViewerFaktura.Size = new System.Drawing.Size(932, 649);
            this.reportViewerFaktura.TabIndex = 0;
            this.reportViewerFaktura.WaitControlDisplayAfter = 250;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.reportViewerFaktura, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(972, 749);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.labelNaslovnaLinija);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 40);
            this.panel1.TabIndex = 3;
            // 
            // labelNaslovnaLinija
            // 
            this.labelNaslovnaLinija.AutoSize = true;
            this.labelNaslovnaLinija.BackColor = System.Drawing.Color.Transparent;
            this.labelNaslovnaLinija.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNaslovnaLinija.ForeColor = System.Drawing.Color.White;
            this.labelNaslovnaLinija.Location = new System.Drawing.Point(5, 5);
            this.labelNaslovnaLinija.Margin = new System.Windows.Forms.Padding(5);
            this.labelNaslovnaLinija.Name = "labelNaslovnaLinija";
            this.labelNaslovnaLinija.Size = new System.Drawing.Size(179, 30);
            this.labelNaslovnaLinija.TabIndex = 0;
            this.labelNaslovnaLinija.Text = "Štampanje računa";
            this.labelNaslovnaLinija.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelNaslovnaLinija.UseMnemonic = false;
            // 
            // StampanjeFakture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "StampanjeFakture";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faktura";
            this.Load += new System.EventHandler(this.StampanjeFakture_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            ((System.ComponentModel.ISupportInitialize)(this.ListaStavkiFaktureViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaFakturaViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmePodaciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PoreskiRekapitularZaReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IspisBrojaSlovimaRSDBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerFaktura;
        private System.Windows.Forms.BindingSource ListaStavkiFaktureViewBindingSource;
        private System.Windows.Forms.BindingSource ListaFakturaViewBindingSource;
        private System.Windows.Forms.BindingSource FirmePodaciBindingSource;
        private System.Windows.Forms.BindingSource PoreskiRekapitularZaReportBindingSource;
        private System.Windows.Forms.BindingSource IspisBrojaSlovimaRSDBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNaslovnaLinija;
    }
}