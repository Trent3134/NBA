using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gService;
        public GameController(IGameService gservice)
        {
            _gService = gservice;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketballGame([FromBody] GameCreate req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (await _gService.CreateGame(req))
            {
                return Ok("Game was Scheduled");
            }
            return BadRequest("Game was blacked out.");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBallGames()
        {
            var allBallGames = await _gService.GetGames();
            return Ok(allBallGames);
            
        }

        [HttpGet]
        [Route("/currentGame/{gameId}")]
        public async Task<IActionResult> GetGamesById(int gameId)
        {
            if (gameId < 1)
            {
                return BadRequest();
            }
            var game = await _gService.GetGameById(gameId);
            if (game is null)
            {
                return NotFound();
            }
            return Ok(game);
        }
    }
