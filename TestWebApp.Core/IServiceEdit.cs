using TestWebApp.Common;

namespace TestWebApp.Core
{
    public interface IServiceEdit<T>
    {
        T Edit(T data);
    }
}
