using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Simple_Calculator.Models
{
    public class Calculator
    {
        [Required(ErrorMessage ="Please enter first Number")]
        [RegularExpression(@"^-?\d+(\.\d+)?$", ErrorMessage ="Please enter a valid Numeric for Number1")]
        public string Number1 { get; set; }

        [Required(ErrorMessage ="Please enter second Number")]
        [RegularExpression(@"^-?\d+(\.\d+)?$", ErrorMessage = "Please enter a valid Numeric for Number2")]//The [RegularExpression] attribute ensures that the input is a valid numeric value. It matches positive, negative, and decimal numbers.
        public string Number2 { get; set; }

        [Required(ErrorMessage = "Please select an operaion")]
        public string Operation { get; set; }
        public double? Result { get; set; }

        public double? GetParsedNumber1()
        {
            return double.TryParse(Number1, out double num1) ? num1 : (double?)null;
        }

        public double? GetParsedNumber2()
        {
            return double.TryParse(Number2, out double num2) ? num2 : (double?)null;
        }


    }
}