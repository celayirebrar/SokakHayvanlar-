using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokakHayvanlari.Models
{
    public class Gonullu
    {
        public int GonulluID { get; set; }

        public int? KullaniciID { get; set; }

        public string AdSoyad { get; set; } = "";

        public string Telefon { get; set; } = "";

        public string Email { get; set; } = "";

        public string Adres { get; set; } = "";

        public string GonullulukDurumu { get; set; } = "Aktif";
    }
}