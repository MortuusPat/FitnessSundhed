using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class Workouts
    {
        public int Id { get; set; }

        [Display(Name = "Workout Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Equipment { get; set; }

        [Required]
        [StringLength(100)]
        public string Targets { get; set; }


    }
    
}