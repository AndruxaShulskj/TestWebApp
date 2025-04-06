using TestWebApp.Common;

namespace TestWebApp.Core
{
    public interface IServiceCreate<in T>
    {
        Task Create(T data);
    }
}
