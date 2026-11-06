
using System.Data.SqlClient;

namespace SokakHayvanlari.Data
{
    public static class Veritabani
    {
        private static readonly string connectionString =
            @"Server=(localdb)\MSSQLLocalDB;
              Database=SokakHayvanlariDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public static SqlConnection BaglantiOlustur()
        {
            return new SqlConnection(connectionString);
        }
    }
}
