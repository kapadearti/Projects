using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieService.Model
{
    public class SeatModel
    {
        public int seatID { get; set; }
        public int seatNumber { get; set; }
        public string Row { get; set; }
        public int screenID { get; set; }
        public string status { get; set; }
        public int price { get; set; }      
    }
}