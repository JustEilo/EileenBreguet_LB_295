using LibraryApi;
using Microsoft.AspNetCore.Mvc;

namespace EileenBreguet_Backup2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharakterController : ControllerBase
    {
        private readonly LibraryContext _db;

        public CharakterController(LibraryContext context)
        {
            _db = context;
        }

        [HttpPost] //Create
        public IActionResult CreateCharakter(Charakters charakter)
        {
            _db.Charakters.Add(charakter);
            _db.SaveChanges();

            return CreatedAtAction("GetAllCharakters", new { id = charakter.id }, charakter);
        }

        [HttpGet]
        public IActionResult GetGame(int id)
        {
            Charakters charakterFromDb = _db.Charakters.SingleOrDefault(b => b.id == id);

            if (charakterFromDb == null)
            {
                return NotFound();
            }

            return Ok(charakterFromDb);
        }

        [HttpPut]
        public IActionResult UpdateGame(Charakters charakter)
        {
            Charakters charakterFromDb = _db.Charakters.SingleOrDefault(b => b.id == charakter.id);

            if (charakterFromDb == null)
            {
                return NotFound();
            }

            charakterFromDb.name = charakter.name;
            charakterFromDb.surename = charakter.surename;

            _db.SaveChanges();

            return Ok("Update ok");

        }

        [HttpDelete]
        public IActionResult DeleteGame(int id)
        {
            Charakters charakterFromDb = _db.Charakters.SingleOrDefault(b => b.id == id);

            if (charakterFromDb == null)
            {
                return NotFound();
            }

            _db.Remove(charakterFromDb);
            _db.SaveChanges();

            return Ok("Deleted game");
        }

        [HttpGet]
        [Route("GetAllCharakters")]
        public IActionResult GetAllCharakters()
        {
            var allCharakters = _db.Games.ToList();

            if (allCharakters.Count == 0)
            {
                return Ok("No charakter in database");
            }

            return Ok(allCharakters);
        }
    }
}
