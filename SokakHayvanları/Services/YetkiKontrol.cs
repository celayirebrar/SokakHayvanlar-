
using System;

namespace SokakHayvanlari.Services
{
    public static class YetkiKontrol
    {
        public static void GirisKontrol()
        {
            if (!OturumYonetimi.GirisYapildiMi())
            {
                throw new UnauthorizedAccessException(
                    "Önce sisteme giriş yapmalısınız."
                );
            }
        }

        public static void YoneticiKontrol()
        {
            GirisKontrol();

            if (!OturumYonetimi.YoneticiMi())
            {
                throw new UnauthorizedAccessException(
                    "Bu işlem için yönetici yetkisi gereklidir."
                );
            }
        }
    }
}
