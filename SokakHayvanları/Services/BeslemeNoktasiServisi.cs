using System;
using System.Data;
using System.Data.SqlClient;
using SokakHayvanlari.Data;
using SokakHayvanlari.Models;

namespace SokakHayvanlari.Services
{
    public class BeslemeNoktasiServisi
    {
        // EKLE
        public void Ekle(BeslemeNoktasi nokta)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                INSERT INTO BeslemeNoktalari
                (NoktaAdi, Konum, Enlem, Boylam,
                 MamaDurumu, SuDurumu, SonBeslemeTarihi,
                 Aciklama, Aktif)
                VALUES
                (@Ad, @Konum, @Enlem, @Boylam,
                 @Mama, @Su, @Tarih, @Aciklama, @Aktif)";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@Ad", SqlDbType.NVarChar, 100)
                .Value = nokta.NoktaAdi;

            cmd.Parameters.Add("@Konum", SqlDbType.NVarChar, 200)
                .Value = nokta.Konum;

            cmd.Parameters.Add("@Enlem", SqlDbType.Float)
                .Value = nokta.Enlem.HasValue
                    ? (object)nokta.Enlem.Value : DBNull.Value;

            cmd.Parameters.Add("@Boylam", SqlDbType.Float)
                .Value = nokta.Boylam.HasValue
                    ? (object)nokta.Boylam.Value : DBNull.Value;

            cmd.Parameters.Add("@Mama", SqlDbType.NVarChar, 30)
                .Value = nokta.MamaDurumu;

            cmd.Parameters.Add("@Su", SqlDbType.NVarChar, 30)
                .Value = nokta.SuDurumu;

            cmd.Parameters.Add("@Tarih", SqlDbType.DateTime2)
                .Value = nokta.SonBeslemeTarihi.HasValue
                    ? (object)nokta.SonBeslemeTarihi.Value
                    : DBNull.Value;

            cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 500)
                .Value = nokta.Aciklama;

            cmd.Parameters.Add("@Aktif", SqlDbType.Bit)
                .Value = nokta.Aktif;

            cmd.ExecuteNonQuery();
        }

        // LİSTELE
        public DataTable Listele()
        {
            using var conn = Veritabani.BaglantiOlustur();

            string sql = @"
                SELECT *
                FROM BeslemeNoktalari
                ORDER BY NoktaID DESC";

            using var cmd = new SqlCommand(sql, conn);
            using var adapter = new SqlDataAdapter(cmd);

            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            return tablo;
        }

        // GÜNCELLE
        public void Guncelle(BeslemeNoktasi nokta)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                UPDATE BeslemeNoktalari SET
                    NoktaAdi = @Ad,
                    Konum = @Konum,
                    Enlem = @Enlem,
                    Boylam = @Boylam,
                    MamaDurumu = @Mama,
                    SuDurumu = @Su,
                    SonBeslemeTarihi = @Tarih,
                    Aciklama = @Aciklama,
                    Aktif = @Aktif
                WHERE NoktaID = @ID";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@ID", SqlDbType.Int)
                .Value = nokta.NoktaID;

            cmd.Parameters.Add("@Ad", SqlDbType.NVarChar, 100)
                .Value = nokta.NoktaAdi;

            cmd.Parameters.Add("@Konum", SqlDbType.NVarChar, 200)
                .Value = nokta.Konum;

            cmd.Parameters.Add("@Enlem", SqlDbType.Float)
                .Value = nokta.Enlem.HasValue
                    ? (object)nokta.Enlem.Value : DBNull.Value;

            cmd.Parameters.Add("@Boylam", SqlDbType.Float)
                .Value = nokta.Boylam.HasValue
                    ? (object)nokta.Boylam.Value : DBNull.Value;

            cmd.Parameters.Add("@Mama", SqlDbType.NVarChar, 30)
                .Value = nokta.MamaDurumu;

            cmd.Parameters.Add("@Su", SqlDbType.NVarChar, 30)
                .Value = nokta.SuDurumu;

            cmd.Parameters.Add("@Tarih", SqlDbType.DateTime2)
                .Value = nokta.SonBeslemeTarihi.HasValue
                    ? (object)nokta.SonBeslemeTarihi.Value
                    : DBNull.Value;

            cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 500)
                .Value = nokta.Aciklama;

            cmd.Parameters.Add("@Aktif", SqlDbType.Bit)
                .Value = nokta.Aktif;

            cmd.ExecuteNonQuery();
        }

        // SİL
        public void Sil(int noktaID)
        {
            using var conn = Veritabani.BaglantiOlustur();
            conn.Open();

            string sql = @"
                DELETE FROM BeslemeNoktalari
                WHERE NoktaID = @ID";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@ID", SqlDbType.Int)
                .Value = noktaID;

            cmd.ExecuteNonQuery();
        }
    }
}