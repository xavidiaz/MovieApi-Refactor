using Microsoft.AspNetCore.Http.HttpResults;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Entities;
using MovieApi_Refactor.Services;

namespace MovieApi_Refactor.Services;

public class MovieService(IUnitOfWork unitOfWork) : IMovieService
{
    public async Task<IEnumerable<Movie>> GetAllAsync() => await unitOfWork.Movies.GetAllAsync();
    public async Task<Movie?> GetByIdAsync(int id) => await unitOfWork.Movies.GetByIdAsync(id);
    public async Task<Movie> CreateAsync(Movie movie)
    {
        unitOfWork.Movies.Add(movie);
        await unitOfWork.CompleteAsync();
        return movie;
    }
    public async Task<Movie?> UpdateAsync(int id, Movie movie)
    {
        var existing = await unitOfWork.Movies.GetByIdAsync(id);
        if (existing is null) return null;

        existing.Title = movie.Title;
        existing.Year = movie.Year;

        await unitOfWork.CompleteAsync();
        return existing;
    }
    public async Task<Movie?> DeleteAsync(int id)
    {
        var movie = await unitOfWork.Movies.GetByIdAsync(id);
        if (movie is null) return null;

        unitOfWork.Movies.Remove(movie);
        await unitOfWork.CompleteAsync();
        return movie;
    }
}
