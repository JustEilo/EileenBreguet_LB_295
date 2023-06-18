using Eileen_Breguet_LB295;
using EileenBreguet_Backup2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryContext _db;

        public LibraryController(LibraryContext context)
        {
            _db = context;
        }

        //localhost:44362/api/library

        [HttpPost] //Create
        public IActionResult CreateGame(Games game)
        {
            _db.Games.Add(game);
            _db.SaveChanges();

            return CreatedAtAction("GetGame", new { id = game.id }, game);
        }

        [HttpGet]
        public IActionResult GetGame(int id)
        {
            Games gameFromDb = _db.Games.SingleOrDefault(b => b.id == id);

            if (gameFromDb == null)
            {
                return NotFound();
            }

            return Ok(gameFromDb);
        }

        [HttpPut]
        public IActionResult UpdateGame(Games game)
        {
            Games gameFromDb = _db.Games.SingleOrDefault(b => b.id == game.id);

            if (gameFromDb == null)
            {
                return NotFound();
            }

            gameFromDb.title = game.title;
            gameFromDb.description = game.description;

            _db.SaveChanges();

            return Ok("Update ok");

        }

        [HttpDelete]
        public IActionResult DeleteGame(int id)
        {
            Games gameFromDb = _db.Games.SingleOrDefault(b => b.id == id);

            if (gameFromDb == null)
            {
                return NotFound();
            }

            _db.Remove(gameFromDb);
            _db.SaveChanges();

            return Ok("Deleted game");
        }

        [HttpGet]
        [Route("GetGame")]
        public IActionResult GetGames()
        {
            var allGames = _db.Games.ToList();

            if (allGames.Count == 0)
            {
                return Ok("No games in database");
            }

            return Ok(allGames);
        }
    }
}
