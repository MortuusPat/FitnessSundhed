using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessSundhed.Models;
namespace FitnessSundhed.ViewModels
{
    public class PlanViewModel
    {
        public IEnumerable<Plan> Plans { get; set; }

        public IEnumerable<PlanRecipeDistribution> RecipesDistribution { get; set; }

        public IEnumerable<PlanWorkoutDistribution> WorkoutsDistribution { get; set; }

        public IEnumerable<Recipes> Recipes { get; set; }

        public IEnumerable<Workouts> Workouts { get; set; }

        public DayOfWeek RequestedDay { get; set; }
    }
}