using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class Recipes
    {
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        [Required]
        [StringLength(100)]
        public string Intruction { get; set; }

        public string Image { get; set; }


        [Required]
        [Display(Name = "Energy(KJ)")]
        public int EnergyKJ { get; set; }


        [Required]
        [Display(Name = "Energy(Cals)")]
        public int EnergyCals { get; set; }

        [Required]
        public double Protein { get; set; }


        [Required]
        public double Fat { get; set; }


        [Required]
        public double Carbs { get; set; }

        [Required]
        public double Sugar { get; set; }

        [Required]
        public double Fiber { get; set; }

        public bool IsChecked { get; set; }

    }
}