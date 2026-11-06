using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SokakHayvanlari.Models;
using SokakHayvanlari.Services;

namespace SokakHayvanlari.Forms
{
    public partial class HayvanFormu : Form
    {
        private HayvanServisi hayvanServisi = new HayvanServisi();
        private int seciliHayvanID = 0;

        public HayvanFormu()
        {
            InitializeComponent();

            // ComboBox seçenekleri
            cmbTur.Items.Clear();
            cmbTur.Items.AddRange(new string[] { "Kedi", "Köpek", "Diğer" });

            cmbCinsiyet.Items.Clear();
            cmbCinsiyet.Items.AddRange(
                new string[] { "Dişi", "Erkek", "Bilinmiyor" });

            cmbSahiplendirmeDurumu.Items.Clear();
            cmbSahiplendirmeDurumu.Items.AddRange(
                new string[] { "Bekliyor", "Sahiplendirildi" });

            // Buton bağlantıları
            btnEkle.Click += btnEkle_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            btnSil.Click += btnSil_Click;
            btnListele.Click += btnListele_Click;

            // Tabloya tıklama bağlantısı
            dgvHayvanlar.CellClick += dgvHayvanlar_CellClick;

            // Tablo ayarları
            dgvHayvanlar.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvHayvanlar.MultiSelect = false;
            dgvHayvanlar.ReadOnly = true;
            dgvHayvanlar.AllowUserToAddRows = false;
            dgvHayvanlar.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Form açılınca hayvanları getir
            HayvanlariListele();
        }

        // HAYVANLARI LİSTELE
        private void HayvanlariListele()
        {
            try
            {
                dgvHayvanlar.DataSource = hayvanServisi.Listele();
                dgvHayvanlar.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Hayvanlar listelenirken hata oluştu:\n" + ex.Message);
            }
        }

        // HAYVAN EKLE
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.Trim() == "" ||
                cmbTur.Text == "" ||
                cmbCinsiyet.Text == "" ||
                txtKonum.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun.");
                return;
            }

            int? yas = null;

            if (txtYas.Text.Trim() != "")
            {
                int yasDegeri;

                if (!int.TryParse(txtYas.Text, out yasDegeri) ||
                    yasDegeri < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir yaş girin.");
                    return;
                }

                yas = yasDegeri;
            }

            try
            {
                Hayvan hayvan = new Hayvan();

                hayvan.Ad = txtAd.Text.Trim();
                hayvan.Tur = cmbTur.Text;
                hayvan.Cinsiyet = cmbCinsiyet.Text;
                hayvan.Yas = yas;
                hayvan.Konum = txtKonum.Text.Trim();
                hayvan.SaglikDurumu = txtSaglikDurumu.Text.Trim();
                hayvan.SahiplendirmeDurumu =
                    cmbSahiplendirmeDurumu.Text;
                hayvan.Fotograf = txtFotograf.Text.Trim();

                hayvanServisi.Ekle(hayvan);

                MessageBox.Show("Hayvan başarıyla eklendi.");

                HayvanlariListele();
                AlanlariTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Hayvan eklenirken hata oluştu:\n" + ex.Message);
            }
        }

        // TABLODAN HAYVAN SEÇ
        private void dgvHayvanlar_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow satir = dgvHayvanlar.Rows[e.RowIndex];

            seciliHayvanID = Convert.ToInt32(
                satir.Cells["HayvanID"].Value);

            txtAd.Text =
                satir.Cells["Ad"].Value?.ToString() ?? "";

            cmbTur.Text =
                satir.Cells["Tur"].Value?.ToString() ?? "";

            cmbCinsiyet.Text =
                satir.Cells["Cinsiyet"].Value?.ToString() ?? "";

            txtYas.Text =
                satir.Cells["Yas"].Value?.ToString() ?? "";

            txtKonum.Text =
                satir.Cells["Konum"].Value?.ToString() ?? "";

            txtSaglikDurumu.Text =
                satir.Cells["SaglikDurumu"].Value?.ToString() ?? "";

            cmbSahiplendirmeDurumu.Text =
                satir.Cells["SahiplendirmeDurumu"].Value?.ToString() ?? "";

            txtFotograf.Text =
                satir.Cells["Fotograf"].Value?.ToString() ?? "";
        }

        // HAYVAN GÜNCELLE
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliHayvanID == 0)
            {
                MessageBox.Show("Önce tablodan bir hayvan seçin.");
                return;
            }

            if (txtAd.Text.Trim() == "" ||
                cmbTur.Text == "" ||
                cmbCinsiyet.Text == "" ||
                txtKonum.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun.");
                return;
            }

            int? yas = null;

            if (txtYas.Text.Trim() != "")
            {
                int yasDegeri;

                if (!int.TryParse(txtYas.Text, out yasDegeri) ||
                    yasDegeri < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir yaş girin.");
                    return;
                }

                yas = yasDegeri;
            }

            try
            {
                Hayvan hayvan = new Hayvan();

                hayvan.HayvanID = seciliHayvanID;
                hayvan.Ad = txtAd.Text.Trim();
                hayvan.Tur = cmbTur.Text;
                hayvan.Cinsiyet = cmbCinsiyet.Text;
                hayvan.Yas = yas;
                hayvan.Konum = txtKonum.Text.Trim();
                hayvan.SaglikDurumu = txtSaglikDurumu.Text.Trim();
                hayvan.SahiplendirmeDurumu =
                    cmbSahiplendirmeDurumu.Text;
                hayvan.Fotograf = txtFotograf.Text.Trim();

                hayvanServisi.Guncelle(hayvan);

                MessageBox.Show("Hayvan bilgileri güncellendi.");

                HayvanlariListele();
                AlanlariTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Güncelleme sırasında hata:\n" + ex.Message);
            }
        }

        // HAYVAN SİL
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliHayvanID == 0)
            {
                MessageBox.Show("Önce tablodan bir hayvan seçin.");
                return;
            }

            DialogResult cevap = MessageBox.Show(
                "Seçili hayvanı silmek istiyor musunuz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                try
                {
                    hayvanServisi.Sil(seciliHayvanID);

                    MessageBox.Show("Hayvan başarıyla silindi.");

                    HayvanlariListele();
                    AlanlariTemizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Silme sırasında hata:\n" + ex.Message);
                }
            }
        }

        // LİSTELE BUTONU
        private void btnListele_Click(object sender, EventArgs e)
        {
            HayvanlariListele();
        }

        // ALANLARI TEMİZLE
        private void AlanlariTemizle()
        {
            txtAd.Clear();
            cmbTur.SelectedIndex = -1;
            cmbCinsiyet.SelectedIndex = -1;
            txtYas.Clear();
            txtKonum.Clear();
            txtSaglikDurumu.Clear();
            cmbSahiplendirmeDurumu.SelectedIndex = -1;
            txtFotograf.Clear();

            seciliHayvanID = 0;
            dgvHayvanlar.ClearSelection();
        }

        // FORM TASARIMI
        private void InitializeComponent()
        {
            lblBaslik = new Label();
            lblAd = new Label();
            txtAd = new TextBox();
            lblTur = new Label();
            cmbTur = new ComboBox();
            lblCinsiyet = new Label();
            cmbCinsiyet = new ComboBox();
            lblYas = new Label();
            txtYas = new TextBox();
            lblKonum = new Label();
            txtKonum = new TextBox();
            lblSaglik = new Label();
            txtSaglikDurumu = new TextBox();
            lblSahiplenme = new Label();
            cmbSahiplendirmeDurumu = new ComboBox();
            lblFotograf = new Label();
            txtFotograf = new TextBox();
            btnEkle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            btnListele = new Button();
            dgvHayvanlar = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvHayvanlar).BeginInit();
            SuspendLayout();

            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblBaslik.Location = new Point(265, 9);
            lblBaslik.Text = "HAYVAN YÖNETİMİ";

            lblAd.AutoSize = true;
            lblAd.Location = new Point(43, 72);
            lblAd.Text = "Hayvan Adı";

            txtAd.Location = new Point(43, 90);
            txtAd.Size = new Size(135, 23);

            lblTur.AutoSize = true;
            lblTur.Location = new Point(279, 72);
            lblTur.Text = "Tür";

            cmbTur.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTur.Location = new Point(279, 90);
            cmbTur.Size = new Size(121, 23);

            lblCinsiyet.AutoSize = true;
            lblCinsiyet.Location = new Point(43, 133);
            lblCinsiyet.Text = "Cinsiyet";

            cmbCinsiyet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCinsiyet.Location = new Point(43, 151);
            cmbCinsiyet.Size = new Size(121, 23);

            lblYas.AutoSize = true;
            lblYas.Location = new Point(279, 137);
            lblYas.Text = "Yaş";

            txtYas.Location = new Point(279, 155);
            txtYas.Size = new Size(92, 23);

            lblKonum.AutoSize = true;
            lblKonum.Location = new Point(43, 198);
            lblKonum.Text = "Konum";

            txtKonum.Location = new Point(43, 216);
            txtKonum.Size = new Size(135, 23);

            lblSaglik.AutoSize = true;
            lblSaglik.Location = new Point(279, 198);
            lblSaglik.Text = "Sağlık Durumu";

            txtSaglikDurumu.Location = new Point(279, 216);
            txtSaglikDurumu.Size = new Size(135, 23);

            lblSahiplenme.AutoSize = true;
            lblSahiplenme.Location = new Point(43, 256);
            lblSahiplenme.Text = "Sahiplendirme Durumu";

            cmbSahiplendirmeDurumu.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbSahiplendirmeDurumu.Location = new Point(43, 284);
            cmbSahiplendirmeDurumu.Size = new Size(150, 23);

            lblFotograf.AutoSize = true;
            lblFotograf.Location = new Point(279, 256);
            lblFotograf.Text = "Fotoğraf yolu";

            txtFotograf.Location = new Point(279, 284);
            txtFotograf.Size = new Size(135, 23);

            btnEkle.Location = new Point(43, 326);
            btnEkle.Size = new Size(85, 30);
            btnEkle.Text = "Hayvan Ekle";

            btnGuncelle.Location = new Point(134, 326);
            btnGuncelle.Size = new Size(85, 30);
            btnGuncelle.Text = "Güncelle";

            btnSil.Location = new Point(225, 326);
            btnSil.Size = new Size(65, 30);
            btnSil.Text = "Sil";

            btnListele.Location = new Point(296, 326);
            btnListele.Size = new Size(75, 30);
            btnListele.Text = "Listele";

            dgvHayvanlar.Location = new Point(43, 375);
            dgvHayvanlar.Size = new Size(850, 190);
            dgvHayvanlar.AllowUserToAddRows = false;
            dgvHayvanlar.AllowUserToDeleteRows = false;
            dgvHayvanlar.ReadOnly = true;
            dgvHayvanlar.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvHayvanlar.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvHayvanlar.MultiSelect = false;

            ClientSize = new Size(984, 611);
            BackColor = SystemColors.ControlLightLight;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hayvan Yönetimi";

            Controls.Add(lblBaslik);
            Controls.Add(lblAd);
            Controls.Add(txtAd);
            Controls.Add(lblTur);
            Controls.Add(cmbTur);
            Controls.Add(lblCinsiyet);
            Controls.Add(cmbCinsiyet);
            Controls.Add(lblYas);
            Controls.Add(txtYas);
            Controls.Add(lblKonum);
            Controls.Add(txtKonum);
            Controls.Add(lblSaglik);
            Controls.Add(txtSaglikDurumu);
            Controls.Add(lblSahiplenme);
            Controls.Add(cmbSahiplendirmeDurumu);
            Controls.Add(lblFotograf);
            Controls.Add(txtFotograf);
            Controls.Add(btnEkle);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnListele);
            Controls.Add(dgvHayvanlar);

            Name = "HayvanFormu";

            ((System.ComponentModel.ISupportInitialize)dgvHayvanlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblBaslik;
        private Label lblAd;
        private TextBox txtAd;
        private Label lblTur;
        private ComboBox cmbTur;
        private Label lblCinsiyet;
        private ComboBox cmbCinsiyet;
        private Label lblYas;
        private TextBox txtYas;
        private Label lblKonum;
        private TextBox txtKonum;
        private Label lblSaglik;
        private TextBox txtSaglikDurumu;
        private Label lblSahiplenme;
        private ComboBox cmbSahiplendirmeDurumu;
        private Label lblFotograf;
        private TextBox txtFotograf;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnListele;
        private DataGridView dgvHayvanlar;
    }
}