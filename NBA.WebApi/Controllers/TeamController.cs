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

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _tService.GetAllTeamsAsync();
            return Ok(teams);
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

    }
