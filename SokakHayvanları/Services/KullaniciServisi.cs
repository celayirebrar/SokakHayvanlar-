
using System.Data.SqlClient;
using SokakHayvanlari.Data;
using SokakHayvanlari.Models;
using System.Data;

namespace SokakHayvanlari.Services
{
    public class KullaniciServisi
    {
        public void KayitOl(
            string adSoyad,
            string kullaniciAdi,
            string sifre,
            string rol = "Gonullu")
        {
            string hash = SifreServisi.HashOlustur(sifre);

            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                INSERT INTO Kullanicilar
                (AdSoyad, KullaniciAdi, SifreHash, Rol)
                VALUES (@Ad, @Kullanici, @Hash, @Rol)";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Ad", SqlDbType.NVarChar, 100)
                .Value = adSoyad;
            cmd.Parameters.Add("@Kullanici", SqlDbType.NVarChar, 50)
                .Value = kullaniciAdi;
            cmd.Parameters.Add("@Hash", SqlDbType.NVarChar, 200)
                .Value = hash;
            cmd.Parameters.Add("@Rol", SqlDbType.NVarChar, 20)
                .Value = rol;

            cmd.ExecuteNonQuery();
        }

        public Kullanici? GirisYap(
            string kullaniciAdi,
            string sifre)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                SELECT KullaniciID, AdSoyad, KullaniciAdi,
                       SifreHash, Rol, Aktif
                FROM Kullanicilar
                WHERE KullaniciAdi = @Kullanici";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Kullanici",
                SqlDbType.NVarChar, 50).Value = kullaniciAdi;

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            string hash = reader["SifreHash"].ToString()!;
            bool aktif = Convert.ToBoolean(reader["Aktif"]);

            if (!aktif || !SifreServisi.Dogrula(sifre, hash))
                return null;

            return new Kullanici
            {
                KullaniciID = Convert.ToInt32(
                    reader["KullaniciID"]),
                AdSoyad = reader["AdSoyad"].ToString()!,
                KullaniciAdi = reader["KullaniciAdi"].ToString()!,
                Rol = reader["Rol"].ToString()!,
                Aktif = aktif
            };
        }

        
    }
}
