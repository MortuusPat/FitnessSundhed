using FitnessSundhed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessSundhed.ViewModels
{
    public class ShoppingListViewModel
    {
        public List<ShoppingList> ShoppingList { get; set; } = new List<ShoppingList>();

        public List<Ingredients> Ingredients { get; set; } = new List<Ingredients>();
    }
}