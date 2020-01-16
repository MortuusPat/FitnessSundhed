﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessSundhed.Models;
using FitnessSundhed.ViewModels;

namespace FitnessSundhed.Controllers
{

    public class RecipesController : Controller
    {

        private ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult List()
        {

            var recipes = _context.Recipess.ToList();

            return View(recipes);
        }

        public ActionResult New()
        {
            return View("RecipeForm");
        }

        [HttpPost]
        public ActionResult Create(Recipes model)
        {
            if (model.Id == 0)
            {
                Recipes recipe = new Recipes();
                recipe = model;
                _context.Recipess.Add(recipe);
            }
            else
            {
                var recipeInDb = _context.Recipess.Single(c => c.Id == model.Id);
                recipeInDb.Name = model.Name;
                recipeInDb.Intruction = model.Intruction;
                recipeInDb.Image = model.Image;
                recipeInDb.Protein = model.Protein;
                recipeInDb.Sugar = model.Sugar;
                recipeInDb.Carbs = model.Carbs;
                recipeInDb.EnergyCals = model.EnergyCals;
                recipeInDb.EnergyKJ = model.EnergyKJ;
                recipeInDb.Fat = model.Fat;
                recipeInDb.Fiber = model.Fiber;


            }

            _context.SaveChanges();
            return RedirectToAction("List", "Recipes");
        }


        [Route("recipes/overview/{id}/{name}")]
        public ActionResult Overview(int id, string name)
        {

            var recipe = _context.Recipess.SingleOrDefault(w => w.Id == id);
            var ingredients = _context.Ingredientss.ToList();
            var recipeDetails = _context.RecipeDetailss.ToList();
            RecipeViewModel viewModel = new RecipeViewModel();
            viewModel.Recipe = recipe;
            viewModel.Ingredients = ingredients;
            viewModel.RecipeDetails = recipeDetails;

            if (recipe == null)
            {
                return HttpNotFound();
            }




            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var recipe = _context.Recipess.SingleOrDefault(c => c.Id == id);

            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View("RecipeForm", recipe);
        }

        public ActionResult Delete(int id)
        {
            var recipe = _context.Recipess.SingleOrDefault(c => c.Id == id);
            
            _context.Recipess.Remove(recipe);

            _context.SaveChanges();
            return RedirectToAction("List", "Recipes");
        }


        //Ingredients
        [Route("recipes/ingredients/new")]
        public ActionResult NewIngredient()
        {
            return View("IngredientForm");
        }

        [HttpPost]
        public ActionResult CreateIngredient(Ingredients model)
        {
            Ingredients ingredient = new Ingredients();
            ingredient = model;
            _context.Ingredientss.Add(ingredient);




            _context.SaveChanges();
            return RedirectToAction("ListIngredients", "Recipes");
        }

        [Route("recipes/ingredients/all")]
        public ActionResult ListIngredients()
        {

            var ingredients = _context.Ingredientss.ToList();

            return View(ingredients);
        }

        [HttpPost]
        public ActionResult CreateDetail(RecipeViewModel model)
        {
            var recipeDetail = model.RecipeDetail;
            var recipe = _context.Recipess.SingleOrDefault(c => c.Id == model.Recipe.Id);
            var ingredient = _context.Ingredientss.SingleOrDefault(c => c.Id == model.RecipeDetail.Ingredient.Id);

            recipeDetail.Recipe = recipe;
            recipeDetail.Ingredient = ingredient;
            
            _context.RecipeDetailss.Add(recipeDetail);




            _context.SaveChanges();
            return RedirectToAction("Overview", "Recipes", new { id = recipe.Id, name = recipe.Name });
        }

        public ActionResult DeleteDetail(int id, int recipeId)
        {
            var recipeDetail = _context.RecipeDetailss.SingleOrDefault(c => c.Id == id);
            var recipe = _context.Recipess.SingleOrDefault(c => c.Id == recipeId);
            _context.RecipeDetailss.Remove(recipeDetail);

            _context.SaveChanges();
            return RedirectToAction("Overview", "Recipes", new { id = recipe.Id, name = recipe.Name });
        }


    }
}