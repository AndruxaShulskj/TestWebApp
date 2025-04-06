using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Business.Models;
using TestWebApp.Core;

namespace TestWebApp.Business.Interfaces
{
    public interface IUserDataService: IServiceBase<UserData>
    {
        Task CreateAsync(IEnumerable<UserData> list);
    }
}
