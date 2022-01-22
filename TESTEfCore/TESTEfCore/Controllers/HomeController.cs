using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TESTEfCore.Data;

namespace TESTEfCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Models.Task> tasks = TasksData.GetTasks();
            return View(tasks);
        }
    }
}
