
namespace SokakHayvanlari.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string AdSoyad { get; set; } = "";
        public string KullaniciAdi { get; set; } = "";
        public string SifreHash { get; set; } = "";
        public string Rol { get; set; } = "Gonullu";
        public bool Aktif { get; set; }
    }
}
