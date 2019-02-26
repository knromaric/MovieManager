using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.DataContracts
{
    public class ReviewDTO
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
    }
}
