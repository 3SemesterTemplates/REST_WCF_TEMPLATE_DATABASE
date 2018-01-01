using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace REST_WCF_TEMPLATE_DATABASE
{
    [DataContract]
    public class Movie
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Titel { get; set; }

        [DataMember]
        public int Rating { get; set; }



        public Movie()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Titel: {Titel}, Rating: {Rating}";
        }
    }
}