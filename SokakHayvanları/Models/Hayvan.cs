
namespace SokakHayvanlari.Models
{
    public class Hayvan
    {
        public int HayvanID { get; set; }
        public string Ad { get; set; } = "";
        public string Tur { get; set; } = "Kedi";
        public string Cinsiyet { get; set; } = "";
        public int? Yas { get; set; }
        public string Konum { get; set; } = "";
        public string SaglikDurumu { get; set; } = "";
        public string SahiplendirmeDurumu { get; set; }
            = "Bekliyor";
        public string Fotograf { get; set; } = "";
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        
    }
}
