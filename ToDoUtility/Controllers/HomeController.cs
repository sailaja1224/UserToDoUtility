using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.DataAccess.ServiceInterface;
using ToDo.Models.Entities;
using Microsoft.AspNet.Identity;

namespace ToDoUtility.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;

        public HomeController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public ActionResult Index()
        {
            List<UserToDo> userTasks = _taskService.GetTasksByUserID(User.Identity.GetUserId()).ToList();
            return View(userTasks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}