using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Business.Models;
using TestWebApp.Common;
using TestWebApp.Core;

namespace TestWebApp.Business.Interfaces
{
    public interface ILogDataService: IServiceGet<LogData>, IServiceCreate<LogData>
    {
        IEnumerable<LogData> GetAll();
    }
}
