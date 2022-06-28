using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(PlayerCreate req);
        Task<IEnumerable<PlayerListItem>> GetAllPlayersAsync();
        Task<IEnumerable<PlayerDetail>> GetPlayersByPositionAsync(Positions Positions);
        Task<IEnumerable<PlayerDetail>> GetPlayerByNumberAsync(int JerseyNumber);
        Task<bool> UpdatePlayerAsync(PlayerUpdate req);
        Task<bool> DeletePlayer(int Id);

    }
