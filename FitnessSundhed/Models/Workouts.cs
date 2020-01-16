using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class Workouts
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Equipment { get; set; }

        public string Targets { get; set; }


    }
    
}