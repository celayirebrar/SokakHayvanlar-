using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SokakHayvanlari.Services;

namespace SokakHayvanlari
    .Forms
{
    public partial class KayitFormu : Form
    {
        public KayitFormu()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                    string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                    string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }

            try
            {
                KullaniciServisi servis = new KullaniciServisi();

                servis.KayitOl(
                    txtAdSoyad.Text.Trim(),
                    txtKullaniciAdi.Text.Trim(),
                    txtSifre.Text,
                    "Gonullu"
                );

                MessageBox.Show("Kayıt başarılı!");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata: " + ex.Message);
            }
        }

        private void lblSifre_Click(object sender, EventArgs e)
        {

        }
    }

}
