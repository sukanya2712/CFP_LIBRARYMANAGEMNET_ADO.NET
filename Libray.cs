using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementAdo
{
    public class Libray
    {
        private string connection = $"Data source= DESKTOP-41GBJMF; Database = LibraryManagement; Integrated Security = true; TrustServerCertificate = true";
        private SqlConnection sqlConnection;
        public Libray()
        {
            sqlConnection = new SqlConnection(connection);
        }
    }
}
