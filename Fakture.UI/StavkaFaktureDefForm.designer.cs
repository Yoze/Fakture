namespace Fakture.UI
{
    partial class StavkaFaktureDefForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNaslov = new System.Windows.Forms.Label();
            this.buttonSnimi = new System.Windows.Forms.Button();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textNazivUsluge = new System.Windows.Forms.TextBox();
            this.comboStopaPDV = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textJedinicaMere = new System.Windows.Forms.TextBox();
            this.textVrstaStavkeId = new System.Windows.Forms.TextBox();
            this.errorProviderVrstaStavkeFak = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderVrstaStavkeFak)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Fakture.UI.Properties.Resources.Background;
            this.panel1.Controls.Add(this.labelNaslov);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 50);
            this.panel1.TabIndex = 10;
            // 
            // labelNaslov
            // 
            this.labelNaslov.AutoSize = true;
            this.labelNaslov.BackColor = System.Drawing.Color.Transparent;
            this.labelNaslov.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNaslov.ForeColor = System.Drawing.Color.Navy;
            this.labelNaslov.Location = new System.Drawing.Point(20, 15);
            this.labelNaslov.Name = "labelNaslov";
            this.labelNaslov.Size = new System.Drawing.Size(234, 25);
            this.labelNaslov.TabIndex = 0;
            this.labelNaslov.Text = "Nova vrsta stavke računa";
            // 
            // buttonSnimi
            // 
            this.buttonSnimi.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSnimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSnimi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSnimi.ForeColor = System.Drawing.Color.White;
            this.buttonSnimi.Location = new System.Drawing.Point(358, 213);
            this.buttonSnimi.Name = "buttonSnimi";
            this.buttonSnimi.Size = new System.Drawing.Size(75, 27);
            this.buttonSnimi.TabIndex = 3;
            this.buttonSnimi.Text = "SNIMI";
            this.buttonSnimi.UseVisualStyleBackColor = false;
            this.buttonSnimi.Click += new System.EventHandler(this.buttonSnimi_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOdustani.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOdustani.Location = new System.Drawing.Point(262, 213);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(90, 27);
            this.buttonOdustani.TabIndex = 4;
            this.buttonOdustani.Text = "ODUSTANI";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            this.buttonOdustani.Click += new System.EventHandler(this.buttonOdustani_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(26, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Naziv stavke";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(26, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jedinica mere";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(26, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Poreska stopa";
            // 
            // textNazivUsluge
            // 
            this.textNazivUsluge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textNazivUsluge.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNazivUsluge.Location = new System.Drawing.Point(131, 79);
            this.textNazivUsluge.MaxLength = 255;
            this.textNazivUsluge.Name = "textNazivUsluge";
            this.textNazivUsluge.Size = new System.Drawing.Size(286, 20);
            this.textNazivUsluge.TabIndex = 0;
            this.textNazivUsluge.Validating += new System.ComponentModel.CancelEventHandler(this.textNazivUsluge_Validating);
            this.textNazivUsluge.Validated += new System.EventHandler(this.textNazivUsluge_Validated);
            // 
            // comboStopaPDV
            // 
            this.comboStopaPDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStopaPDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboStopaPDV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStopaPDV.FormattingEnabled = true;
            this.comboStopaPDV.Items.AddRange(new object[] {
            "10",
            "20"});
            this.comboStopaPDV.Location = new System.Drawing.Point(131, 146);
            this.comboStopaPDV.Name = "comboStopaPDV";
            this.comboStopaPDV.Size = new System.Drawing.Size(121, 28);
            this.comboStopaPDV.TabIndex = 2;
            this.comboStopaPDV.Validating += new System.ComponentModel.CancelEventHandler(this.comboStopaPDV_Validating);
            this.comboStopaPDV.Validated += new System.EventHandler(this.comboStopaPDV_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(258, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "%";
            // 
            // textJedinicaMere
            // 
            this.textJedinicaMere.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textJedinicaMere.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textJedinicaMere.ForeColor = System.Drawing.Color.Black;
            this.textJedinicaMere.Location = new System.Drawing.Point(131, 114);
            this.textJedinicaMere.MaxLength = 10;
            this.textJedinicaMere.Name = "textJedinicaMere";
            this.textJedinicaMere.Size = new System.Drawing.Size(121, 20);
            this.textJedinicaMere.TabIndex = 1;
            this.textJedinicaMere.Validating += new System.ComponentModel.CancelEventHandler(this.textJedinicaMere_Validating);
            this.textJedinicaMere.Validated += new System.EventHandler(this.textJedinicaMere_Validated);
            // 
            // textVrstaStavkeId
            // 
            this.textVrstaStavkeId.Location = new System.Drawing.Point(25, 218);
            this.textVrstaStavkeId.Name = "textVrstaStavkeId";
            this.textVrstaStavkeId.Size = new System.Drawing.Size(40, 25);
            this.textVrstaStavkeId.TabIndex = 9;
            this.textVrstaStavkeId.TabStop = false;
            this.textVrstaStavkeId.Visible = false;
            // 
            // errorProviderVrstaStavkeFak
            // 
            this.errorProviderVrstaStavkeFak.ContainerControl = this;
            // 
            // StavkaFaktureDefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 252);
            this.Controls.Add(this.textVrstaStavkeId);
            this.Controls.Add(this.textJedinicaMere);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboStopaPDV);
            this.Controls.Add(this.textNazivUsluge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonSnimi);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(461, 291);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(461, 291);
            this.Name = "StavkaFaktureDefForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vrste stavki računa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StavkaFaktureDefForm_FormClosing);
            this.Load += new System.EventHandler(this.StavkaFaktureDefForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderVrstaStavkeFak)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSnimi;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNazivUsluge;
        private System.Windows.Forms.ComboBox comboStopaPDV;
        public System.Windows.Forms.Label labelNaslov;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textJedinicaMere;
        private System.Windows.Forms.TextBox textVrstaStavkeId;
        private System.Windows.Forms.ErrorProvider errorProviderVrstaStavkeFak;
    }
}