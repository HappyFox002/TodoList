using Microsoft.AspNetCore.Mvc;
using TESTEfCore.Data;
using TESTEfCore.Models;

namespace TESTEfCore.Controllers
{
    public class RequestController : Controller
    {
        [HttpPost]
        public JsonResult NewTask(string name)
        {
            if (TasksData.AddNewTask(name)) {
                return Json(new RequestStatus() { Status = true });
            }
            return Json(new RequestStatus() { Status = false });
            
        }

        [HttpPost]
        public JsonResult DelTask(string name) {
            if (TasksData.DelTask(name)) {
                return Json(new RequestStatus() { Status = true });
            }
            return Json(new RequestStatus() { Status = false});
        }
    }
}
