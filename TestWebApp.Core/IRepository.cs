using TestWebApp.Common;

namespace TestWebApp.Core
{
    public interface IRepository<T> : IDisposable
            where T : class
    {
        IEnumerable<T> GetAll(DataFilter? filter); // получение всех объектов
        T Get(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        Task SaveAsync();  // сохранение изменений
    }
}
