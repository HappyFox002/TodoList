using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTEfCore.Data;

namespace TESTEfCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<TESTEfCore.Models.Task> tasks = TasksData.GetTasks();
            return View(tasks);
        }

        public IActionResult NewTask(string name) {
            TasksData.AddNewTask(name);
            return RedirectPermanent("~/Home/Index");
        }
    }
}
