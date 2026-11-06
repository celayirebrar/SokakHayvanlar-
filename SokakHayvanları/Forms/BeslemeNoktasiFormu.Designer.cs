
namespace SokakHayvanlari.Forms
{
    partial class BeslemeNoktasiFormu
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblNoktaAdi;
        private System.Windows.Forms.Label lblKonum;
        private System.Windows.Forms.Label lblEnlem;
        private System.Windows.Forms.Label lblBoylam;
        private System.Windows.Forms.Label lblMama;
        private System.Windows.Forms.Label lblSu;
        private System.Windows.Forms.Label lblAciklama;

        private System.Windows.Forms.TextBox txtNoktaAdi;
        private System.Windows.Forms.TextBox txtKonum;
        private System.Windows.Forms.TextBox txtEnlem;
        private System.Windows.Forms.TextBox txtBoylam;
        private System.Windows.Forms.TextBox txtAciklama;

        private System.Windows.Forms.ComboBox cmbMamaDurumu;
        private System.Windows.Forms.ComboBox cmbSuDurumu;

        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnListele;

        private System.Windows.Forms.DataGridView dgvNoktalar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            lblBaslik = new System.Windows.Forms.Label();
            lblNoktaAdi = new System.Windows.Forms.Label();
            lblKonum = new System.Windows.Forms.Label();
            lblEnlem = new System.Windows.Forms.Label();
            lblBoylam = new System.Windows.Forms.Label();
            lblMama = new System.Windows.Forms.Label();
            lblSu = new System.Windows.Forms.Label();
            lblAciklama = new System.Windows.Forms.Label();

            txtNoktaAdi = new System.Windows.Forms.TextBox();
            txtKonum = new System.Windows.Forms.TextBox();
            txtEnlem = new System.Windows.Forms.TextBox();
            txtBoylam = new System.Windows.Forms.TextBox();
            txtAciklama = new System.Windows.Forms.TextBox();

            cmbMamaDurumu = new System.Windows.Forms.ComboBox();
            cmbSuDurumu = new System.Windows.Forms.ComboBox();

            btnEkle = new System.Windows.Forms.Button();
            btnGuncelle = new System.Windows.Forms.Button();
            btnSil = new System.Windows.Forms.Button();
            btnListele = new System.Windows.Forms.Button();

            dgvNoktalar = new System.Windows.Forms.DataGridView();

            this.SuspendLayout();

            lblBaslik.Text = "BESLEME NOKTALARI";
            lblBaslik.Location = new System.Drawing.Point(300, 15);
            lblBaslik.AutoSize = true;

            lblNoktaAdi.Text = "Nokta Adı";
            lblNoktaAdi.Location = new System.Drawing.Point(30, 60);

            txtNoktaAdi.Location = new System.Drawing.Point(140, 57);
            txtNoktaAdi.Size = new System.Drawing.Size(180, 25);

            lblKonum.Text = "Konum";
            lblKonum.Location = new System.Drawing.Point(30, 100);

            txtKonum.Location = new System.Drawing.Point(140, 97);
            txtKonum.Size = new System.Drawing.Size(180, 25);

            lblEnlem.Text = "Enlem";
            lblEnlem.Location = new System.Drawing.Point(30, 140);

            txtEnlem.Location = new System.Drawing.Point(140, 137);
            txtEnlem.Size = new System.Drawing.Size(180, 25);

            lblBoylam.Text = "Boylam";
            lblBoylam.Location = new System.Drawing.Point(30, 180);

            txtBoylam.Location = new System.Drawing.Point(140, 177);
            txtBoylam.Size = new System.Drawing.Size(180, 25);

            lblMama.Text = "Mama Durumu";
            lblMama.Location = new System.Drawing.Point(30, 220);

            cmbMamaDurumu.Location = new System.Drawing.Point(140, 217);
            cmbMamaDurumu.Size = new System.Drawing.Size(180, 25);
            cmbMamaDurumu.Items.AddRange(new object[] { "Yeterli", "Az", "Yok" });

            lblSu.Text = "Su Durumu";
            lblSu.Location = new System.Drawing.Point(30, 260);

            cmbSuDurumu.Location = new System.Drawing.Point(140, 257);
            cmbSuDurumu.Size = new System.Drawing.Size(180, 25);
            cmbSuDurumu.Items.AddRange(new object[] { "Yeterli", "Az", "Yok" });

            lblAciklama.Text = "Açıklama";
            lblAciklama.Location = new System.Drawing.Point(30, 300);

            txtAciklama.Location = new System.Drawing.Point(140, 297);
            txtAciklama.Size = new System.Drawing.Size(180, 60);
            txtAciklama.Multiline = true;

            btnEkle.Text = "Ekle";
            btnEkle.Location = new System.Drawing.Point(30, 380);
            btnEkle.Size = new System.Drawing.Size(75, 30);

            btnGuncelle.Text = "Güncelle";
            btnGuncelle.Location = new System.Drawing.Point(115, 380);
            btnGuncelle.Size = new System.Drawing.Size(85, 30);

            btnSil.Text = "Sil";
            btnSil.Location = new System.Drawing.Point(210, 380);
            btnSil.Size = new System.Drawing.Size(75, 30);

            btnListele.Text = "Listele";
            btnListele.Location = new System.Drawing.Point(295, 380);
            btnListele.Size = new System.Drawing.Size(75, 30);

            dgvNoktalar.Location = new System.Drawing.Point(350, 60);
            dgvNoktalar.Size = new System.Drawing.Size(420, 350);
            dgvNoktalar.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvNoktalar.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvNoktalar.MultiSelect = false;
            dgvNoktalar.ReadOnly = true;

            this.Controls.Add(lblBaslik);
            this.Controls.Add(lblNoktaAdi);
            this.Controls.Add(lblKonum);
            this.Controls.Add(lblEnlem);
            this.Controls.Add(lblBoylam);
            this.Controls.Add(lblMama);
            this.Controls.Add(lblSu);
            this.Controls.Add(lblAciklama);

            this.Controls.Add(txtNoktaAdi);
            this.Controls.Add(txtKonum);
            this.Controls.Add(txtEnlem);
            this.Controls.Add(txtBoylam);
            this.Controls.Add(txtAciklama);

            this.Controls.Add(cmbMamaDurumu);
            this.Controls.Add(cmbSuDurumu);

            this.Controls.Add(btnEkle);
            this.Controls.Add(btnGuncelle);
            this.Controls.Add(btnSil);
            this.Controls.Add(btnListele);

            this.Controls.Add(dgvNoktalar);

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "BeslemeNoktasiFormu";
            this.Text = "Besleme Noktaları";
            this.ResumeLayout(false);
        }
    }
}
