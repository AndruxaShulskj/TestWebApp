using TestWebApp.Common;

namespace TestWebApp.Core
{
    public interface IDeleteRepository<in T> : IDisposable
            where T : class
    {
        void Delete(int id); // удаление объекта по id
    }
}
