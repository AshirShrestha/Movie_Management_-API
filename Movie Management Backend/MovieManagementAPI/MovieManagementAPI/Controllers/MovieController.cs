using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManagementAPI.Data;
using MovieManagementAPI.Models;
using MovieManagementAPI.ViewModels;
using System.Data.Common;
using System.Net.WebSockets;
using System.Security.Cryptography.Xml;

namespace MovieManagementAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("addmovie")]
        public IActionResult AddMovie([FromBody]MovieViewModel movieViewModel)
        {
            using var dbtran = _context.Database.BeginTransaction();
            try
            {
                // creates a object of movie to map on movieViewModel

                Movie movie = new Movie();
                if (movieViewModel != null)
                {
                    movie.Title = movieViewModel.Title;
                    movie.Description = movieViewModel.Description;
                    movie.UserId = movieViewModel.UserId;
                    movie.CreatedDateTime = DateTime.Now;
                    _context.Movie.Add(movie);
                    _context.SaveChanges();
                    MovieDetails movieDetails = new MovieDetails();
                    movieDetails.MovieId = movie.Id;
                    movieDetails.Genre = movieViewModel.Genre;
                    movieDetails.MovieLink = movieViewModel.MovieLink;
                    movieDetails.CreatedDateTime = DateTime.Now;
                    _context.MovieDetails.Add(movieDetails);
                    _context.SaveChanges();
                    MovieMedia movieMedia = new MovieMedia();
                    movieMedia.MovieId = movie.Id;
                    movieMedia.MediaPath = movieViewModel.MediaPath;
                    movieMedia.CreatedDateTime = DateTime.Now;
                    _context.MovieMedia.Add(movieMedia);
                    _context.SaveChanges();
                    dbtran.Commit();
                    return Ok(movieViewModel);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                dbtran.Rollback();
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("allmovies")]
        public IActionResult GetAllMovies([FromQuery] MovieRequestViewModel movieRequest)
        {
            try
            {
                var allMovies = new List<Movie>();
                List<MovieViewModel> movieViewModels = new List<MovieViewModel>();
                if (movieRequest != null)
                {
                    if (movieRequest.SearchName != null
                        && movieRequest.SearchName != "")
                    {
                        //search movie by name
                        if (movieRequest.Limit > 0 && movieRequest.Offset >= 0)
                        {
                            allMovies = _context.Movie.Where(x => x.Title.Contains(movieRequest.SearchName))
                                .Include(x => x.MovieDetails)
                                .Include(x => x.Medias).Skip(movieRequest.Offset)
                                .Take(movieRequest.Limit).ToList();
                        }
                        else
                        {
                            allMovies = _context.Movie.Where(x => x.Title.Contains(movieRequest.SearchName))
                                .Include(x => x.MovieDetails)
                                .Include(x => x.Medias).ToList();
                        }
                    }
                    else
                    {
                        //without search
                        if (movieRequest.Limit > 0 && movieRequest.Offset >= 0)
                        {
                            allMovies = _context.Movie
                            .Include(x => x.MovieDetails)
                            .Include(x => x.Medias).Skip(movieRequest.Offset)
                            .Take(movieRequest.Limit).ToList();
                        }
                        else
                        {
                            allMovies = _context.Movie
                            .Include(x => x.MovieDetails)
                            .Include(x => x.Medias).ToList();
                        }

                    }
                }
                
                if (allMovies != null)
                {
                    foreach (var item in allMovies)
                    {
                        MovieViewModel movieViewModel = new MovieViewModel();
                        movieViewModel.MovieId = item.Id;
                        movieViewModel.Title = item.Title;
                        movieViewModel.CreatedDateTime = item.CreatedDateTime;
                        movieViewModel.Description = item.Description;
                        movieViewModel.Genre = item.MovieDetails.Genre;
                        movieViewModel.MovieLink = item.MovieDetails.MovieLink;
                        movieViewModel.MediaPath = item.Medias?.FirstOrDefault()?.MediaPath;
                        movieViewModels.Add(movieViewModel);

                    }
                    if (movieViewModels != null)
                    {
                        movieViewModels[0].Total = _context.Movie.Count();
                    }
                    return Ok(movieViewModels);
                }


                return NotFound();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            try
            {
                MovieViewModel movieViewModel = new MovieViewModel();
                var movie = _context.Movie.Where(x => x.Id == id)
                    .Include(x => x.MovieDetails)
                    .Include(x => x.Medias).Include(x=>x.MovieReviews).FirstOrDefault();
                if (movie !=null)
                {
                    movieViewModel.MovieId = movie.Id;
                    movieViewModel.Title = movie.Title;
                    movieViewModel.CreatedDateTime = movie.CreatedDateTime;
                    movieViewModel.Description = movie.Description;
                    movieViewModel.Genre = movie.MovieDetails.Genre;
                    movieViewModel.MovieLink = movie.MovieDetails.MovieLink;
                    movieViewModel.MediaPath = movie.Medias?.FirstOrDefault()?.MediaPath;
                    movieViewModel.MovieReviews = new List <MovieReviewViewModel>();
                    if (movie.MovieReviews != null)
                    {
                        foreach(var item in movie.MovieReviews)
                        {
                            MovieReviewViewModel movieReviewViewModel = new MovieReviewViewModel();
                            movieReviewViewModel.MovieId = item.MovieId;
                            movieReviewViewModel.UserId = item.UserId;
                            movieReviewViewModel.ReviewComment = item.Comments;
                            movieViewModel.MovieReviews.Add(movieReviewViewModel);
                        }
                    }                   

                    return Ok (movieViewModel);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpPost("addReview")]
        public IActionResult AddReview(MovieReviewViewModel movieReviewViewModel)
        {
            using var dbTran = _context.Database.BeginTransaction();
            try
            {
                //ceate a object of movie to map on movieViewModel
                MovieReview movieReview = new MovieReview();
                if (movieReviewViewModel != null)
                {
                    movieReview.UserId = movieReviewViewModel.UserId;
                    movieReview.MovieId = movieReviewViewModel.MovieId;
                    movieReview.Comments = movieReviewViewModel.ReviewComment;
                    movieReview.CreatedDateTime = DateTime.Now;
                    _context.MovieReview.Add(movieReview);
                    _context.SaveChanges();
                    dbTran.Commit();
                    return Ok(movieReview);
                }
                else
                {
                    return BadRequest();
                }                   
            }
            catch(Exception ex)
            {
                dbTran.Rollback();
                return BadRequest(ex.Message);
            }
        }
    }
}
