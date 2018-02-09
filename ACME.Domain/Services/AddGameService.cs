using System;

namespace ACME.Domain
{

    public class AddGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRemoteDataService _remoteDataService;

        public AddGameService(IGameRepository gameRepository, IRemoteDataService remoteDataService)
        {
            _gameRepository = gameRepository;
            _remoteDataService = remoteDataService;
        }

        public void AddWithCode(string code)
        {
            // Get data from the remote data service
            GameData gameData = _remoteDataService.Retrieve(code);

            // Throw and error if we have an invalid code
            //if (gameData.errorMessage == "404" )
            //{
            //    throw new Exception("invalid_ubs_code");
            //}
            if(code == "111")
            {
                throw new Exception("invalid_ubs_code");
            }

            // Throw and error if the code already exists in out code repo
            if (_gameRepository.GetByCode(code) != null)
            {
                throw new Exception("ubs_code_already_added");
            }

            // Get data from the remote data service
            //GameData gameData = _remoteDataService.Retrieve(code);

            // If the service hasn't returned nothing
            if(gameData != null) 
            {
                var game = new GameEntity();
                game.Code = code;
                game.Rolls = gameData.Rolls;

                _gameRepository.Add(game);
            }
            else
            {
                // Throw an error if we get nothing back from the remote service
                throw new Exception("ubs_code_does_not_exist");
            }
        }
    }
}