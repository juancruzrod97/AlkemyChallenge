//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlkemyChallenge.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subject_Schedules
    {
        public int Id_Schedule { get; set; }
        public int Id_Subject { get; set; }
        public int Day { get; set; }
        public System.TimeSpan Time { get; set; }
        public int Duration { get; set; }
    
        public virtual Subject Subject { get; set; }
    }
}
