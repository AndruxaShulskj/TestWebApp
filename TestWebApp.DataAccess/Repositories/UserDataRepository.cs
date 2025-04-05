using Microsoft.EntityFrameworkCore;
using TestWebApp.DataAccess.Entities;
using TestWebApp.DataAccess.Interfaces;

namespace TestWebApp.DataAccess.Repositories
{
    public class UserDataRepository: IUserDataRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private bool _disposed;

        public UserDataRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<UserDataEntity> GetAll() => _applicationDbContext.UserDataEntities.AsNoTracking();
        

        public UserDataEntity Get(int id)
        {
            return _applicationDbContext.UserDataEntities.AsNoTracking().Single(k => k.Id==id);
        }

        public void Create(UserDataEntity item)
        {
            _applicationDbContext.UserDataEntities.Add(item);
        }

        public void Update(UserDataEntity item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _applicationDbContext.UserDataEntities.Find(id);
            if (item is not null)
            {
                _applicationDbContext.UserDataEntities.Remove(item);
            }
        }

        public Task SaveAsync()
        {
            return _applicationDbContext.SaveChangesAsync();
        }

        public Task<int> DeleteAll()
        {
            return _applicationDbContext.UserDataEntities.ExecuteDeleteAsync();
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
    }
}
