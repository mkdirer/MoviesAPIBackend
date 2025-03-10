using FluentValidation;
using Movies.Application.Models;
using Movies.Application.Repositories;

namespace Movies.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IValidator<Movie> _validator;

    public MovieService(IMovieRepository movieRepository, IValidator<Movie> validator)
    {
        _movieRepository = movieRepository;
        _validator = validator;
    }

    public async Task<bool> CreateAsync(Movie movie)
    {
        await _validator.ValidateAndThrowAsync(movie);
        return await _movieRepository.CreateAsync(movie);
        
    }

    public Task<Movie?> GetByIdAsync(Guid id)
    {
        return _movieRepository.GetByIdAsync(id);
    }

    public Task<Movie?> GetBySlugAsync(string slug)
    {
        return _movieRepository.GetBySlugAsync(slug);
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        return _movieRepository.GetAllAsync();
    }

    public async Task<Movie?> UpdateAsync(Movie movie)
    {
        await _validator.ValidateAndThrowAsync(movie);
        var movieExist = await _movieRepository.ExistByIdAsync(movie.Id);
        if (!movieExist)
        {
            return null;
        }
        
        await _movieRepository.UpdateAsync(movie);
        return movie;
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return _movieRepository.DeleteAsync(id);
    }
}