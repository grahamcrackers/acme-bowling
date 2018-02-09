using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ACME.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ACME.Api.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IGameRepository _gameRepo;

        public GamesController(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        [HttpPost("{code}")]
        public IActionResult Add(string code)
        {
            IRemoteDataService remoteDataService = new HttpRemoteDataService();

            AddGameService gameService = new AddGameService(_gameRepo, remoteDataService);
            try
            {
                gameService.AddWithCode(code);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private GameView GameEntity2GameView(GameEntity game)
        {
            return new GameView
            {
                Frames = ScoreBuilder.CalculateScore(ScoreBuilder.ParseScore(game.Rolls))
            };
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_gameRepo.GetAll().Select(GameEntity2GameView));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
            // need to implement getting all game data 
            //var games = _gameRepo.GetAll();
            //var gamesView = new List<GameView>();
        }
    }
}