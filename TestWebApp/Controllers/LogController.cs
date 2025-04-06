using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Business.Interfaces;
using TestWebApp.Dto.Models;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController(ILogger<LogController> logger, ILogDataService logDataService, IMapper mapper) : ControllerBase
    {
        private readonly ILogger<LogController> _logger = logger;


        [HttpGet("GetAllLogs")]
        public IEnumerable<LogDto> GetAllData()
        {
            return logDataService.GetAll().Select(mapper.Map<LogDto>);
        }
    }
}
