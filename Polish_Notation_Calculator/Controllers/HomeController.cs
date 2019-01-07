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

        public IActionResult Calculate([FromForm] Calculate calculate, Check check)
        {
            if (check.ifLetter())
            {
                string infixExpression = calculate.toInfix();
                double result = calculate.calcInfix();
                ViewData["otherFix"] = "Expression: " + infixExpression;
                ViewData["result"] = "Result: " + result;
                return View("Index");
            }
            else
            {
                ViewData["error"] = "Error! Letters are not allowed!";
                return View("Index");
            }
        }

        public IActionResult CalculateTrue([FromForm] Calculate calculate, Check check)
        {
            if (check.ifLetterTrue())
            {
                string postfixExpression = calculate.toPostfix();
                string result = calculate.calcPostfix();
                ViewData["otherFix"] = "Expression: " + postfixExpression;
                ViewData["result"] = "Result: " + result;
                return View("Index");
            }
            else
            {
                ViewData["error"] = "Error! Letters are not allowed!";
                return View("Index");
            }
        }

        public IActionResult Clear()
        {
            ViewData["otherFix"] = "";
            ViewData["result"] = "";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
