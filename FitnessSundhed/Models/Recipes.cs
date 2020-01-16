using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class Recipes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Intruction { get; set; }

        public string Image { get; set; }

        public int EnergyKJ { get; set; }

        public int EnergyCals { get; set; }

        public double Protein { get; set; }

        public double Fat { get; set; }

        public double Carbs { get; set; }

        public double Sugar { get; set; }

        public double Fiber { get; set; }

    }
}