using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Responses;
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
        private readonly CorneliusCupDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<VenuesController> _logger;

        public VenuesController(CorneliusCupDbContext context, IMapper mapper, ILogger<VenuesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<VenueResponse>>> GetAllVenues()
        {
            var venues = await _context.Venues
                .ToListAsync();

            var venuesResponse = _mapper.Map<List<VenueResponse>>(venues);

            return Ok(new Response<VenueResponse>(venuesResponse));
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VenueResponse>> GetVenue(int venueId)
        {
            var venue = await _context.Venues
                .SingleOrDefaultAsync(x => x.VenueId == venueId);
            
            if (venue is null)
            {
                return NotFound();
            }

            var venueResponse = _mapper.Map<VenueResponse>(venue);

            return Ok(venueResponse);
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<GolfCourseResponse>>> GetVenueGolfCourses(int venueId)
        {
            var venue = await _context.Venues
                .Include(x=> x.GolfCourses)
                .Where(x => x.VenueId == venueId)
                .SingleOrDefaultAsync();

            if(venue is null)
            {
                return NotFound();
            }

            var golfCourseResponse = _mapper.Map<List<GolfCourseResponse>>(venue.GolfCourses);

            return Ok(new Response<GolfCourseResponse>(golfCourseResponse));
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses/{golfCourseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GolfCourseResponse>> GetVenueGolfCourse(int venueId, int golfCourseId)
        {
            var golfCourse = await _context.GolfCourses
                .Where(x => EF.Property<int>(x, "VenueId") == venueId)
                .Where(x => x.GolfCourseId == golfCourseId)
                .SingleOrDefaultAsync();

            if(golfCourse is null)
            {
                return NotFound();
            }

            var golfCourseResponse = _mapper.Map<GolfCourseResponse>(golfCourse);

            return Ok(golfCourseResponse);
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses/{golfCourseId}/tees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<TeeResponse>>> GetVenueGolfCourseTees(int venueId, int golfCourseId)
        {
            var golfCourse = await _context.GolfCourses
                .Where(x => EF.Property<int>(x, "VenueId") == venueId)
                .Where(x => x.GolfCourseId == golfCourseId)
                .SingleOrDefaultAsync();

            if (golfCourse is null)
            {
                return NotFound();
            }

            var teeResponse = _mapper.Map<List<TeeResponse>>(golfCourse.Tees);

            return Ok(new Response<TeeResponse>(teeResponse));
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("{venueId}/golfcourses/{golfCourseId}/tees/{teeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeeResponse>> GetVenueGolfCourseTee(int venueId, int golfCourseId, int teeId)
        {
            var golfCourse = await _context.GolfCourses
                .Where(x => EF.Property<int>(x, "VenueId") == venueId)
                .Where(x => x.GolfCourseId == golfCourseId)
                .SingleOrDefaultAsync();

            if (golfCourse is null)
            {
                return NotFound();
            }

            var tee = golfCourse.Tees.SingleOrDefault(x => x.TeeId == teeId);

            if (tee is null)
            {
                return NotFound();
            }

            var teeResponse = _mapper.Map<TeeResponse>(tee);

            return Ok(teeResponse);
        }

        //[HttpPost]
        //[MapToApiVersion("1.0")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<VenueResponse>> CreateVenue(Venue venue)
        //{
        //    try
        //    {
        //        var trackedVenue = await _context.Venues.AddAsync(venue);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction(nameof(GetVenue), new { venueId = trackedVenue.Entity.VenueId }, GetVenue(trackedVenue.Entity.VenueId));
        //    } 
        //    catch (DbUpdateException)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
