using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Interface
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);   

    }
}
