using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokakHayvanlari.Models
{
    public class Tedavi
    {
        public int TedaviID { get; set; }

        public int HayvanID { get; set; }

        public string Veteriner { get; set; } = "";

        public string Teshis { get; set; } = "";

        public string TedaviAciklamasi { get; set; } = "";

        public DateTime Tarih { get; set; }
    }
}