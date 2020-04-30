using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webshop.Web.Models
{
    public class Location
    {
        [Display(Name = "Location ID")]
        [Required]
        [Range(0, 1000000000)]
        public decimal ID { get; set; }

        [Display(Name = "Country")]
        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        [Display(Name = "Street")]
        [Required]
        [StringLength(40)]
        public string Street { get; set; }

        [Display(Name = "House_Number")]
        [Required]
        [Range(0, 10000)]
        public Nullable<decimal> House_Number { get; set; }

        [Display(Name = "Zip_Code")]
        [Required]
        public Nullable<decimal> Zip_Code { get; set; }
    }
}