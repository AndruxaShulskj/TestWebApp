using TestWebApp.Common;
using TestWebApp.Core;
using TestWebApp.DataAccess.Entities;

namespace TestWebApp.DataAccess.Interfaces
{
    public interface ILogRepository : ICreateRepository<LogEntity>, IGetRepository<LogEntity>, IBaseRepository
    {
        IEnumerable<LogEntity> GetAll(); // получение всех объектов
    }
}
