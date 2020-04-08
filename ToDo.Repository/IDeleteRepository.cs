using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Repository
{
    public interface IDeleteRepository<T>
    {
        void Delete(T item);

        void Delete(int id);
    }
}
