using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.DataContracts
{
    public class MovieDTO
    {
        public Guid  Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
        public double AverageScore { get; set; }
        public string Rating { get; set; }
    }
}
