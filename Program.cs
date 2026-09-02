using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MovieApi_Refactor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<MovieContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("MovieContext"))
        );

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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
