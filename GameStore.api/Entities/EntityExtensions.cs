using GameStore.api.Dtos;

namespace GameStore.api.Entities;

public static class EntityExtensions
{
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(
            game.ID,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageUri
        );
    }

}