using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Business.Interfaces;
using TestWebApp.Business.Models;
using TestWebApp.Common;
using TestWebApp.Dto.Models;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDataController(ILogger<UserDataController> logger, IUserDataService userDataService, IMapper mapper) : ControllerBase
    {
        private readonly ILogger<UserDataController> _logger = logger;

        [HttpPost("GetFilteredData")]
        public IEnumerable<UserDto> GetItems(DataFilter? filters = null)
        {
            return userDataService.GetAll(filters).Select(mapper.Map<UserDto>);
        }


        [HttpPost("AddData")] 
        public async Task<IActionResult> AddItems(UserDto[] items)
        {
            await userDataService.CreateAsync(items.Select(mapper.Map<UserData>));
            return Ok();
        }
    }
}
