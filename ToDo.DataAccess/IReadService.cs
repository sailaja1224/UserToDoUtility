using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.DataAccess
{
    public interface IReadService<T>
    {
        T GetItem(Int32 id);

        IList<T> GetItems();
    }
}
