using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace REST_WCF_TEMPLATE_DATABASE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //HTTP
        //Get all
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "movies")
        ]
        List<Movie> GetMovies();


        //Get by id
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "movie/{id}")
        ]
        Movie GetOneMovie(String id);

        //Post/create
        [WebInvoke(
                Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                //ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "movies")
        ]
        void AddMovie(Movie newMovie);

        //Delete
        [WebInvoke(
                Method = "DELETE",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "movies?id={id}")
        ]
        void DeleteMovie(int id);

        //Update/Put
        [WebInvoke(
               Method = "PUT",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "movies")
       ]
        void UpdateMovie(Movie myMovie, string id);



      
    }


    
}
