//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieDataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class booking
    {
        public int bookingID { get; set; }
        public string bookPersonname { get; set; }
        public System.DateTime bookingDate { get; set; }
        public int seatid { get; set; }
        public int movieid { get; set; }
        public string paymentStatusID { get; set; }
    
        public virtual movie movie { get; set; }
        public virtual seat seat { get; set; }
    }
}