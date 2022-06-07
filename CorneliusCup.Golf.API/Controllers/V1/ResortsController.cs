using CorneliusCup.Golf.API.Enums;
using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;
using CorneliusCup.Golf.API.Services.Interfaces;
using HashidsNet;
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
    public class ResortsController : ControllerBase
    {
        private readonly IResortService _resortService;
        private readonly IHashids _hashids;
        private readonly ILogger<ResortsController> _logger;

        public ResortsController(IResortService resortService, IHashids hashids, ILogger<ResortsController> logger)
        {
            _resortService = resortService;
            _hashids = hashids;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation("Get a list of all Venues")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<ResortResponse>>> GetVenues()
        {
            var venuesResponse = await _resortService.GetResorts();

            return Ok(new Response<ResortResponse>(venuesResponse));
        }

        [HttpPost]
        [SwaggerOperation("Create a new Venue")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResortResponse>> CreateVenue(ResortRequest venueRequest)
        {
            ResortResponse venueResponse;

            try
            {
                venueResponse = await _resortService.CreateResort(venueRequest);
            }
            catch (DbUpdateException ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }

            return CreatedAtAction(nameof(GetVenue), new { venueId = venueResponse.Id }, venueResponse);
        }

        [HttpGet]
        [SwaggerOperation("Get a single Venue")]
        [MapToApiVersion("1.0")]
        [Route("{venueId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResortResponse>> GetVenue(string venueId)
        {
            var rawVenueId = _hashids.Decode(venueId);

            if (rawVenueId.Length == 0)
            {
                return NotFound();
            }

            ResortResponse venueResponse;

            try
            {
                venueResponse = await _resortService.GetResort(rawVenueId[0]);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return Ok(venueResponse);
        }

        [HttpPut]
        [SwaggerOperation("Update a Venue")]
        [MapToApiVersion("1.0")]
        [Route("{venueId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateVenue(string venueId, ResortRequest venueRequest)
        {
            var rawVenueId = _hashids.Decode(venueId);

            if (rawVenueId.Length == 0)
            {
                return NotFound();
            }

            try
            {
                await _resortService.UpdateResort(rawVenueId[0], venueRequest);
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
        [SwaggerOperation("Delete a Venue")]
        [MapToApiVersion("1.0")]
        [Route("{venueId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteVenue(string venueId)
        {
            var rawVenueId = _hashids.Decode(venueId);

            if (rawVenueId.Length == 0)
            {
                return NotFound();
            }

            try
            {
                await _resortService.DeleteResort(rawVenueId[0]);
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
        [SwaggerOperation("Get a list of all Golf Courses")]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<GolfCourseResponse>>> GetVenueGolfCourses(string venueId)
        {
            var rawVenueId = _hashids.Decode(venueId);

            if (rawVenueId.Length == 0)
            {
                return NotFound();
            }

            IEnumerable<GolfCourseResponse> golfCourseResponse;

            try
            {
                golfCourseResponse = await _resortService.GetGolfCourses(rawVenueId[0]);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return Ok(new Response<GolfCourseResponse>(golfCourseResponse));
        }

        [HttpPost]
        [SwaggerOperation("Create a new Golf Course")]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GolfCourseResponse>> CreateVenueGolfCourse(string venueId, GolfCourseRequest golfCourseRequest)
        {
            var rawVenueId = _hashids.Decode(venueId);

            if (rawVenueId.Length == 0)
            {
                return NotFound();
            }

            GolfCourseResponse golfCourseResponse;

            try
            {
                golfCourseResponse = await _resortService.CreateGolfCourse(rawVenueId[0], golfCourseRequest);
            }
            catch (DbUpdateException ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return CreatedAtAction(nameof(GetVenueGolfCourse), new { venueId = venueId, golfCourseId = golfCourseResponse.Id }, golfCourseResponse);
        }

        [HttpGet]
        [SwaggerOperation("Get a single Golf Course")]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses/{golfCourseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GolfCourseResponse>> GetVenueGolfCourse(string venueId, string golfCourseId)
        {
            var rawVenueId = _hashids.Decode(venueId);
            var rawGolfCourseId = _hashids.Decode(golfCourseId);
            if (rawVenueId.Length == 0 || rawGolfCourseId.Length == 0)
            {
                return NotFound();
            }

            GolfCourseResponse golfCourseResponse;

            try
            {
                golfCourseResponse = await _resortService.GetGolfCourse(rawVenueId[0], rawGolfCourseId[0]);              
            }
            catch(InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return Ok(golfCourseResponse);
        }

        [HttpGet]
        [SwaggerOperation("Get a list of all Tees on a Golf Course")]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses/{golfCourseId}/tees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<TeeResponse>>> GetVenueGolfCourseTees(string venueId, string golfCourseId)
        {
            var rawVenueId = _hashids.Decode(venueId);
            var rawGolfCourseId = _hashids.Decode(golfCourseId);
            if (rawVenueId.Length == 0 || rawGolfCourseId.Length == 0)
            {
                return NotFound();
            }

            IEnumerable<TeeResponse> teeResponse;

            try
            {
                teeResponse = await _resortService.GetGolfCourseTees(rawVenueId[0], rawGolfCourseId[0]);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return Ok(new Response<TeeResponse>(teeResponse));
        }

        [HttpGet]
        [SwaggerOperation("Get a single Tee on a Golf Course")]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses/{golfCourseId}/tees/{teeType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeeResponse>> GetVenueGolfCourseTee(string venueId, string golfCourseId, TeeType teeType)
        {
            var rawVenueId = _hashids.Decode(venueId);
            var rawGolfCourseId = _hashids.Decode(golfCourseId);
            if (rawVenueId.Length == 0 || rawGolfCourseId.Length == 0)
            {
                return NotFound();
            }

            TeeResponse teeResponse;

            try
            {
                teeResponse = await _resortService.GetGolfCourseTee(rawVenueId[0], rawGolfCourseId[0], teeType.ToString());
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return Ok(teeResponse);
        }
    }
}
