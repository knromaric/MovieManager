using MovieManager.DataContracts;
using MovieManager.Management;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MovieManager.Web.Areas.API.Controllers
{
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        private MovieManagement _movieManagement = new MovieManagement();
        
        [HttpGet]
        [Route("getallmovies")]
        public List<MovieDTO> GetMovies()
        {
            return _movieManagement.GetMovies();
        }

        [HttpGet]
        [Route("{movieId}")]
        public MovieDTO GetMovies(Guid movieId)
        {
            return _movieManagement.GetMovie(movieId);
        }

        [HttpDelete]
        [Route("{movieId}")]
        public void DeleteMovie(Guid movieId)
        {
            _movieManagement.DeleteMovie(movieId);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateMovie([FromBody] MovieDTO movie, Guid id)
        {
            _movieManagement.AddOrUpdateMovie(movie);
        }

        [HttpPost]
        [Route("{id}")]
        public void AddMovie([FromBody] MovieDTO movie, Guid id)
        {
            _movieManagement.AddOrUpdateMovie(movie);
        }
    }
}
