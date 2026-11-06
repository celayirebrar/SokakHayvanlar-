using System;
using System.Data;
using System.Data.SqlClient;
using SokakHayvanlari.Data;
using SokakHayvanlari.Models;

namespace SokakHayvanlari.Services
{
    public class GonulluServisi
    {
        // 1. GÖNÜLLÜ EKLE
        public void Ekle(Gonullu gonullu)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                INSERT INTO Gonulluler
                (KullaniciID, AdSoyad, Telefon, Email, Adres, GonullulukDurumu)
                VALUES
                (@KullaniciID, @AdSoyad, @Telefon, @Email, @Adres, @Durum)";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@KullaniciID", SqlDbType.Int)
                .Value = gonullu.KullaniciID.HasValue
                    ? (object)gonullu.KullaniciID.Value
                    : DBNull.Value;

            cmd.Parameters.Add("@AdSoyad", SqlDbType.NVarChar, 100)
                .Value = gonullu.AdSoyad;

            cmd.Parameters.Add("@Telefon", SqlDbType.NVarChar, 20)
                .Value = gonullu.Telefon;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100)
                .Value = gonullu.Email;

            cmd.Parameters.Add("@Adres", SqlDbType.NVarChar, 250)
                .Value = gonullu.Adres;

            cmd.Parameters.Add("@Durum", SqlDbType.NVarChar, 30)
                .Value = gonullu.GonullulukDurumu;

            cmd.ExecuteNonQuery();
        }

        // 2. GÖNÜLLÜLERİ LİSTELE
        public DataTable Listele()
        {
            using var conn = Veritabani.BaglantiOlustur();

            string sql = @"
                SELECT *
                FROM Gonulluler
                ORDER BY GonulluID DESC";

            using var cmd = new SqlCommand(sql, conn);
            using var adapter = new SqlDataAdapter(cmd);

            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            return tablo;
        }

        // 3. GÖNÜLLÜ GÜNCELLE
        public void Guncelle(Gonullu gonullu)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                UPDATE Gonulluler SET
                    KullaniciID = @KullaniciID,
                    AdSoyad = @AdSoyad,
                    Telefon = @Telefon,
                    Email = @Email,
                    Adres = @Adres,
                    GonullulukDurumu = @Durum
                WHERE GonulluID = @GonulluID";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@GonulluID", SqlDbType.Int)
                .Value = gonullu.GonulluID;

            cmd.Parameters.Add("@KullaniciID", SqlDbType.Int)
                .Value = gonullu.KullaniciID.HasValue
                    ? (object)gonullu.KullaniciID.Value
                    : DBNull.Value;

            cmd.Parameters.Add("@AdSoyad", SqlDbType.NVarChar, 100)
                .Value = gonullu.AdSoyad;

            cmd.Parameters.Add("@Telefon", SqlDbType.NVarChar, 20)
                .Value = gonullu.Telefon;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100)
                .Value = gonullu.Email;

            cmd.Parameters.Add("@Adres", SqlDbType.NVarChar, 250)
                .Value = gonullu.Adres;

            cmd.Parameters.Add("@Durum", SqlDbType.NVarChar, 30)
                .Value = gonullu.GonullulukDurumu;

            cmd.ExecuteNonQuery();
        }

        // 4. GÖNÜLLÜ SİL
        public void Sil(int gonulluID)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                DELETE FROM Gonulluler
                WHERE GonulluID = @GonulluID";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@GonulluID", SqlDbType.Int)
                .Value = gonulluID;

            cmd.ExecuteNonQuery();
        }

        public int GonulluIDGetirVeyaOlustur(int kullaniciID, string adSoyad)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string kontrolSql = @"
        SELECT GonulluID
        FROM Gonulluler
        WHERE KullaniciID = @KullaniciID";

            using var kontrolCmd = new SqlCommand(kontrolSql, conn);
            kontrolCmd.Parameters.Add("@KullaniciID", SqlDbType.Int).Value = kullaniciID;

            object sonuc = kontrolCmd.ExecuteScalar();

            if (sonuc != null && sonuc != DBNull.Value)
                return Convert.ToInt32(sonuc);

            string ekleSql = @"
        INSERT INTO Gonulluler
        (KullaniciID, AdSoyad, Telefon, Email, Adres, GonullulukDurumu)
        VALUES
        (@KullaniciID, @AdSoyad, N'', N'', N'', N'Aktif');

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using var ekleCmd = new SqlCommand(ekleSql, conn);

            ekleCmd.Parameters.Add("@KullaniciID", SqlDbType.Int).Value = kullaniciID;
            ekleCmd.Parameters.Add("@AdSoyad", SqlDbType.NVarChar, 100).Value = adSoyad;

            return Convert.ToInt32(ekleCmd.ExecuteScalar());
        }

    }
}