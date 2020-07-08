using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using DapperCRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovieController : Controller
    {
        private readonly MovieRepository movieRepository;

        public MovieController()
        {
            movieRepository = new MovieRepository();
        }
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return movieRepository.GetAllMovies();
        }
        [HttpGet("{id}")]

        public Movie Get(int id)
        {
            return movieRepository.GetByID(id);
        }

        [HttpPost]

        public void Post([FromBody]Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                movieRepository.Add(newMovie);
            }
            else
            {
                throw new HttpException(400, "Bad Request");
            }
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie newMovie)
        {
            newMovie.MovieID = id;
            if (ModelState.IsValid)
            {
                movieRepository.UpdateMovies(newMovie);
            }
            else
            {
                throw new HttpException(400, "Movie wasn't updated");
            }
        }

        [HttpDelete]

        public void Delete(int id)
        {
            movieRepository.DeleteByID(id);
        }

    }

    [Serializable]
    internal class HttpException : Exception
    {
        private int v1;
        private string v2;

        public HttpException()
        {
        }

        public HttpException(string message) : base(message)
        {
        }

        public HttpException(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public HttpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
