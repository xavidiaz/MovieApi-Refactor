using MovieApi_Refactor.Data;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public class MovieService(IUnitOfWork unitOfWork) : IMovieService
{
    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        var movies = await unitOfWork.Movies.GetAllAsync();

        return movies.Select(m => new MovieDto
        {
            Id = m.Id,
            Title = m.Title,
            Year = m.Year,

            Actors =
            [
                .. m.Actors.Select(a => new ActorSummaryDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthYear = a.BirthYear,
                }),
            ],

            Reviews =
            [
                .. m.Reviews.Select(r => new ReviewSummaryDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Text = r.Text,
                }),
            ],
        });
    }

    public async Task<MovieDto?> GetByIdAsync(int id)
    {
        var movie = await unitOfWork.Movies.GetByIdAsync(id);
        if (movie is null)
            return null;

        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,

            Actors =
            [
                .. movie.Actors.Select(a => new ActorSummaryDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthYear = a.BirthYear,
                }),
            ],
            Reviews =
            [
                .. movie.Reviews.Select(r => new ReviewSummaryDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Text = r.Text,
                }),
            ],
        };
    }

    public async Task<MovieDto> CreateAsync(CreateMovieDto createDto)
    {
        var actors = await unitOfWork.Actors.GetByIdsAsync(createDto.ActorsId);

        var movie = new Movie
        {
            Title = createDto.Title,
            Year = createDto.Year,

            Actors = [.. actors],
            Reviews = [],
        };

        unitOfWork.Movies.Add(movie);
        await unitOfWork.CompleteAsync();

        var movieDto = new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,

            Actors =
            [
                .. movie.Actors.Select(a => new ActorSummaryDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthYear = a.BirthYear,
                }),
            ],
            Reviews = [],
        };
        return movieDto;
    }

    public async Task<MovieDto?> UpdateAsync(int id, UpdateMovieDto inputDto)
    {
        var movie = await unitOfWork.Movies.GetByIdAsync(id);
        if (movie is null)
            return null;

        var actors = await unitOfWork.Actors.GetByIdsAsync(inputDto.ActorsId);

        movie.Title = inputDto.Title;
        movie.Year = inputDto.Year;
        movie.Actors = [.. actors];

        await unitOfWork.CompleteAsync();

        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,

            Actors =
            [
                .. movie.Actors.Select(a => new ActorSummaryDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthYear = a.BirthYear,
                }),
            ],
            Reviews =
            [
                .. movie.Reviews.Select(r => new ReviewSummaryDto
                {
                    Id = r.Id,
                    Text = r.Text,
                    Rating = r.Rating,
                }),
            ],
        };
    }

    public async Task<MovieDto?> DeleteAsync(int id)
    {
        var movie = await unitOfWork.Movies.GetByIdAsync(id);
        if (movie is null)
            return null;

        unitOfWork.Movies.Remove(movie);
        await unitOfWork.CompleteAsync();

        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,
            Actors =
            [
                .. movie.Actors.Select(a => new ActorSummaryDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthYear = a.BirthYear,
                }),
            ],
            Reviews =
            [
                .. movie.Reviews.Select(r => new ReviewSummaryDto
                {
                    Id = r.Id,
                    Text = r.Text,
                    Rating = r.Rating,
                }),
            ],
        };
    }
}
