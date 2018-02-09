using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.Domain
{
    public class InMemoryGameRepository : IGameRepository
    {
        List<GameEntity> _games = new List<GameEntity>();

        public void Add(GameEntity game)
        {
            _games.Add(game);

        }

        public List<GameEntity> GetAll()
        {
            return _games;
        }

        public GameEntity GetByCode(string code)
        {
            return _games.Find(game => game.Code == code);
        }
    }
}
