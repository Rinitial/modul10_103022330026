using Microsoft.AspNetCore.Mvc;
using modul10_103022330026.Models;

namespace modul10_103022330026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movieList = new List<Movie>
        {
            new Movie {Title = "The Shawshank Redemption", Director = "Frank Darabont", Stars = ["Tim Robbins", "Morgan Freeman", "Bob Gunton"], Description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."},
            new Movie {Title = "The Godfather", Director = "Francis Ford Coppola", Stars = ["Marlon Brando", "Al Pacino", "James Caan"], Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."},
            new Movie {Title = "The Dark Knight", Director = "Christoper Nolan", Stars = ["Christian Bale", "Heath Ledger", "Aaron Eckhart"], Description = "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."}

        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return movieList;
        }

        [HttpPost]
        public ActionResult<IEnumerable<Movie>> Post([FromBody] Movie moviebaru)
        {
            movieList.Add(moviebaru);
            return movieList;
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> Get(int index)
        {
            if (index < 0 || index >= movieList.Count) 
            {
                return NotFound("Movie tidak ditemukan.");
            }
            return movieList[index];
        }

        [HttpDelete("{index}")]
        public ActionResult<IEnumerable<Movie>> Delete(int index)
        {
            if (index < 0 || index >= movieList.Count)
            {
                return NotFound("Movie tidak ditemukan.");
            }
            movieList.RemoveAt(index);
            return movieList;
        }
    }
}
