using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class Sets
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [StringLength(100)]
        public string SetName { get; set; }

        [Required]
        [Display( Name = "Description")]
        [StringLength(100)]
        public string SetDesc { get; set; }

        public int WorkoutsId { get; set; }


    }
}