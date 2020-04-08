using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models.Entities;

namespace ToDo.DataAccess.ServiceInterface
{
    public interface ITaskService : IDeleteService<UserToDo>, IEditService<UserToDo>, IReadService<UserToDo>
    {
        IList<UserToDo> GetTasksByUserID(string UserID);
    }
}