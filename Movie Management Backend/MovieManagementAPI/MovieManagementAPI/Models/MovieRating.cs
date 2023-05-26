using MovieManagementAPI.Generic;
using System.Globalization;

namespace MovieManagementAPI.Models
{
    public class MovieRating: GenericModel
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public int MovieId { get; set; }
        public string? UserId { get; set; }
        public Movie? Movie { get; set; }
        
    }
}
