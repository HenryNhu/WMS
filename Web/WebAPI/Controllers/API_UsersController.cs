using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS_new.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_UsersController : ControllerBase
    {
        WMS_newContext db = new WMS_newContext();
        [HttpPost]
        public async Task<IActionResult> Login([FromQuery] long UserId, [FromQuery] string Password )
        {
            var result = await db.Users
                .FromSqlRaw("EXEC sp_Login @UserID = {0}, @Password = {1}", UserId, Password)
                .ToListAsync();
            if(result.Count == 0)
            {
                return Ok(new
                {
                    message = "incorrect"
                });
            }
            else
            {
                return Ok(new
                {
                    message = "correct",
                    data = result.First()
                });
            }
        }
    }
}
