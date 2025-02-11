using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Abstractions;
using Task1.Models;

namespace Task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class UserDataController : ControllerBase
    {
        private readonly ILogger<UserDataController> _logger;
        private IDbContext _database;

        public UserDataController(
            IDbContext database,
            ILogger<UserDataController> logger)
        {
            _database = database;
            _logger = logger;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> GetUserData(int? code, string? value)
        {
            try
            {
                var result = await _database.GetModelAsync<UserDataModel>()
                    .Where(x => (code.HasValue ? x.Code == code : x.Code != int.MinValue) 
                                && (!string.IsNullOrEmpty(value) ? x.Value.Equals(value) : !string.IsNullOrEmpty(x.Value)))
                    .ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> PostUserData([FromBody] List<UserDataParameter> data)
        {
            try
            {
                _database.RemoveAll<UserDataModel>();
                await _database.AddRangeAsync<UserDataModel>(data.Select(x => new UserDataModel() { Code = x.Code, Value = x.Value }).OrderBy(x => x.Code));
                await _database.CommitChanges();
                return Ok();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
