using GameStore.api.Entities;

namespace GameStore.api.Repositories;

public interface IGamesReposity
{
    IEnumerable<Game> GetAll();
    Game? Get(int id);
    void Create(Game newGame);
    void Update(Game updatedGame);
    void Delete(int id);
}

