using Demo3.Db.Models;
using Demo3.Dto;
using Demo3.Dto.Players;
using Demo3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Demo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostPlayerAsync([FromBody] CreatePlayerRequest playerRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                await _playerService.CreatePlayerAsync(playerRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Record has been added successfully.");
        }


        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            var player = await _playerService.GetPlayersAsync(urlQueryParameters);
            //removed null validation check for brevity
            return Ok(player);
        }

        [HttpGet("{id:long}/detail")]
        public async Task<IActionResult> GetPlayerDetailAsync(int id)
        {
            var player = await _playerService.GetPlayerDetailAsync(id);
            //removed null validation check for brevity
            return Ok(player);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutPlayerAsync(int id, [FromBody] UpdatePlayerRequest playerRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var isUpdated = await _playerService.UpdatePlayerAsync(id, playerRequest);
            if (!isUpdated)
            {
                return NotFound($"PlayerId {id} not found.");
            }
            return Ok("Record has been updated successfully");
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeletePlayerAsync(int id)
        {
            var isDeleted = await _playerService.DeletePlayerAsync(id);
            if (!isDeleted)
            {
                return NotFound($"PlayerId {id} not found.");
            }
            return Ok("Record has been deleted successfully.");
        }


    }

}
