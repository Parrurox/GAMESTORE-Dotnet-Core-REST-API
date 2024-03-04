using GameStore.api.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

const string GetGameEndpointName = "GetGameById";


// Create a list of games with type Game (which is defined in the GameStore.api/Entities/Game.cs file imported with the using statement above)
List<Game> games = new()
{
    new Game(){
        ID = 1,
        Name = "The Witcher 3",
        Genre = "RPG",
        Price = 29.99m,
        ReleaseDate = new DateTime(2015, 5, 19),
        ImageUri = "https://placehold.co/100"
    },
    new Game(){
        ID = 2,
        Name = "RDR2",
        Genre = "western",
        Price = 39.99m,
        ReleaseDate = new DateTime(2018, 5, 19),
        ImageUri = "https://placehold.co/100"
    },
    new Game(){
        ID = 3,
        Name = "Spiderman",
        Genre = "Action/Superhero",
        Price = 49.99m,
        ReleaseDate = new DateTime(2020, 5, 19),
        ImageUri = "https://placehold.co/100"
    },

};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// -------------- Get all games -----------------------------------------------------
app.MapGet("/games", () => games);

// -------------- Get game by ID ----------------------------------------------------
app.MapGet("/games/{id}", (int id) =>
{
    Game? game = games.Find(g => g.ID == id);
    if (game is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(game);


}).WithName(GetGameEndpointName); // Name the endpoint for later use

// -------------- Create a new game ----------------------------------------

app.MapPost("/games", (Game newGame) =>
{
    newGame.ID = games.Max(g => g.ID) + 1;
    games.Add(newGame);
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = newGame.ID }, newGame);
});

// -------------- Update a game ----------------------------------------
app.MapPut("/games/{id}", (int id, Game updatedGame) =>
{
    Game? existingGame = games.Find(g => g.ID == id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }
    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;
    return Results.Ok();
});

// -------------- Delete a game ----------------------------------------
app.MapDelete("/games/{id}", (int id) =>
{
    Game? Exist = games.Find(g => g.ID == id);
    if (Exist is not null)
    {
        games.Remove(Exist);
    }
    return Results.NoContent();

});

app.Run();
