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
    
    public partial class Enrollment
    {
        public int Id_Enrollment { get; set; }
        public int Id_Subject { get; set; }
        public int Id_Student { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}