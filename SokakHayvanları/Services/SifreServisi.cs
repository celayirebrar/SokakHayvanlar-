
using System.Security.Cryptography;

namespace SokakHayvanlari.Services
{
    public static class SifreServisi
    {
        public static string HashOlustur(string sifre)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                sifre,
                salt,
                600_000,
                HashAlgorithmName.SHA256,
                32);

            return Convert.ToBase64String(salt) + "." +
                   Convert.ToBase64String(hash);
        }

        public static bool Dogrula(
            string sifre,
            string kayitliHash)
        {
            string[] parcalar = kayitliHash.Split('.');

            if (parcalar.Length != 2)
                return false;

            try
            {
                byte[] salt =
                    Convert.FromBase64String(parcalar[0]);
                byte[] beklenen =
                    Convert.FromBase64String(parcalar[1]);

                byte[] hesaplanan = Rfc2898DeriveBytes.Pbkdf2(
                    sifre,
                    salt,
                    600_000,
                    HashAlgorithmName.SHA256,
                    32);

                return CryptographicOperations.FixedTimeEquals(
                    beklenen, hesaplanan);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
