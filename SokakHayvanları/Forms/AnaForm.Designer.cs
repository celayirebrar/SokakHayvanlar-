namespace SokakHayvanlari.Forms
{
    partial class AnaForm
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
            llblBaslik = new Label();
            btnHayvanlar = new Button();
            btnGonulluler = new Button();
            btnBeslemeNoktalari = new Button();
            btnSahiplendirme = new Button();
            btnCikis = new Button();
            SuspendLayout();
            // 
            // llblBaslik
            // 
            llblBaslik.AutoSize = true;
            llblBaslik.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llblBaslik.Location = new Point(12, 9);
            llblBaslik.Name = "llblBaslik";
            llblBaslik.Size = new Size(387, 30);
            llblBaslik.TabIndex = 0;
            llblBaslik.Text = "SOKAK HAYVANLARI YÖNETİM SİSTEMİ";
            // 
            // btnHayvanlar
            // 
            btnHayvanlar.Location = new Point(119, 117);
            btnHayvanlar.Name = "btnHayvanlar";
            btnHayvanlar.Size = new Size(106, 65);
            btnHayvanlar.TabIndex = 1;
            btnHayvanlar.Text = "Hayvanlar";
            btnHayvanlar.UseVisualStyleBackColor = true;
            // 
            // btnGonulluler
            // 
            btnGonulluler.Location = new Point(328, 117);
            btnGonulluler.Name = "btnGonulluler";
            btnGonulluler.Size = new Size(105, 65);
            btnGonulluler.TabIndex = 2;
            btnGonulluler.Text = "Gönüllüler";
            btnGonulluler.UseVisualStyleBackColor = true;
            // 
            // btnBeslemeNoktalari
            // 
            btnBeslemeNoktalari.Location = new Point(119, 210);
            btnBeslemeNoktalari.Name = "btnBeslemeNoktalari";
            btnBeslemeNoktalari.Size = new Size(106, 65);
            btnBeslemeNoktalari.TabIndex = 3;
            btnBeslemeNoktalari.Text = "\tBesleme Noktaları";
            btnBeslemeNoktalari.UseVisualStyleBackColor = true;
            // 
            // btnSahiplendirme
            // 
            btnSahiplendirme.Location = new Point(328, 210);
            btnSahiplendirme.Name = "btnSahiplendirme";
            btnSahiplendirme.Size = new Size(105, 65);
            btnSahiplendirme.TabIndex = 4;
            btnSahiplendirme.Text = "Sahiplendirme";
            btnSahiplendirme.UseVisualStyleBackColor = true;
            // 
            // btnCikis
            // 
            btnCikis.Location = new Point(119, 293);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(106, 60);
            btnCikis.TabIndex = 5;
            btnCikis.Text = "Çıkış Yap";
            btnCikis.UseVisualStyleBackColor = true;
            // 
            // AnaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(btnCikis);
            Controls.Add(btnSahiplendirme);
            Controls.Add(btnBeslemeNoktalari);
            Controls.Add(btnGonulluler);
            Controls.Add(btnHayvanlar);
            Controls.Add(llblBaslik);
            Name = "AnaForm";
            Text = "Sokak Hayvanları Yönetim Sistemi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label llblBaslik;
        private Button btnHayvanlar;
        private Button btnGonulluler;
        private Button btnBeslemeNoktalari;
        private Button btnSahiplendirme;
        private Button btnCikis;
    }
}
