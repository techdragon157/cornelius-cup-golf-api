using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;
using CorneliusCup.Golf.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly CorneliusCupDbContext _context;
        private readonly IMapper _mapper;

        public PlayerService(CorneliusCupDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerResponse>> GetPlayers()
        {
            var players = await _context.Players
                .ToListAsync();

            return _mapper.Map<List<PlayerResponse>>(players);
        }

        public async Task<PlayerResponse> CreatePlayer(PlayerRequest playerRequest)
        {
            var player = _mapper.Map<Player>(playerRequest);
            var trackedVenue = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();

            return _mapper.Map<PlayerResponse>(trackedVenue.Entity);
        }

        public async Task<PlayerResponse> GetPlayer(int playerId)
        {
            var player = await _context.Players
                .SingleAsync(x => x.PlayerId == playerId);

            return _mapper.Map<PlayerResponse>(player);
        }

        public async Task<int> UpdatePlayer(int playerId, PlayerRequest playerRequest)
        {
            var player = await _context.Players
                .SingleAsync(x => x.PlayerId == playerId);

            _mapper.Map(playerRequest, player);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePlayer(int playerId)
        {
            var player = await _context.Players
                .SingleAsync(x => x.PlayerId == playerId);

            _context.Remove(player);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ScoreCardResponse>> GetScoreCards(int playerId)
        {
            var scoreCards = await _context.ScoreCards.ToListAsync();

            return _mapper.Map<List<ScoreCardResponse>>(scoreCards);
        }

        public async Task<ScoreCardResponse> CreateScoreCard(int playerId, ScoreCardRequest scoreCardRequest)
        {
            var player = await _context.Players
                .SingleAsync(x => x.PlayerId == playerId);

            var competition = await _context.Competitions
                .SingleAsync(x => x.CompetitionId == scoreCardRequest.CompetitionId);

            var venue = await _context.Venues
                .SingleAsync(x => x.VenueId == scoreCardRequest.VenueId);

            var golfCourse = await _context.GolfCourses
                .SingleAsync(x => x.GolfCourseId == scoreCardRequest.GolfCourseId);

            var scoreCard = _mapper.Map<ScoreCard>(scoreCardRequest);
            scoreCard.Player = player;
            scoreCard.Competition = competition;
            scoreCard.Venue = venue;
            scoreCard.GolfCourse = golfCourse;

            var trackedScoreCard = await _context.ScoreCards.AddAsync(scoreCard);

            await _context.SaveChangesAsync();

            return _mapper.Map<ScoreCardResponse>(trackedScoreCard.Entity);
        }

        public async Task<ScoreCardResponse> GetScoreCard(int playerId, int scoreCardId)
        {
            var scoreCard = await _context.ScoreCards
                .Where(x => x.PlayerId == playerId)
                .Where(x => x.ScoreCardId == scoreCardId)
                .SingleAsync();

            return _mapper.Map<ScoreCardResponse>(scoreCard);
        }
    }
}
