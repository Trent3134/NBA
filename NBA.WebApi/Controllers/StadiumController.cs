using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;
        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStadiums([FromBody] StadiumCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (await _stadiumService.CreateStadiumAsync(request))
                return Ok("Stadium created successfully.");

            return BadRequest("Stadium could not be created.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStadiums()
        {
            var stadiums = await _stadiumService.GetAllStadiumsAsync();
            return Ok(stadiums);
        }

        [HttpGet("{stadiumId:int}")]
        public async Task<IActionResult> GetStadiumById([FromRoute] int stadiumId)
        {
            var detail = await _stadiumService.GetStadiumById(stadiumId);

            return detail is not null
            ? Ok(detail)
            : NotFound();
        }

        [HttpDelete("{stadiumId:int}")]
        public async Task<IActionResult> DeleteStadium([FromRoute] int stadiumId)
        {
            return await _stadiumService.DeleteStadiumAsync(stadiumId)
            ? Ok("Stadium was deleted")
            : BadRequest("Stadium could not be deleted");
        }
    }
