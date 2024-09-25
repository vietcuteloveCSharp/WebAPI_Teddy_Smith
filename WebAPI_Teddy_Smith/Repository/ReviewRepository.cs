using WebAPI_Teddy_Smith.Data;
using WebAPI_Teddy_Smith.Interface;
using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Repository
{
    public class ReviewRepository : IReviewRepository
    {   private readonly DataContext _context;
        
        public ReviewRepository( DataContext context)
        {
            this._context = context;
        }
        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(c => c.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
           return _context.Reviews.Where(c=>c.Pokemon.Id==pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(c=>c.Id == reviewId);
        }
    }
}
