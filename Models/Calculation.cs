using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public class Calculation
    {
        [Key]
        public decimal First_Number { get; set; }
        public decimal Second_Number { get; set; }
        public string Operator { get; set; }
        public decimal Result { get; set; }


    }
}
