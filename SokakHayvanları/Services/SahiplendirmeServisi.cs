using System.Data;
using System.Data.SqlClient;
using SokakHayvanlari.Data;
using SokakHayvanlari.Models;

namespace SokakHayvanlari.Services
{
    public class SahiplendirmeServisi
    {
        // BAŞVURU EKLE
        public void Ekle(Sahiplendirme basvuru)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                INSERT INTO SahiplendirmeBasvurulari
                (HayvanID, GonulluID, BasvuruTarihi, Durum)
                VALUES
                (@HayvanID, @GonulluID, @Tarih, @Durum)";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@HayvanID", SqlDbType.Int)
                .Value = basvuru.HayvanID;

            cmd.Parameters.Add("@GonulluID", SqlDbType.Int)
                .Value = basvuru.GonulluID;

            cmd.Parameters.Add("@Tarih", SqlDbType.DateTime2)
                .Value = basvuru.BasvuruTarihi;

            cmd.Parameters.Add("@Durum", SqlDbType.NVarChar, 30)
                .Value = basvuru.Durum;

            cmd.ExecuteNonQuery();
        }

        // BAŞVURULARI LİSTELE
        public DataTable Listele()
        {
            using var conn = Veritabani.BaglantiOlustur();

            string sql = @"
                SELECT *
                FROM SahiplendirmeBasvurulari
                ORDER BY BasvuruID DESC";

            using var cmd = new SqlCommand(sql, conn);
            using var adapter = new SqlDataAdapter(cmd);

            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            return tablo;
        }

        // BAŞVURU DURUMUNU GÜNCELLE
        public void DurumGuncelle(int basvuruID, string durum)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                UPDATE SahiplendirmeBasvurulari
                SET Durum = @Durum
                WHERE BasvuruID = @ID";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@ID", SqlDbType.Int)
                .Value = basvuruID;

            cmd.Parameters.Add("@Durum", SqlDbType.NVarChar, 30)
                .Value = durum;

            cmd.ExecuteNonQuery();
        }
    }
}