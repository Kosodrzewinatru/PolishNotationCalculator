using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Polish_Notation_Calculator.Models;

namespace Polish_Notation_Calculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate([FromForm] Calculate calculate)
        {
            string infixExpression = calculate.ToInfix();
            double result = calculate.calcInfix();
            ViewData["otherFix"] = infixExpression;
            ViewData["result"] = result;
            return View("Result");
        }

        public IActionResult CalculateTrue([FromForm] Calculate calculate)
        {
            string postfixExpression = calculate.toPostfix();
            string result = calculate.calcPostfix();
            ViewData["otherFix"] = postfixExpression;
            ViewData["result"] = result;
            return View("Result");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
