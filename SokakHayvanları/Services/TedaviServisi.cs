using System.Data;
using System.Data.SqlClient;
using SokakHayvanlari.Data;
using SokakHayvanlari.Models;

namespace SokakHayvanlari.Services
{
    public class TedaviServisi
    {
        // TEDAVİ EKLE
        public void Ekle(Tedavi tedavi)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                INSERT INTO Tedaviler
                (HayvanID, Veteriner, Teshis, Tedavi, Tarih)
                VALUES
                (@HayvanID, @Veteriner, @Teshis, @Tedavi, @Tarih)";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@HayvanID", SqlDbType.Int)
                .Value = tedavi.HayvanID;

            cmd.Parameters.Add("@Veteriner", SqlDbType.NVarChar, 100)
                .Value = tedavi.Veteriner;

            cmd.Parameters.Add("@Teshis", SqlDbType.NVarChar, 300)
                .Value = tedavi.Teshis;

            cmd.Parameters.Add("@Tedavi", SqlDbType.NVarChar, 500)
                .Value = tedavi.TedaviAciklamasi;

            cmd.Parameters.Add("@Tarih", SqlDbType.Date)
                .Value = tedavi.Tarih;

            cmd.ExecuteNonQuery();
        }

        // TEDAVİLERİ LİSTELE
        public DataTable Listele()
        {
            using var conn = Veritabani.BaglantiOlustur();

            string sql = @"
                SELECT *
                FROM Tedaviler
                ORDER BY TedaviID DESC";

            using var cmd = new SqlCommand(sql, conn);
            using var adapter = new SqlDataAdapter(cmd);

            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            return tablo;
        }

        // TEDAVİ BİLGİLERİNİ GÜNCELLE
        public void Guncelle(Tedavi tedavi)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                UPDATE Tedaviler SET
                    HayvanID = @HayvanID,
                    Veteriner = @Veteriner,
                    Teshis = @Teshis,
                    Tedavi = @Tedavi,
                    Tarih = @Tarih
                WHERE TedaviID = @ID";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@ID", SqlDbType.Int)
                .Value = tedavi.TedaviID;

            cmd.Parameters.Add("@HayvanID", SqlDbType.Int)
                .Value = tedavi.HayvanID;

            cmd.Parameters.Add("@Veteriner", SqlDbType.NVarChar, 100)
                .Value = tedavi.Veteriner;

            cmd.Parameters.Add("@Teshis", SqlDbType.NVarChar, 300)
                .Value = tedavi.Teshis;

            cmd.Parameters.Add("@Tedavi", SqlDbType.NVarChar, 500)
                .Value = tedavi.TedaviAciklamasi;

            cmd.Parameters.Add("@Tarih", SqlDbType.Date)
                .Value = tedavi.Tarih;

            cmd.ExecuteNonQuery();
        }
    }
}