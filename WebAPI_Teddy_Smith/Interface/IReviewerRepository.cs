using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Interface
{
    public interface IReviewerRepository

    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
    }
}
