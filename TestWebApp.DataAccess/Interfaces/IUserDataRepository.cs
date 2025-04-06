using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Common;
using TestWebApp.Core;
using TestWebApp.DataAccess.Entities;

namespace TestWebApp.DataAccess.Interfaces
{
    public interface IUserDataRepository: IGetRepository<UserDataEntity>, ICreateRepository<UserDataEntity>, IDeleteRepository<UserDataEntity>, IBaseRepository
    {
        IEnumerable<UserDataEntity> GetAll(DataFilter? filter); // получение всех объектов

        Task<int> DeleteAll();
    }
}
