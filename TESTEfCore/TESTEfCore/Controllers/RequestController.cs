using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public JsonResult GetPurposes(string name) {
            return Json(new RequestStatus() { Status = true, Response = TasksData.GetPurposes(name)});
        }

        [HttpPost]
        public JsonResult AddPurpose(string name, string taskName, DateTime endTime, string text = "") {
            Purpose p = TasksData.AddPurpose(name, taskName, endTime, text);
            if (p != null)
            {
                return Json(new RequestStatus() { Status = true, Response = TasksData.GetPurposes(p.Id) });
            }
            return Json(new RequestStatus() { Status = false });
        }

        [HttpPost]
        public JsonResult DelPurpose(int id) {
            if (TasksData.DelPurpose(id)) {
                return Json(new RequestStatus() { Status = true});
            }
            return Json(new RequestStatus() { Status = false });
        }

        [HttpPost]
        public JsonResult OverduePurpose(int id) {
            Purpose p = TasksData.ChangePurpose(id, PurposeStatus.OverdueTask);
            if (p != null) {
                return Json(new RequestStatus() { Status = true, Response = TasksData.GetPurposes(p.Id) });
            }
            return Json(new RequestStatus() { Status = false });
        }

        [HttpPost]
        public JsonResult CompletedPurpose(int id)
        {
            Purpose p = TasksData.ChangePurpose(id, PurposeStatus.CompletedTask);
            if (p != null)
            {
                return Json(new RequestStatus() { Status = true, Response = TasksData.GetPurposes(p.Id) });
            }
            return Json(new RequestStatus() { Status = false });
        }
    }
}
