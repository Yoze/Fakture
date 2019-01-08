namespace Fakture.UI
{
    partial class TekuciRacuniForm
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
            this.btnSnimi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBrojTR = new System.Windows.Forms.TextBox();
            this.textBanka = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textTRId = new System.Windows.Forms.TextBox();
            this.textKupacId = new System.Windows.Forms.TextBox();
            this.errorProviderTR = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSnimi
            // 
            this.btnSnimi.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSnimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnimi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnimi.ForeColor = System.Drawing.Color.White;
            this.btnSnimi.Location = new System.Drawing.Point(311, 204);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(75, 27);
            this.btnSnimi.TabIndex = 2;
            this.btnSnimi.Text = "SNIMI";
            this.btnSnimi.UseVisualStyleBackColor = false;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdustani.Location = new System.Drawing.Point(215, 204);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(90, 27);
            this.btnOdustani.TabIndex = 3;
            this.btnOdustani.Text = "ZATVORI";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(34, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Broj tekućeg računa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(34, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Naziv banke";
            // 
            // textBrojTR
            // 
            this.textBrojTR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBrojTR.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBrojTR.Location = new System.Drawing.Point(37, 95);
            this.textBrojTR.MaxLength = 255;
            this.textBrojTR.Name = "textBrojTR";
            this.textBrojTR.Size = new System.Drawing.Size(246, 20);
            this.textBrojTR.TabIndex = 0;
            this.textBrojTR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidacijaUnosaBrojaTR);
            this.textBrojTR.Validating += new System.ComponentModel.CancelEventHandler(this.textBrojTR_Validating);
            this.textBrojTR.Validated += new System.EventHandler(this.textBrojTR_Validated);
            // 
            // textBanka
            // 
            this.textBanka.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBanka.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBanka.Location = new System.Drawing.Point(37, 145);
            this.textBanka.MaxLength = 255;
            this.textBanka.Name = "textBanka";
            this.textBanka.Size = new System.Drawing.Size(328, 20);
            this.textBanka.TabIndex = 1;
            this.textBanka.Validating += new System.ComponentModel.CancelEventHandler(this.textBanka_Validating);
            this.textBanka.Validated += new System.EventHandler(this.textBanka_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(20, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Podaci o tekućim računima";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.BackgroundImage = global::Fakture.UI.Properties.Resources.Background;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 50);
            this.panel1.TabIndex = 8;
            // 
            // textTRId
            // 
            this.textTRId.Location = new System.Drawing.Point(11, 192);
            this.textTRId.Name = "textTRId";
            this.textTRId.Size = new System.Drawing.Size(80, 22);
            this.textTRId.TabIndex = 6;
            this.textTRId.TabStop = false;
            this.textTRId.Visible = false;
            // 
            // textKupacId
            // 
            this.textKupacId.Location = new System.Drawing.Point(12, 220);
            this.textKupacId.Name = "textKupacId";
            this.textKupacId.Size = new System.Drawing.Size(80, 22);
            this.textKupacId.TabIndex = 7;
            this.textKupacId.TabStop = false;
            this.textKupacId.Visible = false;
            // 
            // errorProviderTR
            // 
            this.errorProviderTR.ContainerControl = this;
            // 
            // TekuciRacuniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 243);
            this.Controls.Add(this.textKupacId);
            this.Controls.Add(this.textTRId);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBanka);
            this.Controls.Add(this.textBrojTR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnSnimi);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(414, 282);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(414, 282);
            this.Name = "TekuciRacuniForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tekući računi";
            this.Load += new System.EventHandler(this.TekuciRacuniForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBrojTR;
        private System.Windows.Forms.TextBox textBanka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textTRId;
        private System.Windows.Forms.TextBox textKupacId;
        private System.Windows.Forms.ErrorProvider errorProviderTR;
    }
}