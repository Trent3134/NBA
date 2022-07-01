using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


 
public class GameService : IGameService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GameService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> CreateGame(GameCreate req)
    {
        if (req is null)
        {
            return false;
        }
        var entity = new Game
        {
            TeamAId = req.TeamAId,
            TeamBId = req.TeamBId
        };
        _context.Games.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<GameDetail>> GetGames()
    {
        var allGames = await _context.Games.ToListAsync();
        var gameList = _mapper.Map<List<GameDetail>>(allGames);
        return gameList;
    }

    public async Task<GameDetail> GetGameById(int gameId)
    {
        var game = await _context.Games.FindAsync(gameId);
        if (game is not null)
        {
            var teamA =  await _context.Teams.FindAsync(game.TeamAId);
            if (teamA is null)
            {
                return null;
            }

            var conversionA = _mapper.Map<TeamDetail>(teamA);
            
            var teamB = await _context.Teams.FindAsync(game.TeamBId);
            if (teamB is null)
            {
                return null;
            }
            var conversionB = _mapper.Map<TeamDetail>(teamB);

            return  new GameDetail()
            {
                GameId = game.Id,
                TeamAInfo = conversionA,
                TeamBInfo = conversionB,
                
            };
        }
        return null;
    }
}
