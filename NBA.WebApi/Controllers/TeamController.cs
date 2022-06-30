using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _tService;
        public TeamController(ITeamService teamService)
        {
            _tService = teamService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody]TeamCreate req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (await _tService.CreateTeamAsync(req))
            {
                return Ok("Team was created!");
            }
            return BadRequest("Team could not be created!");
        }

        [HttpGet("GetPlayerByTeam/{teamId:int}")]
        public async Task<IActionResult> GetPlayersFromTeam([FromRoute] int teamId)
        {
            var playerList = await _tService.GetPlayersByTeam(teamId);
            return playerList is not null ? Ok(playerList) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _tService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("GetTeamByOwner/{TeamOwner}")]
        public async Task<IActionResult> GetTeamByTeamOwner([FromRoute] string TeamOwner)
        {
            var detail = await _tService.GetTeamByOwnerAsync(TeamOwner);
            return detail is not null
            ? Ok(detail)
            : NotFound();
        }

        [HttpGet("GetTeamByName/{TeamName}")]
        public async Task<IActionResult> GetTeamByTeamName([FromRoute] string TeamName)
        {
            var detail = await _tService.GetTeamByTeamName(TeamName);
            return detail is not null
            ? Ok(detail)
            : NotFound();
        }

        [HttpGet("GetTeamByMascot/{Mascot:int}")]
        public async Task<IActionResult> GetTeamByMascot([FromRoute] Mascot Mascot)
        {
            var teamMascotType = await _tService.GetTeamByMascotAsync(Mascot);
            return teamMascotType is not null ? Ok(teamMascotType) : NotFound();
        }

        [HttpGet("GetTeamByLocations/{Location:int}")]
        public async Task<IActionResult> GetTeamByLocations([FromRoute] Locations Location)
        {
            var teamLocationsType = await _tService.GetTeamByLocation(Location);
            return teamLocationsType is not null ? Ok(teamLocationsType) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeamById([FromBody] TeamUpdate req)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return await _tService.UpdateTeamAsync(req)? Ok("Team was upated") : BadRequest("Team was not updated");
        }

        [HttpDelete("{teamId:int}")]
        public async Task<IActionResult> DeleteTeam([FromRoute] int teamId)
        {
            return await _tService.DeleteTeamByIdAsync(teamId)
                ? Ok($"Team {teamId} has been removed!")
                : BadRequest($"Tream {teamId} could not be removed!");
        }    

    }
