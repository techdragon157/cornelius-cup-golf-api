using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;
using CorneliusCup.Golf.API.Services.Interfaces;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace CorneliusCup.Golf.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IHashids _hashids;
        private readonly ILogger<PlayersController> _logger;

        public PlayersController(IPlayerService playerService, IHashids hashids, ILogger<PlayersController> logger)
        {
            _playerService = playerService;
            _hashids = hashids;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation("Get a list of all Players")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<PlayerResponse>>> GetPlayers()
        {
            var playersResponse = await _playerService.GetPlayers();

            return Ok(new Response<PlayerResponse>(playersResponse));
        }

        [HttpPost]
        [SwaggerOperation("Create a new Player")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PlayerResponse>> CreatePlayer(PlayerRequest playerRequest)
        {
            PlayerResponse playerResponse = await _playerService.CreatePlayer(playerRequest);

            if (playerResponse is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetPlayer), new { playerId = playerResponse.Id }, playerResponse);
        }

        [HttpGet]
        [SwaggerOperation("Get a single Player")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayerResponse>> GetPlayer(string playerId)
        {
            var rawPlayerId = _hashids.Decode(playerId);
            
            if(rawPlayerId.Length == 0)
            {
                return NotFound();
            }

            var playerResponse = await _playerService.GetPlayer(rawPlayerId[0]);

            if (playerResponse is null)
            {
                return NotFound();
            }

            return Ok(playerResponse);
        }

        [HttpPut]
        [SwaggerOperation("Update a Player")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdatePlayer(string playerId, PlayerRequest playerRequest)
        {
            var rawPlayerId = _hashids.Decode(playerId);
            
            if (rawPlayerId.Length == 0)
            {
                return NotFound();
            }

            var result = await _playerService.UpdatePlayer(rawPlayerId[0], playerRequest);

            if (result is null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation("Delete a Player")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePlayer(string playerId)
        {
            var rawPlayerId = _hashids.Decode(playerId);
            
            if (rawPlayerId.Length == 0)
            {
                return NotFound();
            }

            var result = await _playerService.DeletePlayer(rawPlayerId[0]);

            if (result is null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [SwaggerOperation("Get a list of all Score Cards")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}/scorecards")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<ScoreCardResponse>>> GetPlayerScoreCards(string playerId)
        {
            var rawPlayerId = _hashids.Decode(playerId);
            
            if (rawPlayerId.Length == 0)
            {
                return NotFound();
            }

            var scoreCardResponse = await _playerService.GetScoreCards(rawPlayerId[0]);

            if(scoreCardResponse is null)
            {
                return NotFound();
            }

            return Ok(new Response<ScoreCardResponse>(scoreCardResponse));
        }

        [HttpPost]
        [SwaggerOperation("Create a new Score Card")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}/scorecards")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ScoreCardResponse>> CreatePlayerScoreCard(string playerId, ScoreCardRequest scoreCardRequest)
        {
            var rawPlayerId = _hashids.Decode(playerId);
            
            if (rawPlayerId.Length == 0)
            {
                return NotFound();
            }

            var scoreCardResponse = await _playerService.CreateScoreCard(rawPlayerId[0], scoreCardRequest);

            if(scoreCardResponse is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetPlayerScoreCard), new { playerId = playerId, scoreCardId = scoreCardResponse.Id }, scoreCardResponse);
        }

        [HttpGet]
        [SwaggerOperation("Get a single Score Card")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}/scorecards/{scoreCardId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ScoreCardResponse>> GetPlayerScoreCard(string playerId, string scoreCardId)
        {
            var rawPlayerId = _hashids.Decode(playerId);
            var rawScoreCardId = _hashids.Decode(scoreCardId);
            if (rawPlayerId.Length == 0 || rawScoreCardId.Length == 0)
            {
                return NotFound();
            }

            var scoreCardResponse = await _playerService.GetScoreCard(rawPlayerId[0], rawScoreCardId[0]);

            if(scoreCardResponse is null)
            {
                return NotFound();
            }

            return Ok(scoreCardResponse);
        }

        [HttpPut]
        [SwaggerOperation("Update a Score Card")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}/scorecards/{scoreCardId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ScoreCardResponse>> CreatePlayerScoreCard(string playerId, string scoreCardId, ScoreCardRequest scoreCardRequest)
        {
            var rawPlayerId = _hashids.Decode(playerId);
            var rawScoreCardId = _hashids.Decode(scoreCardId);
            if (rawPlayerId.Length == 0 || rawScoreCardId.Length == 0)
            {
                return NotFound();
            }

            var result = await _playerService.UpdateScoreCard(rawPlayerId[0], rawScoreCardId[0], scoreCardRequest);

            if (result is null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation("Delete a ScoreCard")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}/scorecards/{scoreCardId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteScoreCard(string playerId, string scoreCardId)
        {
            var rawPlayerId = _hashids.Decode(playerId);
            var rawScoreCardId = _hashids.Decode(scoreCardId);
            if (rawPlayerId.Length == 0 || rawScoreCardId.Length == 0)
            {
                return NotFound();
            }

            var result = await _playerService.DeleteScoreCard(rawPlayerId[0], rawScoreCardId[0]);

            if (result is null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
