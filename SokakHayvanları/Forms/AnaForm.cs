
using System;
using System.Windows.Forms;
using SokakHayvanlari.Models;
using SokakHayvanlari.Services;

namespace SokakHayvanlari.Forms
{
    public partial class AnaForm : Form
    {
        private Kullanici aktifKullanici;

        public AnaForm(Kullanici kullanici)
        {
            InitializeComponent();

            aktifKullanici = kullanici;

            // Butonların tıklama işlemleri
            btnHayvanlar.Click += btnHayvanlar_Click;
            btnGonulluler.Click += btnGonulluler_Click;
            btnBeslemeNoktalari.Click += btnBeslemeNoktalari_Click;
            btnSahiplendirme.Click += btnSahiplendirme_Click;
            btnCikis.Click += btnCikis_Click;

            // Kullanıcının rolüne göre menüyü ayarla
            YetkileriAyarla();

            MessageBox.Show(
                "Hoş geldin " + aktifKullanici.AdSoyad,
                "Giriş Başarılı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void YetkileriAyarla()
        {
            bool yonetici = OturumYonetimi.YoneticiMi();

            // Gönüllü yönetimi yalnızca yöneticiye açık
            btnGonulluler.Visible = yonetici;
        }

        private void btnHayvanlar_Click(object sender, EventArgs e)
        {
            if (!OturumYonetimi.GirisYapildiMi())
            {
                MessageBox.Show("Önce giriş yapmalısınız.");
                return;
            }

            using (HayvanFormu form = new HayvanFormu())
            {
                form.ShowDialog();
            }
        }

        private void btnGonulluler_Click(object sender, EventArgs e)
        {
            if (!OturumYonetimi.YoneticiMi())
            {
                MessageBox.Show("Bu işlem için yönetici yetkisi gereklidir.");
                return;
            }

            MessageBox.Show(
                "Gönüllüler yönetimi ekranını bir sonraki modülde hazırlayacağız."
            );
        }

        private void btnBeslemeNoktalari_Click(object sender, EventArgs e)
        {
            using (BeslemeNoktasiFormu form = new BeslemeNoktasiFormu())
            {
                form.ShowDialog();
            }
        }




        private void btnSahiplendirme_Click(object sender, EventArgs e)
        {
            if (!OturumYonetimi.GirisYapildiMi())
            {
                MessageBox.Show("Önce giriş yapmalısınız.");
                return;
            }
            using (SahiplendirmeFormu form = new SahiplendirmeFormu())
            {
                form.ShowDialog();
            }

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show(
                "Oturumu kapatmak istiyor musunuz?",
                "Çıkış Yap",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cevap == DialogResult.Yes)
            {
                OturumYonetimi.OturumKapat();
                this.Close();
            }
        }
    }
}
