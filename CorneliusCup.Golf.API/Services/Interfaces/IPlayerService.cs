using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;

namespace CorneliusCup.Golf.API.Services.Interfaces
{
    public interface IPlayerService
    {
        public Task<IEnumerable<PlayerResponse>> GetPlayers();

        public Task<PlayerResponse> CreatePlayer(PlayerRequest playerRequest);

        public Task<PlayerResponse?> GetPlayer(int playerId);

        public Task<int?> UpdatePlayer(int playerId, PlayerRequest playerRequest);

        public Task<int?> DeletePlayer(int playerId);

        public Task<IEnumerable<ScoreCardResponse>?> GetScoreCards(int playerId);

        public Task<ScoreCardResponse?> CreateScoreCard(int playerId, ScoreCardRequest scoreCardRequest);

        public Task<ScoreCardResponse?> GetScoreCard(int playerId, int scoreCardId);

        public Task<int?> UpdateScoreCard(int playerId, int scoreCardId, ScoreCardRequest scoreCardRequest);

        public Task<int?> DeleteScoreCard(int playerId, int scoreCardId);
    }
}
