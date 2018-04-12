using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieService.Model
{
    public class BookingModel
    {
        public int bookingID { get; set; }
        public string bookPersonname { get; set; }
        public System.DateTime bookingDate { get; set; }
        public int seatid { get; set; }
        public int movieid { get; set; }
        public string paymentStatusID { get; set; }


    }
}