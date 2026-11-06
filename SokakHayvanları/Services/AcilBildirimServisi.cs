using System.Data;
using System.Data.SqlClient;
using SokakHayvanlari.Data;
using SokakHayvanlari.Models;

namespace SokakHayvanlari.Services
{
    public class AcilBildirimServisi
    {
        // BİLDİRİM EKLE
        public void Ekle(AcilBildirim bildirim)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                INSERT INTO AcilBildirimler
                (HayvanID, Konum, Aciklama, Tarih, Durum)
                VALUES
                (@HayvanID, @Konum, @Aciklama, @Tarih, @Durum)";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@HayvanID", SqlDbType.Int)
                .Value = bildirim.HayvanID;

            cmd.Parameters.Add("@Konum", SqlDbType.NVarChar, 200)
                .Value = bildirim.Konum;

            cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 500)
                .Value = bildirim.Aciklama;

            cmd.Parameters.Add("@Tarih", SqlDbType.DateTime2)
                .Value = bildirim.Tarih;

            cmd.Parameters.Add("@Durum", SqlDbType.NVarChar, 30)
                .Value = bildirim.Durum;

            cmd.ExecuteNonQuery();
        }

        // BİLDİRİMLERİ LİSTELE
        public DataTable Listele()
        {
            using var conn = Veritabani.BaglantiOlustur();

            string sql = @"
                SELECT *
                FROM AcilBildirimler
                ORDER BY BildirimID DESC";

            using var cmd = new SqlCommand(sql, conn);
            using var adapter = new SqlDataAdapter(cmd);

            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            return tablo;
        }

        // BİLDİRİM DURUMUNU GÜNCELLE
        public void DurumGuncelle(int bildirimID, string durum)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                UPDATE AcilBildirimler
                SET Durum = @Durum
                WHERE BildirimID = @ID";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@ID", SqlDbType.Int)
                .Value = bildirimID;

            cmd.Parameters.Add("@Durum", SqlDbType.NVarChar, 30)
                .Value = durum;

            cmd.ExecuteNonQuery();
        }
    }
}