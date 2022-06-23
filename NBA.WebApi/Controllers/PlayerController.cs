using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
    public class PlayerController: ControllerBase
    {
        private readonly IPlayerService _pService;
        public PlayerController(IPlayerService pService)
        {
            _pService = pService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerCreate req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (await _pService.CreatePlayerAsync(req))
            {
                return Ok("Player was successfully added!");
            }
            return BadRequest("Player could not be added.");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var allPlayers = await _pService.GetAllPlayersAsync();
            return Ok(allPlayers);
        }
        [HttpGet("PlayerByPosition/{Positions:int}")]
        public async Task<IActionResult> GetAllPlayersByPos([FromRoute] Positions Positions)
        {
            var playerPosType = await _pService.GetPlayersByPosition(Positions);
            return playerPosType is null ? Ok(playerPosType) : NotFound();
        }

        [HttpGet("playerByJerseyNumber/{JerseyNumber:int}")]
        public async Task<IActionResult> GetAllPlayersByJerseyNum([FromRoute]int JerseyNumber)
        {
            var playerJerseyNumber = await _pService.GetPlayerByNumberAsync(JerseyNumber);
            return playerJerseyNumber is null ? Ok(playerJerseyNumber) : NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlayerInfo([FromBody] PlayerUpdate req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return await _pService.UpdatePlayerAsync(req) ? Ok($"{req.Name} was updated"): BadRequest("Player could not be updated.");
        }
    }
