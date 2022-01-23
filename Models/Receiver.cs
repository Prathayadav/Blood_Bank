using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDoner.Models
{
    public class Receiver
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "required")]
        public string Name { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Refered_by_Hospital { get; set; }
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "required")]
        public decimal Fees { get; set; }
        public DateTime Date { get; set; }
        public string Created_Emp { get; set; }
    }
}