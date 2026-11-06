using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokakHayvanlari.Models
{
    public class AcilBildirim
    {
        public int BildirimID { get; set; }

        public int HayvanID { get; set; }

        public string Konum { get; set; } = "";

        public string Aciklama { get; set; } = "";

        public DateTime Tarih { get; set; } = DateTime.Now;

        public string Durum { get; set; } = "Beklemede";
    }
}