using TestWebApp.Common;

namespace TestWebApp.Core
{
    public interface IGetRepository<T> : IDisposable
            where T : class
    {
        T Get(int id); // получение одного объекта по id
    }
}
