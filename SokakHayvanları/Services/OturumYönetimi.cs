
using SokakHayvanlari.Models;

namespace SokakHayvanlari.Services
{
    public static class OturumYonetimi
    {
        // Sisteme giriş yapan kullanıcıyı tutar
        public static Kullanici AktifKullanici { get; private set; }

        // Kullanıcı giriş yaptığında çalışır
        public static void OturumAc(Kullanici kullanici)
        {
            AktifKullanici = kullanici;
        }

        // Kullanıcı çıkış yaptığında çalışır
        public static void OturumKapat()
        {
            AktifKullanici = null;
        }

        // Sisteme giriş yapılmış mı?
        public static bool GirisYapildiMi()
        {
            return AktifKullanici != null;
        }

        // Kullanıcı yönetici mi?
        public static bool YoneticiMi()
        {
            return AktifKullanici != null &&
                   AktifKullanici.Rol == "Yonetici";
        }

        // Kullanıcı gönüllü mü?
        public static bool GonulluMu()
        {
            return AktifKullanici != null &&
                   AktifKullanici.Rol == "Gonullu";
        }
    }
}
