using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieService
{
    public class MovieModel
    {

        public string movieName { get; set; }
        public string language { get; set; }
        public string status { get; set; }
        public string screenName { get; set; }
        public string timeslotDisc { get; set; }
        public DateTime date { get; set; }        
        public int screenID { get; set; }
        public int timeslotID { get; set; }
    }
}