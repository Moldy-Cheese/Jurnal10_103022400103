using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Modul10_103022400103.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> games = new List<Game>
    {
        new Game { Id=1, Nama="Valorant", Developer="Riot Games", TahunRilis=2020, Genre="FPS", Rating=8.5, Platform=new string[] { "PC" }, Mode=new string[] { "Multiplayer" }, IsOnline=true, Harga=0 },
        new Game { Id=2, Nama="GTA V", Developer="Rockstar Games", TahunRilis=2013, Genre="Open World", Rating=9.5, Platform=new string[] { "PC", "PS4", "PS5", "Xbox One" }, Mode=new string[] { "Singleplayer", "Multiplayer" }, IsOnline=true, Harga=300000 },
        new Game { Id=3, Nama="The Witcher 3", Developer="CD Projekt Red", TahunRilis=2015, Genre="RPG", Rating=9.7, Platform=new string[] { "PC", "PS4", "PS5", "Xbox One", "Switch" }, Mode=new string[] { "Singleplayer" }, IsOnline=false, Harga=250000 }
    };

        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return games;
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            foreach (var item in games)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return NotFound("Index tidak ditemukan");
        }

        [HttpPost]
        public ActionResult AddGame([FromBody] Game game)
        {
            games.Add(game);
            return Ok("Film berhasil ditambahkan");
        }

        [HttpPut("{id}")]
        public ActionResult PutGame(int id, [FromBody] Game game)
        {
            foreach (var item in games)
            {
                if (item.Id == id)
                {
                    item.Id = game.Id;
                    item.Nama = game.Nama;
                    item.Developer = game.Developer;
                    item.TahunRilis = game.TahunRilis;
                    item.Genre = game.Genre;
                    item.Rating = game.Rating;
                    item.Platform = game.Platform;
                    item.Mode = game.Mode;
                    item.IsOnline = game.IsOnline;
                    item.Harga = game.Harga;
                    return Ok("Game berhasil diubah");
                }
            }
            return NotFound("Index tidak ditemukan");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            foreach (var item in games)
            {
                if (item.Id == id)
                {
                    games.Remove(item);
                    return Ok("Game berhasil dihapus");
                }
            }
            return NotFound("Index tidak ditemukan");
        }
    }
}
