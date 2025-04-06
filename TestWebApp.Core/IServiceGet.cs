using TestWebApp.Common;

namespace TestWebApp.Core
{
    public interface IServiceGet<out T>
    {
        T Get(int id);
    }
}
