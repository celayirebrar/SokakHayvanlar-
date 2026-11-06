using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokakHayvanlari.Models
{
    public class BeslemeNoktasi
    {
        public int NoktaID { get; set; }

        public string NoktaAdi { get; set; } = "";

        public string Konum { get; set; } = "";

        public double? Enlem { get; set; }

        public double? Boylam { get; set; }

        public string MamaDurumu { get; set; } = "";

        public string SuDurumu { get; set; } = "";

        public DateTime? SonBeslemeTarihi { get; set; }

        public string Aciklama { get; set; } = "";

        public bool Aktif { get; set; } = true;
    }
}
