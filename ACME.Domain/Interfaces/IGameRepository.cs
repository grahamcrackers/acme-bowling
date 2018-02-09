using System.Collections.Generic;

namespace ACME.Domain
{
    public interface IGameRepository
    {
        GameEntity GetByCode(string code);
        void Add(GameEntity gameEntity);
        List<GameEntity> GetAll();
    }
}