using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDoner.Models
{
    public class Donor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "required")]
        public string Name { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "required")]
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "required")]
        public DateTime Date { get; set; }
        public string Created_Emp { get; set; }
    }
}