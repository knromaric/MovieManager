using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.DataAccess
{
    public class ReviewRepository:BaseRepository    
    {
        public List<Review> GetReviews()
        {
            return dbContext.Reviews.ToList();
        }

        public Review GetReview(Guid reviewId)
        {
            var review = dbContext.Reviews.FirstOrDefault(c => c.Id == reviewId);
            return review;
        }

        public void AddReview(Review newReview)
        {
            dbContext.Reviews.Add(newReview);
            dbContext.SaveChanges();
        }

        public void DeleteReview(Guid reviewId)
        {
            var review = dbContext.Reviews.FirstOrDefault(c => c.Id == reviewId);

            if (review != null)
                dbContext.Reviews.Remove(review);

            dbContext.SaveChanges();
        }

        public void UpdateReview(Review updatedReview)
        {
            var reviewInDB = dbContext.Reviews.FirstOrDefault(c => c.Id == updatedReview.Id);
            if (reviewInDB != null)
            {
                reviewInDB.Score = updatedReview.Score;
                dbContext.SaveChanges();
            }
        }
    }
}
