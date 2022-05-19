using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;
using CorneliusCup.Golf.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<PlayersController> _logger;

        public PlayersController(IPlayerService playerService, ILogger<PlayersController> logger)
        {
            _playerService = playerService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation("Get a list of all Players")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<PlayerResponse>>> GetVenues()
        {
            var venuesResponse = await _playerService.GetPlayers();

            return Ok(new Response<PlayerResponse>(venuesResponse));
        }

        [HttpPost]
        [SwaggerOperation("Create a new Player")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PlayerResponse>> CreateVenue(PlayerRequest playerRequest)
        {
            PlayerResponse playerResponse;

            try
            {
                playerResponse = await _playerService.CreatePlayer(playerRequest);
            }
            catch (DbUpdateException ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }

            return CreatedAtAction(nameof(GetPlayer), new { playerId = playerResponse.Id }, playerResponse);
        }

        [HttpGet]
        [SwaggerOperation("Get a single Player")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayerResponse>> GetPlayer(int playerId)
        {
            PlayerResponse playerResponse;

            try
            {
                playerResponse = await _playerService.GetPlayer(playerId);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
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
        public async Task<ActionResult> UpdateVenue(int playerId, PlayerRequest playerRequest)
        {
            try
            {
                await _playerService.UpdatePlayer(playerId, playerRequest);
            }
            catch (DbUpdateException ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation("Delete a Player")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteVenue(int playerId)
        {
            try
            {
                await _playerService.DeletePlayer(playerId);
            }
            catch (DbUpdateException ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return NoContent();
        }

        [HttpGet]
        [SwaggerOperation("Get a list of all Score Cards")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}/scorecards")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<ScoreCardResponse>>> GetPlayerScoreCards(int playerId)
        {
            IEnumerable<ScoreCardResponse> scoreCardResponse;

            try
            {
                scoreCardResponse = await _playerService.GetScoreCards(playerId);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
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
        public async Task<ActionResult<ScoreCardResponse>> CreatePlayerScoreCard(int playerId, ScoreCardRequest scoreCardRequest)
        {
            ScoreCardResponse scoreCardResponse;

            try
            {
                scoreCardResponse = await _playerService.CreateScoreCard(playerId, scoreCardRequest);
            }
            catch (DbUpdateException ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return CreatedAtAction(nameof(GetPlayerScoreCard), new { playerId = playerId, scoreCardId = scoreCardResponse.Id }, scoreCardResponse);
        }

        [HttpGet]
        [SwaggerOperation("Get a single Score Card")]
        [MapToApiVersion("1.0")]
        [Route("{playerId}/scorecards/{scoreCardId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ScoreCardResponse>> GetPlayerScoreCard(int playerId, int scoreCardId)
        {
            ScoreCardResponse scoreCardResponse;

            try
            {
                scoreCardResponse = await _playerService.GetScoreCard(playerId, scoreCardId);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return Ok(scoreCardResponse);
        }

    }
}
