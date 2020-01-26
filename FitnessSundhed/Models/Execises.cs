using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessSundhed.Models
{
    public class Execises
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Reps { get; set; }

        [Required]
        [StringLength(100)]
        public string Note { get; set; }

        public int SetsId { get; set; }

    }
}