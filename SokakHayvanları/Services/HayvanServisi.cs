using System;
using System.Data;
using System.Data.SqlClient;
using SokakHayvanlari.Data;
using SokakHayvanlari.Models;

namespace SokakHayvanlari.Services
{
    public class HayvanServisi
    {
        // 1. HAYVAN EKLEME
        public void Ekle(Hayvan hayvan)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                INSERT INTO Hayvanlar
                (Ad, Tur, Cinsiyet, Yas, Konum,
                 SaglikDurumu, SahiplendirmeDurumu, Fotograf)
                VALUES
                (@Ad, @Tur, @Cinsiyet, @Yas, @Konum,
                 @Saglik, @Durum, @Fotograf)";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@Ad", SqlDbType.NVarChar, 80)
                .Value = hayvan.Ad;

            cmd.Parameters.Add("@Tur", SqlDbType.NVarChar, 20)
                .Value = hayvan.Tur;

            cmd.Parameters.Add("@Cinsiyet", SqlDbType.NVarChar, 15)
                .Value = string.IsNullOrWhiteSpace(hayvan.Cinsiyet)
                    ? DBNull.Value : hayvan.Cinsiyet;

            cmd.Parameters.Add("@Yas", SqlDbType.Int)
                .Value = hayvan.Yas.HasValue
                    ? hayvan.Yas.Value : DBNull.Value;

            cmd.Parameters.Add("@Konum", SqlDbType.NVarChar, 200)
                .Value = string.IsNullOrWhiteSpace(hayvan.Konum)
                    ? DBNull.Value : hayvan.Konum;

            cmd.Parameters.Add("@Saglik", SqlDbType.NVarChar, 200)
                .Value = string.IsNullOrWhiteSpace(hayvan.SaglikDurumu)
                    ? DBNull.Value : hayvan.SaglikDurumu;

            cmd.Parameters.Add("@Durum", SqlDbType.NVarChar, 30)
                .Value = hayvan.SahiplendirmeDurumu;

            cmd.Parameters.Add("@Fotograf", SqlDbType.NVarChar, 500)
                .Value = string.IsNullOrWhiteSpace(hayvan.Fotograf)
                    ? DBNull.Value : hayvan.Fotograf;

            cmd.ExecuteNonQuery();
        }

        // 2. HAYVANLARI LİSTELEME
        public DataTable Listele()
        {
            using var conn = Veritabani.BaglantiOlustur();

            string sql = @"
                SELECT *
                FROM Hayvanlar
                ORDER BY HayvanID DESC";

            using var cmd = new SqlCommand(sql, conn);
            using var adapter = new SqlDataAdapter(cmd);

            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            return tablo;
        }

        // 3. HAYVAN GÜNCELLEME
        public void Guncelle(Hayvan hayvan)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                UPDATE Hayvanlar SET
                    Ad = @Ad,
                    Tur = @Tur,
                    Cinsiyet = @Cinsiyet,
                    Yas = @Yas,
                    Konum = @Konum,
                    SaglikDurumu = @Saglik,
                    SahiplendirmeDurumu = @Durum,
                    Fotograf = @Fotograf
                WHERE HayvanID = @HayvanID";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@HayvanID", SqlDbType.Int)
                .Value = hayvan.HayvanID;

            cmd.Parameters.Add("@Ad", SqlDbType.NVarChar, 80)
                .Value = hayvan.Ad;

            cmd.Parameters.Add("@Tur", SqlDbType.NVarChar, 20)
                .Value = hayvan.Tur;

            cmd.Parameters.Add("@Cinsiyet", SqlDbType.NVarChar, 15)
                .Value = string.IsNullOrWhiteSpace(hayvan.Cinsiyet)
                    ? DBNull.Value : hayvan.Cinsiyet;

            cmd.Parameters.Add("@Yas", SqlDbType.Int)
                .Value = hayvan.Yas.HasValue
                    ? hayvan.Yas.Value : DBNull.Value;

            cmd.Parameters.Add("@Konum", SqlDbType.NVarChar, 200)
                .Value = string.IsNullOrWhiteSpace(hayvan.Konum)
                    ? DBNull.Value : hayvan.Konum;

            cmd.Parameters.Add("@Saglik", SqlDbType.NVarChar, 200)
                .Value = string.IsNullOrWhiteSpace(hayvan.SaglikDurumu)
                    ? DBNull.Value : hayvan.SaglikDurumu;

            cmd.Parameters.Add("@Durum", SqlDbType.NVarChar, 30)
                .Value = hayvan.SahiplendirmeDurumu;

            cmd.Parameters.Add("@Fotograf", SqlDbType.NVarChar, 500)
                .Value = string.IsNullOrWhiteSpace(hayvan.Fotograf)
                    ? DBNull.Value : hayvan.Fotograf;

            cmd.ExecuteNonQuery();
        }

        // 4. HAYVAN SİLME
        public void Sil(int hayvanID)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                DELETE FROM Hayvanlar
                WHERE HayvanID = @HayvanID";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@HayvanID", SqlDbType.Int)
                .Value = hayvanID;

            cmd.ExecuteNonQuery();
        }
    }
}