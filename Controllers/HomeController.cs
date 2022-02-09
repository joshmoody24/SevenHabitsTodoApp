using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using SevenHabitsTodoApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SevenHabitsTodoApp.Controllers
{
    public class HomeController : Controller
    {

        //TODO: taskContext goes here


        //TODO: assign taskContext in constructor
        public HomeController()
        {

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quadrant()
        {
            return View();
        }

        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateTask()
        {
            return View();
        }

        //TODO: Post method for update task

        [HttpGet]
        public IActionResult DeleteTask()
        {
            return View();
        }

        //TODO: Post method for delete task

    }
}
