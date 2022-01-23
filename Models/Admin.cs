using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDoner.Models
{
    public class Admin
    {
        public string Empname { get; set; }
        [Required(ErrorMessage = "required*")]
        public string  Email{ get; set; }
        [Required(ErrorMessage = "required*")]
        [DataType(DataType.Password)]
        public string  Password{ get; set; }
        public string  ConatctNo{ get; set; }
    }
}