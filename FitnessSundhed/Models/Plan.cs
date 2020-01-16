using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class Plan
    {
        public int Id { get; set; }

        public DayOfWeek Day { get; set; }

        public virtual ApplicationUser User { get; set; }


    }
}