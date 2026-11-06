
using System;
using System.Data;
using System.Windows.Forms;
using SokakHayvanlari.Models;
using SokakHayvanlari.Services;

namespace SokakHayvanlari.Forms
{
    public partial class SahiplendirmeFormu : Form
    {
        private SahiplendirmeServisi servis = new SahiplendirmeServisi();
        private GonulluServisi gonulluServisi = new GonulluServisi();
        private HayvanServisi hayvanServisi = new HayvanServisi();

        private int seciliBasvuruID = 0;

        public SahiplendirmeFormu()
        {
            InitializeComponent();

            btnBasvuruYap.Click += btnBasvuruYap_Click;
            btnListele.Click += btnListele_Click;
            btnDurumGuncelle.Click += btnDurumGuncelle_Click;
            dgvBasvurular.CellClick += dgvBasvurular_CellClick;

            btnDurumGuncelle.Visible = OturumYonetimi.YoneticiMi();

            HayvanlariGetir();
            BasvurulariListele();
        }

        private void HayvanlariGetir()
        {
            try
            {
                DataTable tablo = hayvanServisi.Listele();

                cmbHayvan.DataSource = tablo;
                cmbHayvan.DisplayMember = "Ad";
                cmbHayvan.ValueMember = "HayvanID";
                cmbHayvan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hayvanlar getirilemedi: " + ex.Message);
            }
        }

        private void BasvurulariListele()
        {
            try
            {
                dgvBasvurular.DataSource = servis.Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başvurular listelenemedi: " + ex.Message);
            }
        }

        private void btnBasvuruYap_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OturumYonetimi.GirisYapildiMi())
                {
                    MessageBox.Show("Önce giriş yapmalısınız!");
                    return;
                }

                if (cmbHayvan.SelectedIndex < 0)
                {
                    MessageBox.Show("Lütfen bir hayvan seçiniz!");
                    return;
                }

                Kullanici kullanici = OturumYonetimi.AktifKullanici;

                int gonulluID =
                    gonulluServisi.GonulluIDGetirVeyaOlustur(
                        kullanici.KullaniciID,
                        kullanici.AdSoyad
                    );

                Sahiplendirme basvuru = new Sahiplendirme
                {
                    HayvanID = Convert.ToInt32(cmbHayvan.SelectedValue),
                    GonulluID = gonulluID,
                    BasvuruTarihi = DateTime.Now,
                    Durum = "Beklemede"
                };

                servis.Ekle(basvuru);

                MessageBox.Show("Sahiplendirme başvurunuz oluşturuldu!");

                BasvurulariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başvuru hatası: " + ex.Message);
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            BasvurulariListele();
        }

        private void dgvBasvurular_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                seciliBasvuruID = Convert.ToInt32(
                    dgvBasvurular.Rows[e.RowIndex].Cells["BasvuruID"].Value);

                cmbDurum.Text = Convert.ToString(
                    dgvBasvurular.Rows[e.RowIndex].Cells["Durum"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başvuru seçilemedi: " + ex.Message);
            }
        }

        private void btnDurumGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OturumYonetimi.YoneticiMi())
                {
                    MessageBox.Show("Bu işlem için yönetici yetkisi gerekir!");
                    return;
                }

                if (seciliBasvuruID == 0)
                {
                    MessageBox.Show("Önce tablodan bir başvuru seçiniz!");
                    return;
                }

                servis.DurumGuncelle(seciliBasvuruID, cmbDurum.Text);

                MessageBox.Show("Başvuru durumu güncellendi!");

                seciliBasvuruID = 0;
                BasvurulariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }
    }
}
