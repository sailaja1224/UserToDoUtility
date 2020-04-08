using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models.Entities;

namespace ToDo.Repository.iRepo
{
    public interface ITaskRepository : IReadRepository<UserToDo>, IEditRepository<UserToDo>, IDeleteRepository<UserToDo>
    {
        IList<UserToDo> GetTasksByUserID(string UserID);
    }
}
