using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Core;
using TestWebApp.DataAccess.Entities;

namespace TestWebApp.DataAccess.Interfaces
{
    public interface IUserDataRepository: IRepository<UserDataEntity>
    {
        Task<int> DeleteAll();
    }
}
