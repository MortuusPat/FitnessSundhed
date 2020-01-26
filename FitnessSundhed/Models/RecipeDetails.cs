using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class RecipeDetails
    {
        public int Id { get; set; }

        public Recipes Recipe { get; set; }

        public Ingredients Ingredient { get; set; }


        [Required]
        public double Quantity { get; set; }


        [Required]
        public string Measurement { get; set; }
    }
}