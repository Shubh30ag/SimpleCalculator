using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Models;

namespace WebCalculatorProject.Controllers
{
    public class CalculatorController : Controller
    {
        private CalculationDbContextClass db;
        public CalculatorController(CalculationDbContextClass calculationDbContextClass)
        {
            db = calculationDbContextClass;
        }
        
        
        public IActionResult Index()
        {
            var calculations = db.Calculations.Select(x => new Calculation
            {
                First_Number = x.First_Number,
                Second_Number = x.Second_Number,
                Operator = x.Operator,
                Result = x.Result
            }).Take(5).ToList();
            
            ViewModel viewModel = new ViewModel() { calculations = calculations };

            return View(viewModel);
        }

        
        public IActionResult Save(decimal nr1, decimal nr2, string operation)
        {
            string error = string.Empty;

            decimal result = 0;
            if (operation == "+")
            {
                result = Add(nr1, nr2);
            }
            else if (operation == "-")
            {
                result = Subtract(nr1, nr2);
            }
            else if (operation == "*")
            {
                result = Multiply(nr1, nr2);
            }
            else if (operation == "/")
            {
                if (nr2 != 0)
                {
                    result = Divide(nr1, nr2);
                }
                else
                {
                    error = " ''Can't divide with 0!'' ";
                    return View("Index", $"{error}");
                }
            }
            Calculation calculation = new Calculation() { First_Number = nr1, Second_Number = nr2, Operator = operation, Result = result};
            db.Calculations.Add(calculation);
            db.SaveChanges();
            var calculations = db.Calculations.Select(x => new Calculation
            {
                First_Number = x.First_Number,
                Second_Number = x.Second_Number,
                Operator = x.Operator,
                Result = x.Result
            }).Take(5).ToList();
            ViewModel viewModel = new ViewModel() { calculation = calculation, calculations = calculations };

            return View("Index", viewModel);
        }

        public IActionResult Calculate(decimal nr1, decimal nr2, string operation)
        {
            string error = string.Empty;
            decimal result = 0;
            if (operation == "+")
            {
                result = Add(nr1, nr2);
            }
            else if (operation == "-")
            {
                result = Subtract(nr1, nr2);
            }
            else if (operation == "*")
            {
                result = Multiply(nr1, nr2);
            }
            else if (operation == "/")
            {
                if (nr2 != 0 )
                {
                    result = Divide(nr1, nr2);
                }
                else
                {
                    error = " ''Can't divide with 0!'' ";
                    return View("Index", $"{error}");
                }
            }
            Calculation calculation = new Calculation() { First_Number = nr1, Second_Number = nr2, Operator = operation, Result = result };
            var calculations = db.Calculations.Select(x => new Calculation
            {
                First_Number = x.First_Number,
                Second_Number = x.Second_Number,
                Operator = x.Operator
            }).Take(5).ToList();
            ViewModel viewModel = new ViewModel() { calculation = calculation, calculations = calculations};

            return View("Index", viewModel);

        }

        private decimal Divide(decimal nr1, decimal nr2)
        {
            return nr1 / nr2;
        }

        private decimal Multiply(decimal nr1, decimal nr2)
        {
            return nr1 * nr2;
        }

        private decimal Subtract(decimal nr1, decimal nr2)
        {
            return nr1 - nr2; ;
        }

        private decimal Add(decimal nr1, decimal nr2)
        {
            return nr1 + nr2;
        }
    }
}