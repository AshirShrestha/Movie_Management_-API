using MovieManagementAPI.Generic;

namespace MovieManagementAPI.Models
{
    public class UserFavourite:GenericModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string? UserId { get; set; }
        public Movie? Movie { get; set; }
    }
}
