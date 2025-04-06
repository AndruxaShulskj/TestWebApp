using TestWebApp.Common;

namespace TestWebApp.Core
{
    public interface IUpdateRepository<in T> : IDisposable
            where T : class
    {
        void Update(T item); // обновление объекта
    }
}
