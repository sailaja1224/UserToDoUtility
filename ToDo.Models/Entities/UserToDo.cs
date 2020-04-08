using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models.Entities
{
    public class UserToDo
    {
        public int ID { get; set; }

        public string ToDoName { get; set; }

        public DateTime DueDate { get; set; }

        public bool Status { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public UserToDo()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
