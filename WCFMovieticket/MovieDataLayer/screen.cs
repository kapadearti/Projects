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
    
    public partial class screen
    {
        public screen()
        {
            this.movies = new HashSet<movie>();
            this.seats = new HashSet<seat>();
        }
    
        public int screenID { get; set; }
        public string screenName { get; set; }
    
        public virtual ICollection<movie> movies { get; set; }
        public virtual ICollection<seat> seats { get; set; }
    }
}