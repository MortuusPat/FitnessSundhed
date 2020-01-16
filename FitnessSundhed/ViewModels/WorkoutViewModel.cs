using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessSundhed.Models;
namespace FitnessSundhed.ViewModels
{
    public class WorkoutViewModel
    {
        public Workouts Workout { get; set; }
        public List<Sets> Sets { get; set; } = new List<Sets>();

        public Sets Set { get; set; }
        public List<Execises> Execises { get; set; } = new List<Execises>();

        public Execises Execise { get; set; }
    }
}