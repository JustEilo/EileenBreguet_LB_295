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

        [HttpPost] //Create Request
        public IActionResult CreateGame(Games game)
        {
            _db.Games.Add(game);
            _db.SaveChanges();

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        [HttpGet]//Get Requet
        public IActionResult GetGame(int id)
        {
            Games gameFromDb = _db.Games.SingleOrDefault(b => b.Id == id);

            if (gameFromDb == null)
            {
                return NotFound();
            }

            return Ok(gameFromDb);
        }

        [HttpPut]// Update Request
        public IActionResult UpdateGame(Games game)
        {
            Games gameFromDb = _db.Games.SingleOrDefault(b => b.Id == game.Id);

            if (gameFromDb == null)
            {
                return NotFound();
            }

            gameFromDb.Title = game.Title;
            gameFromDb.Description = game.Description;

            _db.SaveChanges();

            return Ok("Update ok");

        }

        [HttpDelete] // Delete Request
        public IActionResult DeleteGame(int id)
        {
            Games gameFromDb = _db.Games.SingleOrDefault(b => b.Id == id);

            if (gameFromDb == null)
            {
                return NotFound();
            }

            _db.Remove(gameFromDb);
            _db.SaveChanges();

            return Ok("Deleted game");
        }

        [HttpGet] // GET All Request from games.
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
