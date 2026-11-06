
using System;
using System.Windows.Forms;
using SokakHayvanlari.Models;
using SokakHayvanlari.Services;

namespace SokakHayvanlari.Forms
{
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }

        private void GirisFormu_Load(object sender, EventArgs e)
        {

        }

        private void but_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre giriniz!");
                return;
            }

            try
            {
                KullaniciServisi servis = new KullaniciServisi();

                Kullanici? kullanici = servis.GirisYap(
                    txtKullaniciAdi.Text.Trim(),
                    txtSifre.Text
                );

                if (kullanici == null)
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                    return;
                }




                // Giriş yapan kullanıcıyı oturuma kaydet
                OturumYonetimi.OturumAc(kullanici);

                this.Hide();

                using (AnaForm anaForm = new AnaForm(kullanici))
                {
                    anaForm.ShowDialog();
                }

                // AnaForm kapanınca giriş ekranına geri dön
                txtSifre.Clear();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void d(object sender, EventArgs e)
        {

        }

        private void dcvc(object sender, EventArgs e)
        {

        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            using (KayitFormu form = new KayitFormu())
            {
                form.ShowDialog();
            }
        }
    }
}
