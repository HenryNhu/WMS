using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS_new.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_WarehouseController : ControllerBase
    {
        WMS_newContext db = new WMS_newContext();
        [HttpPost]
        public async Task<IActionResult> CurrentWarehouseProcess([FromQuery] int warehouseId)
        {
            // Truy vấn WarehouseID từ cơ sở dữ liệu
            var result = await db.Warehouses
                .FromSqlRaw("SELECT * FROM Warehouse WHERE WarehouseID = {0}", warehouseId)
                .ToListAsync();

            // Kiểm tra kết quả
            if (result.Count == 0)
            {
                return Ok(new
                {
                    message = "incorrect warehouse"
                });
            }
            else
            {
                return Ok(new
                {
                    message = "correct warehouse"
                });
            }
        }

    }
}
