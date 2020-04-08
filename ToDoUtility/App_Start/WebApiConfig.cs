using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ToDoUtility
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                            "updateTask",
                            "api/Task/Update/{userToDo}",
                            new { controller = "Task", action = "PutUserToDo", userToDo = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                            "saveTask",
                            "api/Task/Save/{userToDo}",
                            new { controller = "Task", action = "PostUserToDo", userToDo = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                            "deleteTask",
                            "api/Task/Delete/{id}",
                            new { controller = "Task", action = "DeleteUserToDo", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                            "getTasks",
                            "api/Task/GetTasks",
                            new { controller = "Task", action = "GetUserToDo"});
            
            config.Routes.MapHttpRoute(
                            "completeTasks",
                            "api/Task/CompleteTask/{id}",
                            new { controller = "Task", action = "CompleteTask", id = RouteParameter.Optional });

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
