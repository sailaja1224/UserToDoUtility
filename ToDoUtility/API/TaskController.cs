using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToDo.DataAccess.ServiceInterface;
using ToDo.Models.Context;
using ToDo.Models.Entities;
using Microsoft.AspNet.Identity;

namespace ToDoUtility.API
{
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;
        private ToDoContext db = new ToDoContext();

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Task/5
        [HttpGet]
        public string GetUserToDo()
        {
            Object result = null;
            try
            {
                result = new
                {
                    success = true,
                    data = _taskService.GetTasksByUserID(User.Identity.GetUserId())
                };
            }
            catch (Exception ex)
            {
                result = new
                {
                    success = false,
                    Message = ex.Message
                };
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        // POST: api/Task/Save
        public string PostUserToDo(UserToDo userToDo)
        {
            Object result = null;
            if (!ModelState.IsValid)
            {
                result = new
                {
                    success = false,
                    Message = "Invalid Model!"
                };
            }

            try
            {
                userToDo.CreatedBy = User.Identity.GetUserId();
                _taskService.SaveItem(userToDo);

                result = new
                {
                    success = true,
                    Message = "Task Saved Successfully!"
                };
            }
            catch (Exception ex)
            {
                result = new
                {
                    success = false,
                    Message = ex.Message
                };
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }


        // DELETE: api/Task/Update/
        [HttpPost]
        public string PutUserToDo(UserToDo userToDo)
        {
            Object result = null;
            if (!ModelState.IsValid)
            {
                result = new
                {
                    success = false,
                    Message = "Invalid Model!"
                };
            }

            userToDo.ModifiedBy = User.Identity.GetUserId();

            try
            {
                _taskService.UpdateItem(userToDo);
                result = new
                {
                    success = true,
                    Message = "Task Updated Successfully!"
                };
            }
            catch (Exception ex)
            {
                result = new
                {
                    success = false,
                    Message = ex.Message
                };
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        // DELETE: api/Task/Delete/5
        [HttpDelete]
        public string DeleteUserToDo(int id)
        {
            Object result = null;
            UserToDo userToDo = _taskService.GetItem(id);
            if (userToDo == null)
            {
                result = new
                {
                    success = false,
                    Message = "Task Not Found!"
                };
            }

            try
            {
                _taskService.Delete(id);

                result = new
                {
                    success = true,
                    Message = "Task Deleted Successfully!"
                };
            }
            catch (Exception ex)
            {
                result = new
                {
                    success = false,
                    Message = ex.Message
                };
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPut]
        public string CompleteTask(int id)
        {
            Object result = null;
            if (!ModelState.IsValid)
            {
                result = new
                {
                    success = false,
                    Message = "Invalid Model!"
                };
            }

            UserToDo userToDo = _taskService.GetItem(id);
            userToDo.ModifiedBy = User.Identity.GetUserId();
            userToDo.Status = true;

            try
            {
                _taskService.UpdateItem(userToDo);
                result = new
                {
                    success = true,
                    Message = "Task Completed Successfully!"
                };
            }
            catch (Exception ex)
            {
                result = new
                {
                    success = false,
                    Message = ex.Message
                };
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}