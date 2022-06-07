using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Extensions;
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
            var players = await _context.Players.ToListAsync();

            return _mapper.Map<List<PlayerResponse>>(players);
        }

        public async Task<PlayerResponse> CreatePlayer(PlayerRequest playerRequest)
        {
            var player = _mapper.Map<Player>(playerRequest);

            var trackedVenue = await _context.Players.AddAsync(player);

            await _context.SaveChangesAsync();

            return _mapper.Map<PlayerResponse>(trackedVenue.Entity);
        }

        public async Task<PlayerResponse?> GetPlayer(int playerId)
        {
            var player = await _context.Players
                .SingleOrDefaultAsync(x => x.PlayerId == playerId);

            if(player is null)
            {
                return null;
            }

            return _mapper.Map<PlayerResponse>(player);
        }

        public async Task<int?> UpdatePlayer(int playerId, PlayerRequest playerRequest)
        {
            var player = await _context.Players
                .SingleOrDefaultAsync(x => x.PlayerId == playerId);

            if (player is null)
            {
                return null;
            }

            _mapper.Map(playerRequest, player);

            return await _context.SaveChangesAsync();
        }

        public async Task<int?> DeletePlayer(int playerId)
        {
            var player = await _context.Players
                .SingleOrDefaultAsync(x => x.PlayerId == playerId);

            if (player is null)
            {
                return null;
            }

            _context.Remove(player);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ScoreCardResponse>?> GetScoreCards(int playerId)
        {
            var player = await _context.Players
                .SingleOrDefaultAsync(x => x.PlayerId == playerId);

            if (player is null)
            {
                return null;
            }

            var scoreCards = await _context.ScoreCards
                .Where(x => x.PlayerId == playerId)
                .ToListAsync();

            return _mapper.Map<List<ScoreCardResponse>>(scoreCards);
        }

        public async Task<ScoreCardResponse?> CreateScoreCard(int playerId, ScoreCardRequest scoreCardRequest)
        {
            var player = await _context.Players
                .SingleOrDefaultAsync(x => x.PlayerId == playerId);

            var competition = await _context.Competitions
                .SingleOrDefaultAsync(x => x.CompetitionId == scoreCardRequest.CompetitionId);

            var golfCourse = await _context.GolfCourses
                .SingleOrDefaultAsync(x => x.GolfCourseId == scoreCardRequest.GolfCourseId);

            if (player is null || competition is null || golfCourse is null)
            {
                return null;
            }

            var scoreCard = _mapper.Map<ScoreCard>(scoreCardRequest);

            scoreCard.Player = player;
            scoreCard.Competition = competition;
            scoreCard.GolfCourse = golfCourse;

            scoreCard.CalculateScores();

            var trackedScoreCard = await _context.ScoreCards.AddAsync(scoreCard);

            await _context.SaveChangesAsync();

            return _mapper.Map<ScoreCardResponse>(trackedScoreCard.Entity);
        }

        public async Task<ScoreCardResponse?> GetScoreCard(int playerId, int scoreCardId)
        {
            var scoreCard = await _context.ScoreCards
                .Where(x => x.PlayerId == playerId)
                .Where(x => x.ScoreCardId == scoreCardId)
                .SingleOrDefaultAsync();

            if (scoreCard is null)
            {
                return null;
            }

            return _mapper.Map<ScoreCardResponse>(scoreCard);
        }

        public async Task<int?> UpdateScoreCard(int playerId, int scoreCardId, ScoreCardRequest scoreCardRequest)
        {
            var scoreCard = await _context.ScoreCards
                .Where(x => x.PlayerId == playerId)
                .Where(x => x.ScoreCardId == scoreCardId)
                .SingleOrDefaultAsync();

            if (scoreCard is null)
            {
                return null;
            }

            _mapper.Map(scoreCardRequest, scoreCard);

            return await _context.SaveChangesAsync();
        }

        public async Task<int?> DeleteScoreCard(int playerId, int scoreCardId)
        {
            var scoreCard = await _context.ScoreCards
                .Where(x => x.PlayerId == playerId)
                .Where(x => x.ScoreCardId == scoreCardId)
                .SingleOrDefaultAsync();

            if (scoreCard is null)
            {
                return null;
            }

            _context.Remove(scoreCard);

            return await _context.SaveChangesAsync();
        }
    }
}
