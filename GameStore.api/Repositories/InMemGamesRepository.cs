using GameStore.api.Entities;

namespace GameStore.api.Repositories;

public class InMemGamesRepository
{
    // Create a list of games with type Game (which is defined in the GameStore.api/Entities/Game.cs file imported with the using statement above)
    private readonly List<Game> games = new() // static because we will use it in a static method
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


    // Get all games
    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    // Get a game by ID
    public Game? Get(int id)
    {
        return games.Find(game => game.ID == id);
    }

    // Create a new game
    public void Create(Game newGame)
    {

        newGame.ID = games.Max(g => g.ID) + 1;
        games.Add(newGame);
    }


    // Update a game by ID
    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(g => g.ID == updatedGame.ID);
        games[index] = updatedGame;
    }
    // Delete a game by ID
    public void Delete(int id)
    {
        var index = games.FindIndex(g => g.ID == id);
        games.RemoveAt(index);
    }
}