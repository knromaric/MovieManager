using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.DataAccess
{
    public class MovieRepository:BaseRepository
    {
        public List<Movie> GetMovies()
        {
            return dbContext.Movies.ToList();
        }

        public Movie GetMovie(Guid movieId)
        {
            var movie = dbContext.Movies.FirstOrDefault(c => c.Id == movieId);
            return movie;
        }

        public void AddMovie(Movie newMovie)
        {
            dbContext.Movies.Add(newMovie);
            dbContext.SaveChanges();
        }

        public void DeleteMovie(Guid movieId)
        {
            var movie = dbContext.Movies.FirstOrDefault(c => c.Id == movieId);

            if (movie != null)
                dbContext.Movies.Remove(movie);

            dbContext.SaveChanges();
        }

        public void UpdateMovie(Movie updatedMovie)
        {
            var movieInDB = dbContext.Movies.FirstOrDefault(c => c.Id == updatedMovie.Id);
            if (movieInDB != null)
            {
                movieInDB.Title = updatedMovie.Title;
                dbContext.SaveChanges();
            }
        }
    }
}
