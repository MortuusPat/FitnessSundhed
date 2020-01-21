using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }

        public Ingredients IngredientId { get; set; }

        public double Quantity { get; set; }

        public string Measurement { get; set; }

        public bool IsDone { get; set; }

        public virtual ApplicationUser User { get; set; }


    }
}