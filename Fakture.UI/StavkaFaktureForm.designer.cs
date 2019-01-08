namespace Fakture.UI
{
    partial class StavkaFaktureForm
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
            this.labelVrstaUsluge = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboNazivStavke = new System.Windows.Forms.ComboBox();
            this.textKolicina = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBoxCenaSaPDV = new System.Windows.Forms.CheckBox();
            this.textCenaBezPDV = new System.Windows.Forms.TextBox();
            this.textRabat = new System.Windows.Forms.TextBox();
            this.textStopaPDV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.linkNovaStavka = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNaslov = new System.Windows.Forms.Label();
            this.textJedinicaMere = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textDodatniOpis = new System.Windows.Forms.TextBox();
            this.linkIzmeniStavku = new System.Windows.Forms.LinkLabel();
            this.textVrednostBezPDV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textIznosRabata = new System.Windows.Forms.TextBox();
            this.textPoreskaOsnovica = new System.Windows.Forms.TextBox();
            this.textVrednostSaPDV = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textIznosPDVa = new System.Windows.Forms.TextBox();
            this.textFakturaId = new System.Windows.Forms.TextBox();
            this.textStavkaID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.errorProviderStavkaFakture = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkObrisiVrstuStavke = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderStavkaFakture)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVrstaUsluge
            // 
            this.labelVrstaUsluge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVrstaUsluge.AutoSize = true;
            this.labelVrstaUsluge.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVrstaUsluge.ForeColor = System.Drawing.Color.DimGray;
            this.labelVrstaUsluge.Location = new System.Drawing.Point(22, 151);
            this.labelVrstaUsluge.Name = "labelVrstaUsluge";
            this.labelVrstaUsluge.Size = new System.Drawing.Size(80, 17);
            this.labelVrstaUsluge.TabIndex = 18;
            this.labelVrstaUsluge.Text = "Vrsta usluge";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(422, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Količina";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(315, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Jed. mere";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(182, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Rabat %";
            // 
            // comboNazivStavke
            // 
            this.comboNazivStavke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNazivStavke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboNazivStavke.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboNazivStavke.FormattingEnabled = true;
            this.comboNazivStavke.Location = new System.Drawing.Point(25, 125);
            this.comboNazivStavke.Name = "comboNazivStavke";
            this.comboNazivStavke.Size = new System.Drawing.Size(261, 28);
            this.comboNazivStavke.TabIndex = 1;
            this.comboNazivStavke.SelectionChangeCommitted += new System.EventHandler(this.comboNazivStavke_SelectionChangeCommitted);
            this.comboNazivStavke.Validating += new System.ComponentModel.CancelEventHandler(this.comboNazivStavke_Validating);
            this.comboNazivStavke.Validated += new System.EventHandler(this.comboNazivStavke_Validated);
            // 
            // textKolicina
            // 
            this.textKolicina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textKolicina.Enabled = false;
            this.textKolicina.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textKolicina.Location = new System.Drawing.Point(402, 125);
            this.textKolicina.Name = "textKolicina";
            this.textKolicina.Size = new System.Drawing.Size(93, 27);
            this.textKolicina.TabIndex = 3;
            this.textKolicina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textKolicina.Enter += new System.EventHandler(this.textKolicina_Enter);
            this.textKolicina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidacijaUnosaDecimalnihBrojeva);
            this.textKolicina.Leave += new System.EventHandler(this.ConvertTextToDecimal);
            this.textKolicina.Validating += new System.ComponentModel.CancelEventHandler(this.textKolicina_Validating);
            this.textKolicina.Validated += new System.EventHandler(this.textKolicina_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.checkBoxCenaSaPDV);
            this.groupBox1.Controls.Add(this.textCenaBezPDV);
            this.groupBox1.Controls.Add(this.textRabat);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textStopaPDV);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox1.Location = new System.Drawing.Point(501, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 108);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cena po jedinici";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(37, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 17);
            this.label14.TabIndex = 23;
            this.label14.Text = "Cena";
            // 
            // checkBoxCenaSaPDV
            // 
            this.checkBoxCenaSaPDV.AutoSize = true;
            this.checkBoxCenaSaPDV.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBoxCenaSaPDV.Enabled = false;
            this.checkBoxCenaSaPDV.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.checkBoxCenaSaPDV.FlatAppearance.BorderSize = 2;
            this.checkBoxCenaSaPDV.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.checkBoxCenaSaPDV.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCenaSaPDV.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxCenaSaPDV.Location = new System.Drawing.Point(117, 22);
            this.checkBoxCenaSaPDV.Name = "checkBoxCenaSaPDV";
            this.checkBoxCenaSaPDV.Size = new System.Drawing.Size(55, 52);
            this.checkBoxCenaSaPDV.TabIndex = 23;
            this.checkBoxCenaSaPDV.Text = "Cena je\r\nsa PDV";
            this.checkBoxCenaSaPDV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxCenaSaPDV.UseVisualStyleBackColor = true;
            this.checkBoxCenaSaPDV.CheckedChanged += new System.EventHandler(this.checkBoxCenaSaPDV_CheckedChanged);
            // 
            // textCenaBezPDV
            // 
            this.textCenaBezPDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCenaBezPDV.Enabled = false;
            this.textCenaBezPDV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCenaBezPDV.ForeColor = System.Drawing.Color.Black;
            this.textCenaBezPDV.Location = new System.Drawing.Point(10, 53);
            this.textCenaBezPDV.Name = "textCenaBezPDV";
            this.textCenaBezPDV.Size = new System.Drawing.Size(93, 27);
            this.textCenaBezPDV.TabIndex = 0;
            this.textCenaBezPDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textCenaBezPDV.Enter += new System.EventHandler(this.textCenaBezPDV_Enter);
            this.textCenaBezPDV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidacijaUnosaDecimalnihBrojeva);
            this.textCenaBezPDV.Leave += new System.EventHandler(this.ConvertTextToDecimal);
            this.textCenaBezPDV.Validating += new System.ComponentModel.CancelEventHandler(this.textCenaBezPDV_Validating);
            this.textCenaBezPDV.Validated += new System.EventHandler(this.textCenaBezPDV_Validated);
            // 
            // textRabat
            // 
            this.textRabat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRabat.Enabled = false;
            this.textRabat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRabat.Location = new System.Drawing.Point(183, 54);
            this.textRabat.Name = "textRabat";
            this.textRabat.Size = new System.Drawing.Size(52, 27);
            this.textRabat.TabIndex = 1;
            this.textRabat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textRabat.Enter += new System.EventHandler(this.textRabat_Enter);
            this.textRabat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidacijaUnosaDecimalnihBrojeva);
            this.textRabat.Leave += new System.EventHandler(this.ConvertTextToDecimal);
            // 
            // textStopaPDV
            // 
            this.textStopaPDV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textStopaPDV.Enabled = false;
            this.textStopaPDV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textStopaPDV.Location = new System.Drawing.Point(253, 57);
            this.textStopaPDV.Name = "textStopaPDV";
            this.textStopaPDV.ReadOnly = true;
            this.textStopaPDV.Size = new System.Drawing.Size(48, 20);
            this.textStopaPDV.TabIndex = 6;
            this.textStopaPDV.TabStop = false;
            this.textStopaPDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(308, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(256, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 34);
            this.label5.TabIndex = 5;
            this.label5.Text = "Stopa\r\nPDV";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodaj.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.ForeColor = System.Drawing.Color.White;
            this.btnDodaj.Location = new System.Drawing.Point(785, 448);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 27);
            this.btnDodaj.TabIndex = 8;
            this.btnDodaj.Text = "SNIMI";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdustani.Location = new System.Drawing.Point(689, 448);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(90, 27);
            this.btnOdustani.TabIndex = 9;
            this.btnOdustani.Text = "ODUSTANI";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // linkNovaStavka
            // 
            this.linkNovaStavka.AutoSize = true;
            this.linkNovaStavka.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkNovaStavka.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkNovaStavka.Location = new System.Drawing.Point(22, 222);
            this.linkNovaStavka.Name = "linkNovaStavka";
            this.linkNovaStavka.Size = new System.Drawing.Size(113, 17);
            this.linkNovaStavka.TabIndex = 16;
            this.linkNovaStavka.TabStop = true;
            this.linkNovaStavka.Text = "Nova vrsta usluge";
            this.linkNovaStavka.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNovaStavka_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Fakture.UI.Properties.Resources.Background;
            this.panel1.Controls.Add(this.labelNaslov);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 50);
            this.panel1.TabIndex = 0;
            // 
            // labelNaslov
            // 
            this.labelNaslov.AutoSize = true;
            this.labelNaslov.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNaslov.ForeColor = System.Drawing.Color.Navy;
            this.labelNaslov.Location = new System.Drawing.Point(20, 15);
            this.labelNaslov.Name = "labelNaslov";
            this.labelNaslov.Size = new System.Drawing.Size(137, 25);
            this.labelNaslov.TabIndex = 0;
            this.labelNaslov.Text = "Stavka računa";
            // 
            // textJedinicaMere
            // 
            this.textJedinicaMere.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textJedinicaMere.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textJedinicaMere.Location = new System.Drawing.Point(315, 128);
            this.textJedinicaMere.MaxLength = 10;
            this.textJedinicaMere.Name = "textJedinicaMere";
            this.textJedinicaMere.ReadOnly = true;
            this.textJedinicaMere.Size = new System.Drawing.Size(67, 20);
            this.textJedinicaMere.TabIndex = 19;
            this.textJedinicaMere.TabStop = false;
            this.textJedinicaMere.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(22, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Dodatni opis vrste usluge";
            // 
            // textDodatniOpis
            // 
            this.textDodatniOpis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDodatniOpis.Enabled = false;
            this.textDodatniOpis.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDodatniOpis.Location = new System.Drawing.Point(25, 173);
            this.textDodatniOpis.MaxLength = 255;
            this.textDodatniOpis.Name = "textDodatniOpis";
            this.textDodatniOpis.Size = new System.Drawing.Size(261, 27);
            this.textDodatniOpis.TabIndex = 2;
            // 
            // linkIzmeniStavku
            // 
            this.linkIzmeniStavku.AutoSize = true;
            this.linkIzmeniStavku.Enabled = false;
            this.linkIzmeniStavku.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkIzmeniStavku.LinkColor = System.Drawing.Color.Black;
            this.linkIzmeniStavku.Location = new System.Drawing.Point(22, 251);
            this.linkIzmeniStavku.Name = "linkIzmeniStavku";
            this.linkIzmeniStavku.Size = new System.Drawing.Size(119, 17);
            this.linkIzmeniStavku.TabIndex = 15;
            this.linkIzmeniStavku.TabStop = true;
            this.linkIzmeniStavku.Text = "Izmeni vrstu usluge";
            this.linkIzmeniStavku.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIzmeniStavku_LinkClicked);
            // 
            // textVrednostBezPDV
            // 
            this.textVrednostBezPDV.BackColor = System.Drawing.Color.SeaShell;
            this.textVrednostBezPDV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textVrednostBezPDV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textVrednostBezPDV.Location = new System.Drawing.Point(154, 37);
            this.textVrednostBezPDV.Name = "textVrednostBezPDV";
            this.textVrednostBezPDV.ReadOnly = true;
            this.textVrednostBezPDV.Size = new System.Drawing.Size(159, 20);
            this.textVrednostBezPDV.TabIndex = 1;
            this.textVrednostBezPDV.TabStop = false;
            this.textVrednostBezPDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(31, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Vrednost bez PDV";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(65, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Iznos rabata";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(36, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Poreska osnovica";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(33, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Vrednost sa PDV";
            // 
            // textIznosRabata
            // 
            this.textIznosRabata.BackColor = System.Drawing.Color.SeaShell;
            this.textIznosRabata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textIznosRabata.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIznosRabata.Location = new System.Drawing.Point(154, 69);
            this.textIznosRabata.Name = "textIznosRabata";
            this.textIznosRabata.ReadOnly = true;
            this.textIznosRabata.Size = new System.Drawing.Size(159, 20);
            this.textIznosRabata.TabIndex = 2;
            this.textIznosRabata.TabStop = false;
            this.textIznosRabata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textPoreskaOsnovica
            // 
            this.textPoreskaOsnovica.BackColor = System.Drawing.Color.SeaShell;
            this.textPoreskaOsnovica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPoreskaOsnovica.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPoreskaOsnovica.Location = new System.Drawing.Point(154, 101);
            this.textPoreskaOsnovica.Name = "textPoreskaOsnovica";
            this.textPoreskaOsnovica.ReadOnly = true;
            this.textPoreskaOsnovica.Size = new System.Drawing.Size(159, 20);
            this.textPoreskaOsnovica.TabIndex = 5;
            this.textPoreskaOsnovica.TabStop = false;
            this.textPoreskaOsnovica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textVrednostSaPDV
            // 
            this.textVrednostSaPDV.BackColor = System.Drawing.Color.SeaShell;
            this.textVrednostSaPDV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textVrednostSaPDV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textVrednostSaPDV.ForeColor = System.Drawing.Color.ForestGreen;
            this.textVrednostSaPDV.Location = new System.Drawing.Point(154, 165);
            this.textVrednostSaPDV.Name = "textVrednostSaPDV";
            this.textVrednostSaPDV.ReadOnly = true;
            this.textVrednostSaPDV.Size = new System.Drawing.Size(159, 20);
            this.textVrednostSaPDV.TabIndex = 9;
            this.textVrednostSaPDV.TabStop = false;
            this.textVrednostSaPDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textIznosPDVa);
            this.groupBox2.Controls.Add(this.textVrednostBezPDV);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textVrednostSaPDV);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textPoreskaOsnovica);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textIznosRabata);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox2.Location = new System.Drawing.Point(501, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 200);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ukupno";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(79, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "Iznos PDV";
            // 
            // textIznosPDVa
            // 
            this.textIznosPDVa.BackColor = System.Drawing.Color.SeaShell;
            this.textIznosPDVa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textIznosPDVa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIznosPDVa.Location = new System.Drawing.Point(154, 133);
            this.textIznosPDVa.Name = "textIznosPDVa";
            this.textIznosPDVa.ReadOnly = true;
            this.textIznosPDVa.Size = new System.Drawing.Size(159, 20);
            this.textIznosPDVa.TabIndex = 6;
            this.textIznosPDVa.TabStop = false;
            this.textIznosPDVa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textFakturaId
            // 
            this.textFakturaId.Location = new System.Drawing.Point(25, 351);
            this.textFakturaId.Name = "textFakturaId";
            this.textFakturaId.Size = new System.Drawing.Size(60, 22);
            this.textFakturaId.TabIndex = 11;
            this.textFakturaId.Visible = false;
            // 
            // textStavkaID
            // 
            this.textStavkaID.Location = new System.Drawing.Point(134, 351);
            this.textStavkaID.Name = "textStavkaID";
            this.textStavkaID.Size = new System.Drawing.Size(45, 22);
            this.textStavkaID.TabIndex = 10;
            this.textStavkaID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "stavka ID";
            this.label2.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(31, 330);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "faktura ID";
            this.label13.Visible = false;
            // 
            // errorProviderStavkaFakture
            // 
            this.errorProviderStavkaFakture.ContainerControl = this;
            // 
            // linkObrisiVrstuStavke
            // 
            this.linkObrisiVrstuStavke.AutoSize = true;
            this.linkObrisiVrstuStavke.Enabled = false;
            this.linkObrisiVrstuStavke.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkObrisiVrstuStavke.LinkColor = System.Drawing.Color.Tomato;
            this.linkObrisiVrstuStavke.Location = new System.Drawing.Point(22, 280);
            this.linkObrisiVrstuStavke.Name = "linkObrisiVrstuStavke";
            this.linkObrisiVrstuStavke.Size = new System.Drawing.Size(117, 17);
            this.linkObrisiVrstuStavke.TabIndex = 14;
            this.linkObrisiVrstuStavke.TabStop = true;
            this.linkObrisiVrstuStavke.Text = "Obriši vrstu usluge";
            this.linkObrisiVrstuStavke.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkObrisiVrstuStavke_LinkClicked);
            // 
            // StavkaFaktureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 487);
            this.Controls.Add(this.linkObrisiVrstuStavke);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textStavkaID);
            this.Controls.Add(this.textFakturaId);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkIzmeniStavku);
            this.Controls.Add(this.textDodatniOpis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textJedinicaMere);
            this.Controls.Add(this.linkNovaStavka);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textKolicina);
            this.Controls.Add(this.comboNazivStavke);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelVrstaUsluge);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(888, 480);
            this.Name = "StavkaFaktureForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stavke računa";
            this.Load += new System.EventHandler(this.StavkaFakture_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderStavkaFakture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelVrstaUsluge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboNazivStavke;
        private System.Windows.Forms.TextBox textKolicina;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textCenaBezPDV;
        private System.Windows.Forms.TextBox textRabat;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label labelNaslov;
        private System.Windows.Forms.LinkLabel linkNovaStavka;
        private System.Windows.Forms.TextBox textJedinicaMere;
        private System.Windows.Forms.TextBox textStopaPDV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDodatniOpis;
        private System.Windows.Forms.LinkLabel linkIzmeniStavku;
        private System.Windows.Forms.TextBox textVrednostBezPDV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textIznosRabata;
        private System.Windows.Forms.TextBox textPoreskaOsnovica;
        private System.Windows.Forms.TextBox textVrednostSaPDV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textFakturaId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textIznosPDVa;
        private System.Windows.Forms.TextBox textStavkaID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider errorProviderStavkaFakture;
        private System.Windows.Forms.LinkLabel linkObrisiVrstuStavke;
        private System.Windows.Forms.CheckBox checkBoxCenaSaPDV;
        private System.Windows.Forms.Label label14;
    }
}