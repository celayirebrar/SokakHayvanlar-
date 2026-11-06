namespace SokakHayvanlari.Forms
{
    partial class KayitFormu
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
            lblAdSoyad = new Label();
            txtAdSoyad = new TextBox();
            lblKullaniciAdi = new Label();
            txtKullaniciAdi = new TextBox();
            lblSifre = new Label();
            txtSifre = new TextBox();
            btnKaydet = new Button();
            SuspendLayout();
            // 
            // lblAdSoyad
            // 
            lblAdSoyad.AutoSize = true;
            lblAdSoyad.Location = new Point(229, 32);
            lblAdSoyad.Name = "lblAdSoyad";
            lblAdSoyad.Size = new Size(57, 15);
            lblAdSoyad.TabIndex = 0;
            lblAdSoyad.Text = "Ad Soyad";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(229, 50);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(206, 23);
            txtAdSoyad.TabIndex = 1;
            // 
            // lblKullaniciAdi
            // 
            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Location = new Point(229, 94);
            lblKullaniciAdi.Name = "lblKullaniciAdi";
            lblKullaniciAdi.Size = new Size(71, 15);
            lblKullaniciAdi.TabIndex = 2;
            lblKullaniciAdi.Text = "Kullanıcı adı";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(229, 112);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(206, 23);
            txtKullaniciAdi.TabIndex = 3;
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Location = new Point(229, 157);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(30, 15);
            lblSifre.TabIndex = 4;
            lblSifre.Text = "Şifre";
            lblSifre.Click += lblSifre_Click;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(229, 175);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(206, 23);
            txtSifre.TabIndex = 5;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(289, 283);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(75, 23);
            btnKaydet.TabIndex = 6;
            btnKaydet.Text = "Kayıt Ol";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // KayitFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 391);
            Controls.Add(btnKaydet);
            Controls.Add(txtSifre);
            Controls.Add(lblSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(lblKullaniciAdi);
            Controls.Add(txtAdSoyad);
            Controls.Add(lblAdSoyad);
            Name = "KayitFormu";
            Text = "KayitFormu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAdSoyad;
        private TextBox txtAdSoyad;
        private Label lblKullaniciAdi;
        private TextBox txtKullaniciAdi;
        private Label lblSifre;
        private TextBox txtSifre;
        private Button btnKaydet;
    }
} 
