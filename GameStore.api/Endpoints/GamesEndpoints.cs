using GameStore.api.Entities;
using GameStore.api.Repositories;

namespace GameStore.api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGameById";


    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {


        InMemGamesRepository repository = new();
        // -------------- Route Grouping -----------------------------------------------------
        var group = routes.MapGroup("/games")
                        .WithParameterValidation(); // Enable parameter validation for all routes in this group(comes from miniapis package)


        routes.MapGet("/", () => "Hello World!"); // before using route group

        // -------------- Get all games -----------------------------------------------------
        // app.MapGet("/games", () => games); // before using route group
        group.MapGet("/", () => repository.GetAll()); // after using route group

        // -------------- Get game by ID ----------------------------------------------------
        group.MapGet("/{id}", (int id) =>
        {
            Game? game = repository.Get(id);
            return game is not null ? Results.Ok(game) : Results.NotFound();



        }).WithName(GetGameEndpointName); // Name the endpoint for later use

        // -------------- Create a new game ----------------------------------------

        group.MapPost("/", (Game newGame) =>
        {
            repository.Create(newGame);
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = newGame.ID }, newGame);
        });

        // -------------- Update a game ----------------------------------------
        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            Game? existingGame = repository.Get(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;
            repository.Update(existingGame);
            return Results.Ok();
        });

        // -------------- Delete a game ----------------------------------------
        group.MapDelete("/{id}", (int id) =>
        {
            Game? Exist = repository.Get(id);
            if (Exist is not null)
            {
                repository.Delete(id);
            }
            return Results.NoContent();

        });

        return group;

    }
}