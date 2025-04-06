using TestWebApp.Common;

namespace TestWebApp.Core
{
    public interface IBaseRepository : IDisposable
    {
        Task SaveAsync();  // сохранение изменений
    }
}
