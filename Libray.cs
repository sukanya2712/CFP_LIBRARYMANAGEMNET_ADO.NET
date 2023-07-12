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

        public bool AddBooktoLibrary(Book book)
        {
            try
            {
                sqlConnection.Open();
                string query = "AddBooks";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue("@id", book.id);
                sqlCommand.Parameters.AddWithValue("@title", book.Title);
                sqlCommand.Parameters.AddWithValue("@author", book.Author);
                sqlCommand.Parameters.AddWithValue("@genre", book.Genre);
                sqlCommand.Parameters.AddWithValue("@borrowed", 0);
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine($"{result} number of rows affected in Contact Table");
                    sqlConnection.Close();
                    return true;
                }
                else
                {
                    sqlConnection.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public int GetTotalNoofBooks()
        {
            try
            {
                sqlConnection.Open();
                string query = "getbooks";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                int result = Convert.ToInt32(sqlCommand.ExecuteScalar());

                sqlConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sqlConnection.Close();
            }

            return 0;
        }

    }
}
