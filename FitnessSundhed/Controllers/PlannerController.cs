using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessSundhed.Models;
using FitnessSundhed.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitnessSundhed.Controllers
{
    public class PlannerController : Controller
    {


        private ApplicationDbContext _context;

        protected UserManager<ApplicationUser> UserManager { get; set; }

        public PlannerController()
        {
            _context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Planner", "Planner");
        }

        [Route("planner")]
        public ActionResult Planner(DayOfWeek? day)
        {
            
            var userId = User.Identity.GetUserId();
            ApplicationUser user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var dbPlans = _context.Planss.ToList();
            PlanViewModel viewModel = new PlanViewModel();
            List<Plan> plans = new List<Plan>();
            foreach (var plan in dbPlans)
            {
                if (plan.User == user)
                {
                    plans.Add(plan);
                    
                }
            }
            viewModel.Plans = plans;
            viewModel.RecipesDistribution = _context.PlanRecipeDistributionss.ToList();
            viewModel.WorkoutsDistribution = _context.PlanWorkoutDistributionss.ToList();
            viewModel.Recipes = _context.Recipess.ToList();
            viewModel.Workouts = _context.Workoutss.ToList();
            if (day == null)
            {
                viewModel.RequestedDay = DateTime.Now.DayOfWeek;
            }
            else
            {
                viewModel.RequestedDay = day.Value;
            }

            return View(viewModel);






        }

        public ActionResult Create()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());

            DateTime startDate = new DateTime(2020, 1, 6);
            DateTime endDate = new DateTime(2020, 1, 12);
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DayOfWeek dw = date.DayOfWeek;


                //Create day plan
                var plan = new Plan();
                plan.Day = dw;
                plan.User = user;
                _context.Planss.Add(plan);
                

                //Pick random Workout to current plan
                var workoutList = _context.Workoutss.ToList();
                var planWorkout = new PlanWorkoutDistribution();
                planWorkout.Workout = workoutList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                planWorkout.Plan = plan;
                _context.PlanWorkoutDistributionss.Add(planWorkout);

                //Pick random Recipes to current plan
                var recipeList = _context.Recipess.ToList();
                var planRecipe = new PlanRecipeDistribution();
                
                planRecipe.Recipe = recipeList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                planRecipe.Plan = plan;
                _context.PlanRecipeDistributionss.Add(planRecipe);
  
                

            }
            _context.SaveChanges();
            return RedirectToAction("Planner", "Planner");
        }


    }
}