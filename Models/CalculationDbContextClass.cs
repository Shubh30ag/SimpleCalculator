using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public class CalculationDbContextClass : DbContext
    {
        public CalculationDbContextClass(DbContextOptions<CalculationDbContextClass> dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<Calculation> Calculations { get; set; }
    }
}
