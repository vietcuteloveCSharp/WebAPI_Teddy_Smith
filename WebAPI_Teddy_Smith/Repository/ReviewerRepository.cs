using WebAPI_Teddy_Smith.Data;
using WebAPI_Teddy_Smith.Interface;
using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {   private readonly DataContext _context;
        public ReviewerRepository(DataContext context)
        {
            this._context = context;
        }
        public ICollection<Review> GetReviewByReviewer(int reviewerId)
        {
           return _context.Reviews.Where(c=>c.Reviewer.Id==reviewerId).ToList();
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _context.Reviewers.Where(c => c.Id == reviewerId).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _context.Reviewers.Any(c => c.Id == reviewerId);
        }
    }
}
