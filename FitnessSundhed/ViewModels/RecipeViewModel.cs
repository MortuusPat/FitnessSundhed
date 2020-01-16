using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessSundhed.Models;
namespace FitnessSundhed.ViewModels
{
    public class RecipeViewModel
    {
        public Recipes Recipe { get; set; }
        public IEnumerable<Ingredients> Ingredients { get; set; }

        public List<RecipeDetails> RecipeDetails { get; set; } = new List<RecipeDetails>();

        public RecipeDetails RecipeDetail { get; set; }

    }
}