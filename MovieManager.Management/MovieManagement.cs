using MovieManager.DataAccess;
using MovieManager.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Management
{
    public class MovieManagement
    {
        private MovieRepository _repo = new MovieRepository();

        public List<MovieDTO> GetMovies()
        {
            var movies = _repo.GetMovies();
            var moviesToReturn = movies.Select(m => new MovieDTO
            {
                Id = m.Id,
                AverageScore = (float)m.AverageScore,
                CategoryName = m.Category.Name,
                Length = m.Length,
                Rating = m.Rating,
                ReleaseDate = m.ReleaseDate,
                Title = m.Title
            }).ToList();

            return moviesToReturn;
        }

        public MovieDTO GetMovie(Guid movieId)
        {
            var movie = _repo.GetMovie(movieId);
            return new MovieDTO
            {
                Id = movie.Id,
                AverageScore = (float)movie.AverageScore,
                CategoryName = movie.Category.Name,
                Length = movie.Length,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate,
                Title = movie.Title
            };

        }

        public void AddOrUpdateMovie(MovieDTO newMovie)
        {
            var movie = new Movie
            {
                Id = (newMovie.Id == Guid.Empty) ? Guid.NewGuid() : newMovie.Id,
                Title = newMovie.Title,
                AverageScore = newMovie.AverageScore,
                Length = newMovie.Length,
                Rating = newMovie.Rating,
                ReleaseDate = newMovie.ReleaseDate
            };

            if (!string.IsNullOrEmpty(newMovie.CategoryName))
            {
                var categoryRepo = new CategoryRepository();
                var existingMovie = categoryRepo.GetCategoryByName(newMovie.CategoryName);
                if (existingMovie != null)
                    movie.CategoryId = existingMovie.Id;
            }


            if (newMovie.Id != Guid.Empty)
            {
                _repo.UpdateMovie(movie); 
            }
            else
            {
                _repo.AddMovie(movie);
            }
        }

        public void DeleteMovie(Guid id)
        {
            _repo.DeleteMovie(id);
        }




    }
}
