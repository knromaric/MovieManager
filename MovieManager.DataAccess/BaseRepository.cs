using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.DataAccess
{
    public class BaseRepository
    {
        protected MoviesDBEntities dbContext = new MoviesDBEntities();
    }
}
