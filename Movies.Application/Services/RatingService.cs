using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using Movies.Application.Repositories;
using ValidationException = FluentValidation.ValidationException;

namespace Movies.Application.Services;

public class RatingService: IRatingService
{
    private readonly IRatingRepository _ratingRepository;
    private readonly IMovieRepository _movieRepository;

    public RatingService(IRatingRepository ratingRepository, IMovieRepository movieRepository)
    {
        _ratingRepository = ratingRepository;
        _movieRepository = movieRepository;
    }

    public async Task<bool> RateMovieAsync(Guid movieId, int rating, Guid userId, CancellationToken token = default)
    {
        if (rating is <= 0 or > 10)
        {
            throw new ValidationException(new[]
            {
                new ValidationFailure
                {
                    PropertyName = "Rating",
                    ErrorMessage = "Rating must be between 0 and 10"
                }
            });
        }
        var movieExists = await _movieRepository.ExistByIdAsync(movieId, token);
        if (!movieExists)
        {
            return false;
        }
        
        return await _ratingRepository.RateMovieAsync(movieId, rating, userId, token);
    }
}