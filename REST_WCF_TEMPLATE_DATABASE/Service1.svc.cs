using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

//EKSAMEN

namespace REST_WCF_TEMPLATE_DATABASE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private Model1 moviedb = new Model1();

        #region Connection string
        //Data Source=natascha.database.windows.net;Initial Catalog=School;Integrated Security=False;User ID=nataschajakobsen;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        private static string connectingString =
               "Server=tcp:natascha.database.windows.net,1433;Initial Catalog=School;Persist Security Info=False;User ID=nataschajakobsen;Password=Roskilde4000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        #endregion

        #region POST
        public void AddMovie(Movie newMovie)
        {
            SqlConnection conn = new SqlConnection(connectingString); //laver en ny instans af SqlConnection og kalder den conn.
            SqlCommand command = new SqlCommand(); //ny instans af SqlCommand og kalder den command

            command.Connection = conn;
            conn.Open(); //åbnes forbindelsen 

            command.CommandText = @"INSERT INTO Movies(Titel, Rating) 
                                VALUES (@Titel, @Rating)";

            command.Parameters.AddWithValue("@Titel", newMovie.Titel);
            command.Parameters.AddWithValue("@Rating", newMovie.Rating);

            command.ExecuteNonQuery(); //udfører SQL statement "command"
            conn.Close();
        }
        #endregion

        #region DELETE
        public void DeleteMovie(int id)
        {
            SqlConnection conn = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = @"DELETE FROM Movies WHERE Movies.id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion

        #region GET
        public List<Movie> GetMovies()
        {
            List<Movie> liste = new List<Movie>(); //ny instans af movie
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = "SELECT * FROM Movies";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Movie film = new Movie
                    {
                        Id = reader.GetInt32(0),
                        Titel = reader.GetString(1),
                        Rating = reader.GetInt32(2),
                    };
                    liste.Add(film);
                }

            }
            return liste; 
        }
        #endregion

        #region Get One Movie Virker ikke 
        public Movie GetOneMovie(string id)
        {
            int idint = Int32.Parse(id);
            return moviedb.Movies.ToList().Find(c => c.Id == idint);
        }
        #endregion

        #region PUT
        public void UpdateMovie(Movie myMovie, string id)
        {
            SqlConnection conn = new SqlConnection(connectingString);
            SqlCommand command = new SqlCommand();

            command.Connection = conn;
            conn.Open();

            command.CommandText = @"UPDATE Movies 
                                SET Titel = @titel, 
                                    Rating = @rating, 
                                WHERE Movies.Id = @id";

            command.Parameters.AddWithValue("@id", myMovie.Id);
            command.Parameters.AddWithValue("@titel", myMovie.Titel);
            command.Parameters.AddWithValue("@rating", myMovie.Rating);


            command.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
    }
}
