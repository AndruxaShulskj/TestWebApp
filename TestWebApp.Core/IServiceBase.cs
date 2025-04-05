using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApp.Core
{
    public interface IServiceBase<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        T Create(T data);

        T Edit(T data);

        void Delete(int id);

        Task DeleteAll();

    }
}
