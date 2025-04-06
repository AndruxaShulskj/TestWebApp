using AutoMapper;
using TestWebApp.Business.Interfaces;
using TestWebApp.Business.Models;
using TestWebApp.Common;
using TestWebApp.DataAccess.Entities;
using TestWebApp.DataAccess.Interfaces;

namespace TestWebApp.Business.Services
{
    public class LogDataService(ILogRepository logRepository, IMapper mapper) : ILogDataService
    {

        public IEnumerable<LogData> GetAll()
        {
            return logRepository.GetAll().Select(mapper.Map<LogData>);
        }

        public LogData Get(int id)
        {
            return mapper.Map<LogData>(logRepository.Get(id));
        }

        public Task Create(LogData data)
        {
            var userEntity = mapper.Map<LogEntity>(data);
            logRepository.Create(userEntity);

            return logRepository.SaveAsync();
        }
    }
}
