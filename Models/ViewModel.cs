using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public class ViewModel
    {
        public IEnumerable<Calculation> calculations { get; set; }
        public Calculation calculation { get; set; }
    }
}
