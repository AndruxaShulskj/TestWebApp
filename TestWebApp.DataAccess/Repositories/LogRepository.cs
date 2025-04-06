using Microsoft.EntityFrameworkCore;
using TestWebApp.Common;
using TestWebApp.DataAccess.Entities;
using TestWebApp.DataAccess.Interfaces;

namespace TestWebApp.DataAccess.Repositories
{
    public class LogRepository : ILogRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private bool _disposed;

        public LogRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public void Create(LogEntity item)
        {
            _applicationDbContext.LogEntities.Add(item);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<LogEntity> GetAll() => _applicationDbContext.LogEntities.AsNoTracking();

        public LogEntity Get(int id)
        {
            return _applicationDbContext.LogEntities.AsNoTracking().Single(k => k.Id == id);
        }

        public Task SaveAsync()
        {
            return _applicationDbContext.SaveChangesAsync();
        }
    }
}
