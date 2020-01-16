using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class RecipeDetails
    {
        public int Id { get; set; }

        public Recipes Recipe { get; set; }

        public Ingredients Ingredient { get; set; }

        public double Quantity { get; set; }

        public string Measurement { get; set; }
    }
}