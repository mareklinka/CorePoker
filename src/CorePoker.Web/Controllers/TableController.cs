using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using CorePoker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CorePoker.Controllers
{
    [Route("api/[controller]")]
    public class TableController : Controller
    {
        private readonly CorePokerContext db;

        public TableController(CorePokerContext db)
        {
            this.db = db;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var table = await db.Tables.FirstOrDefaultAsync(_ => _.PublicId == id);

            if (table == null)
            {
                return NotFound();
            }

            return Json(table);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TablePayload table)
        {
            var player = await db.Players.FirstOrDefaultAsync(_ => _.Nickname == table.PlayerName);

            if (player == null)
            {
                return NotFound("Player not found");
            }

            var tableEntity = new Table
            {
                CreatedAt = DateTime.UtcNow,
                Name = table.TableName,
                PublicId = Guid.NewGuid().ToString(),
                Owner = player
            };

            tableEntity.TablePlayers.Add(new TablePlayer {Player = player});

            db.Tables.Add(tableEntity);
            db.SaveChanges();

            return Ok(new {tableId = tableEntity.PublicId});
        }

        public sealed class TablePayload
        {
            [Required]
            [MaxLength(60)]
            public string TableName { get; set; }

            [Required]
            [MaxLength(60)]
            public string PlayerName { get; set; }
        }
    }
}
