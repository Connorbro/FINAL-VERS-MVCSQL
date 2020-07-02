using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly Models.MovieRepository movieRepository;

        public MovieController()
        {
            movieRepository = new Models.MovieRepository();
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
    }
}
