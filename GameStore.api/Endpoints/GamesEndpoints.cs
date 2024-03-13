using GameStore.api.Dtos;
using GameStore.api.Entities;
using GameStore.api.Repositories;

namespace GameStore.api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGameById";


    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {


        // InMemGamesRepository repository = new(); // before using dependency injection
        // -------------- Route Grouping -----------------------------------------------------
        var group = routes.MapGroup("/games")
                        .WithParameterValidation(); // Enable parameter validation for all routes in this group(comes from miniapis package) 


        routes.MapGet("/", () => "Hello World!"); // before using route group

        // -------------- Get all games -----------------------------------------------------
        // app.MapGet("/games", () => games); // before using route group
        group.MapGet("/", (IGamesReposity repository) => repository
        .GetAll()
        .Select(game => game.AsDto())
        ); // after using route group

        // -------------- Get game by ID ----------------------------------------------------
        group.MapGet("/{id}", (IGamesReposity repository, int id) =>
        {
            Game? game = repository.Get(id);
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();



        }).WithName(GetGameEndpointName); // Name the endpoint for later use

        // -------------- Create a new game ----------------------------------------

        group.MapPost("/", (CreateGameDto gameDto, IGamesReposity repository) =>
        {
            Game newGame = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri
            };
            repository.Create(newGame);
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = newGame.ID }, newGame);
        });

        // -------------- Update a game ----------------------------------------
        group.MapPut("/{id}", (IGamesReposity repository, int id, UpdateGameDto updatedGameDto) =>
        {
            Game? existingGame = repository.Get(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existingGame.ImageUri = updatedGameDto.ImageUri;
            repository.Update(existingGame);
            return Results.Ok();
        });

        // -------------- Delete a game ----------------------------------------
        group.MapDelete("/{id}", (IGamesReposity repository, int id) =>
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