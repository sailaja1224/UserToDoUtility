using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.DataAccess
{
    public interface IEditService<T>
    {
        void SaveItem(T item);

        void SaveItems(IList<T> items);

        void UpdateItem(T item);
    }
}