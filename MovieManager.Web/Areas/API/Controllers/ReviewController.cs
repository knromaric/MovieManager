using MovieManager.DataContracts;
using MovieManager.Management;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MovieManager.Web.Areas.API.Controllers
{
    [RoutePrefix("api/reviews")]
    public class ReviewController : ApiController
    {
        private ReviewManagement _reviewManagement = new ReviewManagement();

        [HttpGet]
        [Route("getallreviews")]
        public List<ReviewDTO> GetReviews()
        {
            return _reviewManagement.GetReviews();
        }

        [HttpGet]
        [Route("{reviewId}")]
        public ReviewDTO GetReview(Guid reviewId)
        {
            return _reviewManagement.GetReview(reviewId);
        }

        [HttpDelete]
        [Route("{reviewId}")]
        public void DeleteReview(Guid reviewId)
        {
            _reviewManagement.DeleteReview(reviewId);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateReview([FromBody] ReviewDTO review, Guid id)
        {
            _reviewManagement.AddOrUpdateReview(review);
        }

        [HttpPost]
        [Route("{id}")]
        public void AddReview([FromBody] ReviewDTO review, Guid id)
        {
            _reviewManagement.AddOrUpdateReview(review);
        }
    }
}
