using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using SevenHabitsTodoApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SevenHabitsTodoApp.Models;

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

        [HttpGet]
        public IActionResult CreateTask()
        {
            List<Category> categories = taskEntryContext.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskEntry taskEntry)
        {
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
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditTask(int taskEntryId)
        {
            //reuse create task as edit form
            ViewBag.Categories = taskEntryContext.Categories.ToList();
            var taskEntry = taskEntryContext.Responses.Single(x => x.TaskID == taskEntryId);
            return View("CreateTask", taskEntry);
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
            else
            {
                ViewBag.Categories = taskEntryContext.Categories.ToList();
                return View("CreateTask");
            }
        }

        [HttpGet]
        public IActionResult DeleteTask(int taskEntryId)
        {
            TaskEntry taskEntry = taskEntryContext.Responses.Single(x => x.TaskID == taskEntryId);

            return View(taskEntry);
        }

        [HttpPost]
        public IActionResult DeleteTask(TaskEntry taskEntry)
        {
            taskEntryContext.Responses.Remove(taskEntry);
            taskEntryContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
