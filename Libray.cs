using System;
using System.Collections.Generic;
using System.Data;
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


        public bool GetBookList()
        {
            try
            {
                List<Book> list = new List<Book>();
                sqlConnection.Open();
                string Query = "getbooklist";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        Genre = (string)reader["genre"],
                        Borrowed = (int)reader["borrowed"],
                    };
                    list.Add(book);
                }
                foreach (Book book in list)
                {
                    Console.WriteLine($"Book_id: {book.id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                        $"\t Genre:- {book.Genre}");
                    if (book.Borrowed > 0)
                    {
                        Console.Write("Borrowed : yes");
                    }
                    else
                    {
                        Console.WriteLine("Borrowed : NO");
                    }

                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }


        public int get_total_no_availble_books()
        {
            try
            {
                sqlConnection.Open();
                string query = "NOOFAVABOOKS";
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


        public int NoofBorrowedBooks()
        {
            try
            {
                sqlConnection.Open();
                string query = "NOOFBORROWEDBOOKS";
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

        public bool GetBooksbyAuthor(string input)
        {
            try
            {
                List<Book> list = new List<Book>();
                sqlConnection.Open();
                string Query = "GetBooksByAuthor";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AuthorName", input);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        Genre = (string)reader["genre"],
                        Borrowed = (int)reader["borrowed"],
                    };
                    list.Add(book);
                }
                foreach (Book book in list)
                {
                    Console.WriteLine($"Book_id: {book.id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                        $"\t Genre:- {book.Genre}");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public bool GetBooksbyGenre(string input)
        {
            try
            {
                List<Book> list = new List<Book>();
                sqlConnection.Open();
                string Query = "GetBooksByGenre";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@GenreName", input);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        //Genre = (string)reader["genre"],
                        Borrowed = (int)reader["borrowed"],
                    };
                    list.Add(book);
                }
                foreach (Book book in list)
                {
                    Console.WriteLine($"Book_id: {book.id}\t Title:- {book.Title}\t Author:- {book.Author}");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public bool BorrowebookfromLibrary(string bookTitle)
        {
            try
            {
                sqlConnection.Open();
                string Query = "BorrowBook";
                SqlCommand command = new SqlCommand(Query, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookTitle", bookTitle);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Book borrowed successfully.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
