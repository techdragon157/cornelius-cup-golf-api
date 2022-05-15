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
    public class VenuesController : ControllerBase
    {
        private readonly IVenueService _venueService;
        private readonly ILogger<VenuesController> _logger;

        public VenuesController(IVenueService venueService, ILogger<VenuesController> logger)
        {
            _venueService = venueService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation("Get a list of all Venues")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<VenueResponse>>> GetVenues()
        {
            var venuesResponse = await _venueService.GetVenues();

            return Ok(new Response<VenueResponse>(venuesResponse));
        }

        [HttpPost]
        [SwaggerOperation("Create a new Venue")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VenueResponse>> CreateVenue(VenueRequest venueRequest)
        {
            VenueResponse venueResponse;

            try
            {
                venueResponse = await _venueService.CreateVenue(venueRequest);
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
        public async Task<ActionResult<VenueResponse>> GetVenue(int venueId)
        {
            VenueResponse venueResponse;

            try
            {
                venueResponse = await _venueService.GetVenue(venueId);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VenueResponse>> UpdateVenue(int venueId, VenueRequest venueRequest)
        {
            try
            {
                await _venueService.UpdateVenue(venueId, venueRequest);
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
        public async Task<ActionResult> DeleteVenue(int venueId)
        {
            try
            {
                await _venueService.DeleteVenue(venueId);
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
        public async Task<ActionResult<Response<GolfCourseResponse>>> GetVenueGolfCourses(int venueId)
        {
            IEnumerable<GolfCourseResponse> golfCourseResponse;

            try
            {
                golfCourseResponse = await _venueService.GetGolfCourses(venueId);
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
        public async Task<ActionResult<GolfCourseResponse>> CreateVenueGolfCourse(int venueId, GolfCourseRequest golfCourseRequest)
        {
            GolfCourseResponse golfCourseResponse;

            try
            {
                golfCourseResponse = await _venueService.CreateGolfCourse(venueId, golfCourseRequest);
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
        public async Task<ActionResult<GolfCourseResponse>> GetVenueGolfCourse(int venueId, int golfCourseId)
        {
            GolfCourseResponse golfCourseResponse;

            try
            {
                golfCourseResponse = await _venueService.GetGolfCourse(venueId, golfCourseId);              
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
        public async Task<ActionResult<Response<TeeResponse>>> GetVenueGolfCourseTees(int venueId, int golfCourseId)
        {
            IEnumerable<TeeResponse> teeResponse;

            try
            {
                teeResponse = await _venueService.GetGolfCourseTees(venueId, golfCourseId);
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
        [Route("{venueId}/golfcourses/{golfCourseId}/tees/{teeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeeResponse>> GetVenueGolfCourseTee(int venueId, int golfCourseId, int teeId)
        {
            TeeResponse teeResponse;

            try
            {
                teeResponse = await _venueService.GetGolfCourseTee(venueId, golfCourseId, teeId);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message, statusCode: 404);
            }

            return Ok(teeResponse);
        }
    }
}
