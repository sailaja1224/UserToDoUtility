using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models.Context;
using ToDo.Models.Entities;
using ToDo.Repository.iRepo;

namespace ToDo.Repository.Repo
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoContext _context;

        public TaskRepository(ToDoContext context)
        {
            _context = context;
        }

        public void Delete(UserToDo item)
        {
            UserToDo toDo = GetItem(item.ID);
            toDo.IsDeleted = true;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            UserToDo toDo = GetItem(id);
            toDo.IsDeleted = true;
            _context.SaveChanges();
        }

        public UserToDo GetItem(int id)
        {
            return _context.UserToDos.Where(x => x.ID == id && !x.IsDeleted).FirstOrDefault();
        }

        public IList<UserToDo> GetItems()
        {
            return _context.UserToDos.Where(x => !x.IsDeleted).ToList();
        }

        public IList<UserToDo> GetTasksByUserID(string UserID)
        {
            return _context.UserToDos.Where(x => x.CreatedBy == UserID && !x.IsDeleted).ToList();
        }

        public void SaveItem(UserToDo item)
        {
            _context.UserToDos.Add(item);
            _context.SaveChanges();
        }

        public void SaveItems(IList<UserToDo> items)
        {
            foreach(UserToDo userToDo in items)
            {
                _context.UserToDos.Add(userToDo);
            }
            _context.SaveChanges();
        }

        public void UpdateItem(UserToDo item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.Entry(item).Property(x => x.CreatedBy).IsModified = false;
            _context.Entry(item).Property(x => x.CreatedDate).IsModified = false;

            _context.SaveChanges();
        }
    }
}