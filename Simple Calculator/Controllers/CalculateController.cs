using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Simple_Calculator.Models;

namespace Simple_Calculator.Controllers
{
    public class CalculateController : Controller
    {
        // GET: Calculate
        public ActionResult Index()
        {
            return View(new Calculator());//The purpose of passing new CalculatorModel() to the view is to provide the view with a strongly-typed model instance that: Enables binding of input fields to model properties.

        }
        [HttpPost]

        public ActionResult Index(Calculator calculator_obj)
        {
            double? num1 = null; // Declare num1 and num2 outside
            double? num2 = null;

            if (ModelState.IsValid)
            {
                num1 = calculator_obj.GetParsedNumber1();
                num2 = calculator_obj.GetParsedNumber2();

            }
            if(num1 == null || num2 == null)
            {
                if (num1 == null)
                {
                    ModelState.AddModelError("Number1", "Please enter a valid numeric value for Number 1.");
                }if (num2 == null)
                {
                    ModelState.AddModelError("Number2", "Please enter a valid numeric value for Number 1.");
                }
            }
            // Perform the calculation
            switch (calculator_obj.Operation)
            {
                case "Add":
                    calculator_obj.Result = num1 + num2;
                    break;
                case "Subtract":
                    calculator_obj.Result = num1 - num2;
                    break;
                case "Multiply":
                    calculator_obj.Result = num1 * num2;
                    break;
                case "Divide":
                    if (num2 != 0)
                        calculator_obj.Result = num1 / num2;
                    else
                        ModelState.AddModelError("Number2", "Division by zero is not allowed.");
                    break;
                default:
                    ModelState.AddModelError("Operation", "Invalid operation.");
                    break;
            }
            return View(calculator_obj);
        }

    }
}