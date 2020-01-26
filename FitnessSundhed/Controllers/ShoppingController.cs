using FitnessSundhed.Models;
using FitnessSundhed.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessSundhed.Controllers
{
    public class ShoppingController : Controller
    {
        private ApplicationDbContext _context;
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ShoppingController()
        {
            _context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Shoppinglist")]
        public ActionResult ShoppingList()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var shoppingListInDb = _context.ShoppingListss.ToList();
            var shoppingList = new List<ShoppingList>();
            var viewModel = new ShoppingListViewModel();
            viewModel.Ingredients = _context.Ingredientss.ToList();

            foreach (var item in shoppingListInDb)
            {
                if (item.User == user)
                {
                    shoppingList.Add(item);
                }
            }

            viewModel.ShoppingList = shoppingList;

            return View(viewModel);
        }

        [Route("Shoppinglist/Create")]
        public ActionResult NewList()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var recipesInDb = _context.Recipess.ToList();
            var recipeDistributionInDb = _context.PlanRecipeDistributionss.ToList();
            var planInDb = _context.Planss.ToList();
            var recipes = new List<Recipes>();

            foreach (var plan in planInDb)
            {
                if (plan.User == user)
                {
                    foreach (var distribution in recipeDistributionInDb)
                    {
                        if (distribution.Plan == plan)
                        {
                            recipes.Add(distribution.Recipe);
                        }
                    }
                }
                
            }

            return View(recipes);
        }

        [HttpPost]
        public ActionResult Create(List<Recipes> model)
        {
            List<Recipes> recipes = new List<Recipes>();
            foreach (Recipes recipe in model)
            {
                
                if (recipe.IsChecked == true)
                {
                    recipes.Add(_context.Recipess.Single(c => c.Id == recipe.Id));
                }

            }



            //Find Ingredients

            var shoppingList = new List<ShoppingList>();
            var recipeDetailsInDb = _context.RecipeDetailss.ToList();
            var ingredients = _context.Ingredientss.ToList();

            foreach (var recipe in recipes)
            {
                foreach (var recipeDetails in recipeDetailsInDb)
                {
                    if (recipeDetails.Recipe == recipe)
                    {
                        foreach (var ingredient in ingredients)
                        {
                            if (recipeDetails.Ingredient == ingredient)
                            {
                                var shoppingListItem = new ShoppingList();
                                shoppingListItem.IngredientId = ingredient;
                                shoppingListItem.Measurement = recipeDetails.Measurement;
                                shoppingListItem.Quantity = recipeDetails.Quantity;
                                shoppingList.Add(shoppingListItem);
                            }
                        }
                        
                        

                    }

                }
                
            }

            

            //Add to database
            var user = UserManager.FindById(User.Identity.GetUserId());
            foreach (var item in shoppingList)
            {
                item.User = user;
                _context.ShoppingListss.Add(item);
            }
            _context.SaveChanges();


            return RedirectToAction("ShoppingList", "Shopping");
        }


        public ActionResult ClearList()
        {
            var shoppingList = _context.ShoppingListss.ToList();
            var user = UserManager.FindById(User.Identity.GetUserId());
            foreach (var item in shoppingList)
            {
                if (item.User == user)
                {
                    _context.ShoppingListss.Remove(item);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("ShoppingList", "Shopping");

        }
    }
}