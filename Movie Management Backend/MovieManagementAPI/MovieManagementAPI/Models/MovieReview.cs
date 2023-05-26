using MovieManagementAPI.Generic;

namespace MovieManagementAPI.Models
{
    public class MovieReview:GenericModel
    {
        public int Id { get; set; }
        public string? Comments { get; set; }
        public int MovieId { get; set; }
        public string? UserId { get; set; }
        public Movie? Movie { get; set; }

    }
}
