using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokakHayvanlari.Models
{
    public class Sahiplendirme
    {
        public int BasvuruID { get; set; }

        public int HayvanID { get; set; }

        public int GonulluID { get; set; }

        public DateTime BasvuruTarihi { get; set; }

        public string Durum { get; set; } = "Beklemede";
    }
}