using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using SevenHabitsTodoApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SevenHabitsTodoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace SevenHabitsTodoApp.Controllers
{
    public class HomeController : Controller
    {

        private TaskEntryContext taskEntryContext;

        //TODO: assign taskContext in constructor
        public HomeController(TaskEntryContext tc)
        {
            taskEntryContext = tc;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quadrant()
        {
            return View();
        }

        public IActionResult TaskList()
        {
            var tasks = taskEntryContext.Responses.Include(x => x.CategoryName).ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            ViewBag.categories = taskEntryContext.Categories.ToList();
            
            return View("TaskApplication");
        }

        [HttpPost]
        public IActionResult CreateTask(TaskEntry taskEntry)
        {
            ViewBag.New = true; //set this variable to indicate that you are adding new task not from the seeded databse
            if (ModelState.IsValid)
            {
                taskEntryContext.Add(taskEntry);
                taskEntryContext.SaveChanges();
                // change this next line to whatever page we want the user to be redirected to
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = taskEntryContext.Categories.ToList();
                return View("TaskApplication");
            }
        }

        [HttpGet]
        public IActionResult EditTask(int taskid)
        {
            //reuse create task as edit form
            ViewBag.Categories = taskEntryContext.Categories.ToList();
            var taskEntry = taskEntryContext.Responses.Single(x => x.TaskID == taskid);
            return View("TaskApplication", taskEntry);
        }

        [HttpPost]
        public IActionResult EditTask(TaskEntry taskEntry)
        {
            if (ModelState.IsValid)
            {
                taskEntryContext.Update(taskEntry);
                taskEntryContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.New = false;
            
            ViewBag.Categories = taskEntryContext.Categories.ToList();
            return View("TaskList");
            
        }

        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            var taskEntry = taskEntryContext.Responses.Single(x => x.TaskID == taskid);

            return View(taskEntry);
        }

        [HttpPost]
        public IActionResult DeleteTask(TaskEntry taskEntry)
        {
            taskEntryContext.Responses.Remove(taskEntry);
            taskEntryContext.SaveChanges();
            return RedirectToAction("TaskList");
        }
    }
}
