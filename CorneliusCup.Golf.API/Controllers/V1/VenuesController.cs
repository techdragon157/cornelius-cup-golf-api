using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;
using CorneliusCup.Golf.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<VenueResponse>>> GetVenues()
        {
            var venuesResponse = await _venueService.GetVenues();

            return Ok(new Response<VenueResponse>(venuesResponse));
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VenueResponse>> CreateVenue(VenueRequest venueRequest)
        {
            try
            {
                var venueResponse = await _venueService.CreateVenue(venueRequest);

                return CreatedAtAction(nameof(GetVenue), new { venueId = venueResponse.Id }, venueResponse);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VenueResponse>> GetVenue(int venueId)
        {
            var venueResponse = await _venueService.GetVenue(venueId);

            if (venueResponse is null)
            {
                return NotFound();
            }

            return Ok(venueResponse);
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [Route("{venueId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VenueResponse>> UpdateVenue(int venueId, VenueRequest venueRequest)
        {
            try
            {
                var result = await _venueService.UpdateVenue(venueId, venueRequest);

                if (result is null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        [Route("{venueId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteVenue(int venueId)
        {
            try
            {
                var result = await _venueService.DeleteVenue(venueId);

                if (result is null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<GolfCourseResponse>>> GetVenueGolfCourses(int venueId)
        {
            var golfCourseResponse = await _venueService.GetGolfCourses(venueId);

            if (golfCourseResponse is null)
            {
                return NotFound();
            }

            return Ok(new Response<GolfCourseResponse>(golfCourseResponse));
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GolfCourseResponse>> CreateVenueGolfCourse(int venueId, GolfCourseRequest golfCourseRequest)
        {
            try
            {
                var golfCourseResponse = await _venueService.CreateGolfCourse(venueId, golfCourseRequest);

                if (golfCourseResponse is null)
                {
                    return NotFound();
                }

                return CreatedAtAction(nameof(GetVenueGolfCourse), new { venueId = golfCourseResponse.Id }, golfCourseResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses/{golfCourseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GolfCourseResponse>> GetVenueGolfCourse(int venueId, int golfCourseId)
        {
            var golfCourseResponse = await _venueService.GetGolfCourse(venueId, golfCourseId);

            if (golfCourseResponse is null)
            {
                return NotFound();
            }

            return Ok(golfCourseResponse);
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses/{golfCourseId}/tees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<TeeResponse>>> GetVenueGolfCourseTees(int venueId, int golfCourseId)
        {
            var teeResponse = await _venueService.GetGolfCourseTees(venueId, golfCourseId);

            if (teeResponse is null)
            {
                return NotFound();
            }

            return Ok(new Response<TeeResponse>(teeResponse));
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses/{golfCourseId}/tees/{teeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeeResponse>> GetVenueGolfCourseTee(int venueId, int golfCourseId, int teeId)
        {
            var teeResponse = await _venueService.GetGolfCourseTee(venueId, golfCourseId, teeId);

            if (teeResponse is null)
            {
                return NotFound();
            }

            return Ok(teeResponse);
        }
    }
}
