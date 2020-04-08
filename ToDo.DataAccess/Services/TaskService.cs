using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccess.ServiceInterface;
using ToDo.Models.Entities;
using ToDo.Repository.iRepo;

namespace ToDo.DataAccess.Services
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public void Delete(UserToDo item)
        {
            _repository.Delete(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public UserToDo GetItem(int id)
        {
            return _repository.GetItem(id);
        }

        public IList<UserToDo> GetItems()
        {
            return _repository.GetItems();
        }

        public IList<UserToDo> GetTasksByUserID(string UserID)
        {
            return _repository.GetTasksByUserID(UserID);
        }

        public void SaveItem(UserToDo item)
        {
            _repository.SaveItem(item);
        }

        public void SaveItems(IList<UserToDo> items)
        {
            _repository.SaveItems(items);
        }

        public void UpdateItem(UserToDo item)
        {
            _repository.UpdateItem(item);
        }
    }
}
