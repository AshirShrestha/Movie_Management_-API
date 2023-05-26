using MovieManagementAPI.Generic;

namespace MovieManagementAPI.Models
{
    public class MovieMedia:GenericModel
    {
        public int Id { get; set; }
        public string? MediaPath { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
