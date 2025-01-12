using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS_new.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_NationController : ControllerBase
    {
        WMS_newContext db = new WMS_newContext();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nation>>> GetNations()
        {
            if (db.Nations == null)
            {
                return NotFound();
            }
            return await db.Nations.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Nation>> PostNation(Nation nation)
        {
            if (db.Nations == null)
            {
                return NotFound();
            }
            db.Nations.Add(nation);
            await db.SaveChangesAsync();
            return CreatedAtAction("GetNations", new {id = nation.NationId}, nation);
        }
    }
}
