using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class Sets
    {
        public int Id { get; set; }
        public string SetName { get; set; }
        public string SetDesc { get; set; }

        public int WorkoutsId { get; set; }


    }
}