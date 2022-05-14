using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class GolfCourseController : ControllerBase
    {
        private readonly CorneliusCupDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GolfCourseController> _logger;

        public GolfCourseController(CorneliusCupDbContext context, IMapper mapper, ILogger<GolfCourseController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<VenueResponse>>> GetAllVenues()
        {
            //var value = await _context
            //    .Venues
            //    .Select(v => new VenueResponse
            //    {
            //        VenueId = v.VenueId,
            //        Name = v.Name,
            //        GolfCourses = v
            //            .GolfCourses
            //            .Select(g => new GolfCourseResponse
            //            {
            //                GolfCourseId = g.GolfCourseId,
            //                Name = g.Name,
            //                Tees = g
            //                    .Tees
            //                    .Select(t => new TeeResponse
            //                    {
            //                        CourseRating = t.CourseRating,
            //                        SlopeRating = t.SlopeRating,
            //                        Par = t.Par,
            //                        SSS = t.SSS,
            //                        TeeType = t.TeeType,
            //                        HoleDetails = t
            //                            .HoleDetails
            //                            .Select(h => new HoleDetailResponse
            //                            {
            //                                Number = h.Number,
            //                                Par = h.Par,
            //                                StrokeIndex = h.StrokeIndex,
            //                                Yards = h.Yards
            //                            })
            //                    })
            //            })
            //    }).ToListAsync();

            var venues = await _context.Venues.Include(x => x.GolfCourses).ToListAsync();
            var venuesResponse = _mapper.Map<List<VenueResponse>>(venues);
            return Ok(new Response<VenueResponse>(venuesResponse));

            //return Ok(new Response<VenueResponse>(value));
        }

        [HttpGet]
        [Route("{venueId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VenueResponse>> GetVenue(int venueId)
        {
            var value = await _context
                .Venues
                .Select(v => new VenueResponse
                {
                    VenueId = v.VenueId,
                    Name = v.Name,
                    GolfCourses = v
                        .GolfCourses
                        .Select(g => new GolfCourseResponse
                        {
                            GolfCourseId = g.GolfCourseId,
                            Name = g.Name,
                            Tees = g
                                .Tees
                                .Select(t => new TeeResponse
                                {
                                    CourseRating = t.CourseRating,
                                    SlopeRating = t.SlopeRating,
                                    Par = t.Par,
                                    SSS = t.SSS,
                                    TeeType = t.TeeType,
                                    HoleDetails = t
                                        .HoleDetails
                                        .Select(h => new HoleDetailResponse
                                        {
                                            Number = h.Number,
                                            Par = h.Par,
                                            StrokeIndex = h.StrokeIndex,
                                            Yards = h.Yards
                                        })
                                })
                        })
                }).SingleOrDefaultAsync(x => x.VenueId == venueId);

            if(value is null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VenueResponse>> CreateVenue(Venue venue)
        {
            try
            {
                var trackedVenue = await _context.Venues.AddAsync(venue);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVenue), new { venueId = trackedVenue.Entity.VenueId }, GetVenue(trackedVenue.Entity.VenueId));
            } 
            catch (DbUpdateException)
            {
                return BadRequest();
            }
        }
    }
}
