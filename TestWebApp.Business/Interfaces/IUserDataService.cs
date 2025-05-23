﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Business.Models;
using TestWebApp.Common;
using TestWebApp.Core;

namespace TestWebApp.Business.Interfaces
{
    public interface IUserDataService: IServiceGet<UserData>, IServiceCreate<UserData>
    {
        IEnumerable<UserData> GetAll(DataFilter? filters);

        Task CreateAsync(IEnumerable<UserData> list);
    }
}
