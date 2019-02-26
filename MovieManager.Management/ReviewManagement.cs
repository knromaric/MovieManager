using MovieManager.DataAccess;
using MovieManager.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Management
{
    public class ReviewManagement
    {
        private ReviewRepository _repo = new ReviewRepository();

        public List<ReviewDTO> GetReviews()
        {
            var reviews = _repo.GetReviews().Select(r => new ReviewDTO
            {
                Id = r.Id,
                Score = r.Score.GetValueOrDefault()
            }).ToList();

            return reviews;
        }

        public ReviewDTO GetReview(Guid reviewId)
        {
            var review = _repo.GetReview(reviewId);

            return new ReviewDTO
            {
                Id = review.Id,
                Score = review.Score.GetValueOrDefault()
            };
        }

        public void DeleteReview(Guid reviewId)
        {
            _repo.DeleteReview(reviewId);
        }

        public void AddOrUpdateReview(ReviewDTO newReview)
        {
            var review = new Review
            {
                Id = (newReview.Id == Guid.Empty) ? Guid.NewGuid() : newReview.Id,
                Score = newReview.Score
            };

            if(newReview.Id == Guid.Empty)
            {
                _repo.AddReview(review);
            }
            else
            {
                _repo.UpdateReview(review);
            }
        }
    }
}
