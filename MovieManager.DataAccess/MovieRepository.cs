using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            try
            {
                dbContext.Movies.Add(newMovie);
                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
                throw;
            }
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
