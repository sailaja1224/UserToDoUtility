using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Repository
{
    public interface IEditRepository<T>
    {
        void SaveItem(T item);

        void SaveItems(IList<T> items);

        void UpdateItem(T item);
    }
}
