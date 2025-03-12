using Movies.Application.Models;

namespace Movies.Application.Repositories;

public interface IMovieRepository
{
    Task<bool> CreateAsync(Movie movie, CancellationToken token = default);
    
    Task<Movie?> GetByIdAsync(Guid id, Guid? userid = default, CancellationToken token = default);
    
    Task<Movie?> GetBySlugAsync(string slug, Guid? userid = default, CancellationToken token = default);
    
    Task<IEnumerable<Movie>> GetAllAsync(Guid? userId = default, CancellationToken token = default);
    
    Task<bool> UpdateAsync(Movie movie, CancellationToken token = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken token = default);
    
    Task<bool> ExistByIdAsync(Guid id, CancellationToken token = default);
}