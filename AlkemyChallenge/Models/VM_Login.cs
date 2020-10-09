using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlkemyChallenge.Models
{
    public class VM_Login //view model class for login
    {
        public int Id_Admin { get; set; }
        public int Id_Student { get; set; }
        [Required][MinLength(3)]
        public string Username { get; set; }
        [Required][MinLength(3)]
        public string Password { get; set; }
        [Required][MinLength(3)]
        public string Dni { get; set; }
        [Required][MinLength(3)]
        public string Docket { get; set; }
        public char Type { get; set; }
    }
}