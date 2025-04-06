using TestWebApp.Common;

namespace TestWebApp.Core
{
    public interface IServiceBase<T>
    {
        IEnumerable<T> GetAll(DataFilter? filters);

        T Get(int id);

        T Create(T data);        

        T Edit(T data);

        void Delete(int id);
    }
}
