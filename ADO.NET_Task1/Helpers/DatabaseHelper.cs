using ADO.NET_Task1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADO.NET_Task1.Helpers
{
    public class DatabaseHelper
    {
        public static List<Author> GetAuthorsFromDb()
        {
            var authors = new List<Author>();
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString =
                    ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                conn.Open();

                SqlDataReader reader = null;
                string query = "SELECT * FROM Authors";

                using (var cmd = new SqlCommand(query, conn))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var author = new Author()
                        {
                            Id = reader[0].ToString(),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                        };
                        authors.Add(author);
                    }
                }
            }
            App.CurrentAuthors = authors;
            return authors;
        }

        public static void DeleteAuthorsByID(List<string> IDs)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString =
                   ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                conn.Open();

                string s = IDs.Aggregate((i, j) => i + "," + j).ToString();

                string query = $"DELETE FROM S_Cards WHERE Id_Book IN (SELECT Id FROM Books WHERE Id_Author IN ({s}));" +
                                $"DELETE FROM T_Cards WHERE Id_Book IN (SELECT Id FROM Books WHERE Id_Author IN ({s}));" +
                                $"DELETE FROM Books WHERE Id_Author IN ({s});" +
                                $"DELETE FROM Authors WHERE Id IN ({s});";


                using (var cmd = new SqlCommand(query, conn))
                {
                        //cmd.Parameters.Add(paramId);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public static void EditAuthorsByID(string Id, string firstname, string lastname)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString =
                  ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                conn.Open();

                string query = $"UPDATE Authors Set FirstName='{firstname}',Lastname='{lastname}' WHERE ID={Id}";


                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public static void AddAuthorToDatabase(Author author)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString =
                  ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                conn.Open();

                string query = $"INSERT INTO Authors ([Id],[FirstName],[LastName]) " +
                               $"VALUES('{author.Id}','{author.FirstName}','{author.LastName}')";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
