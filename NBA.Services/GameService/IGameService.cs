using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IGameService
    {
        Task<bool> CreateGame(GameCreate req);
        Task<IEnumerable<GameDetail>> GetGames();

        Task<GameDetail> GetGameById(int gameId);
    }
