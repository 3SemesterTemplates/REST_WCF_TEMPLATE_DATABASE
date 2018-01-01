using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace REST_WCF_TEMPLATE_DATABASE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        #region Connection string
        //Data Source=natascha.database.windows.net;Initial Catalog=School;Integrated Security=False;User ID=nataschajakobsen;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        private static string connectingString =
               "Server=tcp:natascha.database.windows.net,1433;Initial Catalog=School;Persist Security Info=False;User ID=nataschajakobsen;Password=Roskilde4000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        #endregion

        public void AddMovie(Movie newMovie)
        {
            throw new NotImplementedException();
        }

        public Movie DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMovies()
        {
            List<Movie> liste = new List<Movie>();
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

        public Movie GetOneMovie(string id)
        {
            throw new NotImplementedException();
        }

        public Movie UpdateMovie(Movie myMovie)
        {
            throw new NotImplementedException();
        }
    }
}
