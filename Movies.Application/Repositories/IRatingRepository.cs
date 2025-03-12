namespace Movies.Application.Repositories;

public interface IRatingRepository
{
    Task<float?> GetRatingAsync(Guid movieid, CancellationToken token = default);
    Task<(float? Rating, int? UserRating)> GetRatingAsync(Guid movieid, Guid userId, CancellationToken token = default);
}