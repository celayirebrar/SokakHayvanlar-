
using System;
using System.Globalization;
using System.Windows.Forms;
using SokakHayvanlari.Models;
using SokakHayvanlari.Services;

namespace SokakHayvanlari.Forms
{
    public partial class BeslemeNoktasiFormu : Form
    {
        private BeslemeNoktasiServisi servis = new BeslemeNoktasiServisi();
        private int seciliNoktaID = 0;

        public BeslemeNoktasiFormu()
        {
            InitializeComponent();

            btnEkle.Click += btnEkle_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            btnSil.Click += btnSil_Click;
            btnListele.Click += btnListele_Click;
            dgvNoktalar.CellClick += dgvNoktalar_CellClick;

            NoktalariListele();
        }

        private BeslemeNoktasi BilgileriAl()
        {
            if (string.IsNullOrWhiteSpace(txtNoktaAdi.Text) ||
                string.IsNullOrWhiteSpace(txtKonum.Text))
            {
                throw new Exception("Nokta adı ve konum boş bırakılamaz!");
            }

            double enlem;
            double boylam;

            double? enlemDegeri = null;
            double? boylamDegeri = null;

            if (!string.IsNullOrWhiteSpace(txtEnlem.Text))
            {
                if (!double.TryParse(txtEnlem.Text, NumberStyles.Any,
                    CultureInfo.CurrentCulture, out enlem))
                    throw new Exception("Enlem sayısal olmalıdır!");

                enlemDegeri = enlem;
            }

            if (!string.IsNullOrWhiteSpace(txtBoylam.Text))
            {
                if (!double.TryParse(txtBoylam.Text, NumberStyles.Any,
                    CultureInfo.CurrentCulture, out boylam))
                    throw new Exception("Boylam sayısal olmalıdır!");

                boylamDegeri = boylam;
            }

            return new BeslemeNoktasi
            {
                NoktaID = seciliNoktaID,
                NoktaAdi = txtNoktaAdi.Text.Trim(),
                Konum = txtKonum.Text.Trim(),
                Enlem = enlemDegeri,
                Boylam = boylamDegeri,
                MamaDurumu = cmbMamaDurumu.Text,
                SuDurumu = cmbSuDurumu.Text,
                SonBeslemeTarihi = DateTime.Now,
                Aciklama = txtAciklama.Text.Trim(),
                Aktif = true
            };
        }

        private void NoktalariListele()
        {
            try
            {
                dgvNoktalar.DataSource = servis.Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                BeslemeNoktasi nokta = BilgileriAl();
                nokta.NoktaID = 0;

                servis.Ekle(nokta);

                MessageBox.Show("Besleme noktası başarıyla eklendi!");
                FormuTemizle();
                NoktalariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliNoktaID == 0)
                {
                    MessageBox.Show("Önce listeden bir kayıt seçiniz!");
                    return;
                }

                BeslemeNoktasi nokta = BilgileriAl();
                servis.Guncelle(nokta);

                MessageBox.Show("Besleme noktası güncellendi!");
                FormuTemizle();
                NoktalariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliNoktaID == 0)
                {
                    MessageBox.Show("Önce listeden bir kayıt seçiniz!");
                    return;
                }

                DialogResult cevap = MessageBox.Show(
                    "Seçili besleme noktasını silmek istiyor musunuz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    servis.Sil(seciliNoktaID);

                    MessageBox.Show("Kayıt silindi!");
                    FormuTemizle();
                    NoktalariListele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatası: " + ex.Message);
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            NoktalariListele();
        }

        private void dgvNoktalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow satir = dgvNoktalar.Rows[e.RowIndex];

                seciliNoktaID = Convert.ToInt32(satir.Cells["NoktaID"].Value);
                txtNoktaAdi.Text = Convert.ToString(satir.Cells["NoktaAdi"].Value);
                txtKonum.Text = Convert.ToString(satir.Cells["Konum"].Value);
                txtEnlem.Text = Convert.ToString(satir.Cells["Enlem"].Value);
                txtBoylam.Text = Convert.ToString(satir.Cells["Boylam"].Value);
                cmbMamaDurumu.Text = Convert.ToString(satir.Cells["MamaDurumu"].Value);
                cmbSuDurumu.Text = Convert.ToString(satir.Cells["SuDurumu"].Value);
                txtAciklama.Text = Convert.ToString(satir.Cells["Aciklama"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt seçme hatası: " + ex.Message);
            }
        }

        private void FormuTemizle()
        {
            seciliNoktaID = 0;

            txtNoktaAdi.Clear();
            txtKonum.Clear();
            txtEnlem.Clear();
            txtBoylam.Clear();
            txtAciklama.Clear();

            cmbMamaDurumu.SelectedIndex = -1;
            cmbSuDurumu.SelectedIndex = -1;
        }
    }
}
