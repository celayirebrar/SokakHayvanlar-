namespace SokakHayvanlari.Forms
{
    partial class GirisFormu
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
            lblBaslik = new Label();
            lblKullanici = new Label();
            lblSifre = new Label();
            btnGiris = new Button();
            btnKayitOl = new Button();
            txtKullaniciAdi = new TextBox();
            txtSifre = new TextBox();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Location = new Point(228, 23);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(97, 15);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Sokak Hayvanları";
            // 
            // lblKullanici
            // 
            lblKullanici.AutoSize = true;
            lblKullanici.Location = new Point(57, 51);
            lblKullanici.Name = "lblKullanici";
            lblKullanici.Size = new Size(71, 15);
            lblKullanici.TabIndex = 1;
            lblKullanici.Text = "Kullanıcı adı";
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Location = new Point(57, 110);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(30, 15);
            lblSifre.TabIndex = 2;
            lblSifre.Text = "Şifre";
            // 
            // btnGiris
            // 
            btnGiris.Location = new Point(130, 201);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(239, 52);
            btnGiris.TabIndex = 3;
            btnGiris.Text = "Giriş Yap";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += but_Click;
            // 
            // btnKayitOl
            // 
            btnKayitOl.Location = new Point(130, 294);
            btnKayitOl.Name = "btnKayitOl";
            btnKayitOl.Size = new Size(239, 57);
            btnKayitOl.TabIndex = 4;
            btnKayitOl.Text = "Kayıt Ol";
            btnKayitOl.UseVisualStyleBackColor = true;
            btnKayitOl.Click += btnKayitOl_Click;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(57, 69);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(239, 23);
            txtKullaniciAdi.TabIndex = 5;
            txtKullaniciAdi.Click += d;
            txtKullaniciAdi.TextChanged += dcvc;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(57, 128);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(239, 23);
            txtSifre.TabIndex = 6;
            txtSifre.UseSystemPasswordChar = true;
            txtSifre.TextChanged += txtSifre_TextChanged;
            // 
            // GirisFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(btnKayitOl);
            Controls.Add(btnGiris);
            Controls.Add(lblSifre);
            Controls.Add(lblKullanici);
            Controls.Add(lblBaslik);
            Name = "GirisFormu";
            Text = "GirisFormu";
            Load += GirisFormu_Load;
            Click += txtSifre_TextChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBaslik;
        private Label lblKullanici;
        private Label lblSifre;
        private Button btnGiris;
        private Button button1;
        private Button btnKayitOl;
        private TextBox txtKullaniciAdi;
        private TextBox textBox1;
        private TextBox txtSifre;
    }
}
