namespace Fakture.UI
{
    partial class OdabirKorisnikaForm
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
            this.btnMilan = new System.Windows.Forms.Button();
            this.btnDamir = new System.Windows.Forms.Button();
            this.lblConn = new System.Windows.Forms.Label();
            this.btnBata = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMilan
            // 
            this.btnMilan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMilan.ForeColor = System.Drawing.Color.Navy;
            this.btnMilan.Location = new System.Drawing.Point(26, 90);
            this.btnMilan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMilan.Name = "btnMilan";
            this.btnMilan.Size = new System.Drawing.Size(207, 54);
            this.btnMilan.TabIndex = 0;
            this.btnMilan.Text = "M i l a n";
            this.btnMilan.UseVisualStyleBackColor = true;
            this.btnMilan.Click += new System.EventHandler(this.btnMilan_Click);
            // 
            // btnDamir
            // 
            this.btnDamir.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDamir.ForeColor = System.Drawing.Color.Navy;
            this.btnDamir.Location = new System.Drawing.Point(241, 90);
            this.btnDamir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDamir.Name = "btnDamir";
            this.btnDamir.Size = new System.Drawing.Size(207, 54);
            this.btnDamir.TabIndex = 1;
            this.btnDamir.Text = "D a m i r";
            this.btnDamir.UseVisualStyleBackColor = true;
            this.btnDamir.Click += new System.EventHandler(this.btnDamir_Click);
            // 
            // lblConn
            // 
            this.lblConn.AutoSize = true;
            this.lblConn.Location = new System.Drawing.Point(26, 166);
            this.lblConn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(50, 20);
            this.lblConn.TabIndex = 2;
            this.lblConn.Text = "label1";
            this.lblConn.Visible = false;
            // 
            // btnBata
            // 
            this.btnBata.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBata.ForeColor = System.Drawing.Color.Navy;
            this.btnBata.Location = new System.Drawing.Point(455, 90);
            this.btnBata.Name = "btnBata";
            this.btnBata.Size = new System.Drawing.Size(207, 54);
            this.btnBata.TabIndex = 3;
            this.btnBata.Text = "B a t a";
            this.btnBata.UseVisualStyleBackColor = true;
            this.btnBata.Click += new System.EventHandler(this.btnBata_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(197, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Odaberite korisnika";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Khaki;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnClose.Location = new System.Drawing.Point(537, 200);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "ODUSTANI";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "FAKTURISANJE";
            // 
            // OdabirKorisnikaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(683, 260);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBata);
            this.Controls.Add(this.lblConn);
            this.Controls.Add(this.btnDamir);
            this.Controls.Add(this.btnMilan);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(683, 260);
            this.MinimumSize = new System.Drawing.Size(683, 260);
            this.Name = "OdabirKorisnikaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fakturisanje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMilan;
        private System.Windows.Forms.Button btnDamir;
        private System.Windows.Forms.Label lblConn;
        private System.Windows.Forms.Button btnBata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
    }
}