using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class PlanWorkoutDistribution
    {
        public int Id { get; set; }

        public Plan Plan { get; set; }

        public Workouts Workout { get; set; }
    }
}