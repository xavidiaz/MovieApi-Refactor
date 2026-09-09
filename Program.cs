using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MovieApi_Refactor;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Entities;
using MovieApi_Refactor.Repositories;
using MovieApi_Refactor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieContext"))
);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MovieContext>();
    db.Database.Migrate();

    if (!db.Movies.Any())
    {
        db.Movies.AddRange(
            new Movie { Title = "The Matrix", Year = 1999 },
            new Movie { Title = "Inception", Year = 2010 },
            new Movie { Title = "Parasite", Year = 2019 }
        );
        db.SaveChanges();
    }

    if (!db.Actors.Any())
    {
        var matrix = db.Movies.First(m => m.Title == "The Matrix");
        var inception = db.Movies.First(m => m.Title == "Inception");
        var parasite = db.Movies.First(m => m.Title == "Parasite");

        matrix.Actors.Add(
            new Actor
            {
                FirstName = "Keanu",
                LastName = "Reeves",
                BirthYear = 1964,
            }
        );
        matrix.Actors.Add(
            new Actor
            {
                FirstName = "Carrie-Anne",
                LastName = "Moss",
                BirthYear = 1967,
            }
        );

        inception.Actors.Add(
            new Actor
            {
                FirstName = "Leonardo",
                LastName = "DiCaprio",
                BirthYear = 1974,
            }
        );

        parasite.Actors.Add(
            new Actor
            {
                FirstName = "Song",
                LastName = "Kang-ho",
                BirthYear = 1967,
            }
        );

        db.SaveChanges();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
