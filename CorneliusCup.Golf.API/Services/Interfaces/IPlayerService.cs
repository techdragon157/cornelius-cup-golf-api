using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;

namespace CorneliusCup.Golf.API.Services.Interfaces
{
    public interface IPlayerService
    {
        public Task<IEnumerable<PlayerResponse>> GetPlayers();

        public Task<PlayerResponse> CreatePlayer(PlayerRequest playerRequest);

        public Task<PlayerResponse> GetPlayer(int playerId);

        public Task<int> UpdatePlayer(int playerId, PlayerRequest playerRequest);

        public Task<int> DeletePlayer(int playerId);
    }
}
