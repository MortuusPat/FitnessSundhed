using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class PlanRecipeDistribution
    {
        public int Id { get; set; }

        public Plan Plan { get; set; }

        public Recipes Recipe { get; set; }
    }
}