using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public PlayerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreatePlayerAsync(PlayerCreate req)
        {
            var newPlayer = _mapper.Map<PlayersEntity>(req);
            _context.Add(newPlayer);
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<IEnumerable<PlayerListItem>> GetAllPlayersAsync()
        {
            var allPlayers = await _context.Players.ToListAsync();
            var playerList = _mapper.Map<List<PlayerListItem>>(allPlayers);
            return playerList;
        }
        public async Task<IEnumerable<PlayerDetail>> GetPlayersByPositionAsync(Positions Positions)
        {
            var players = await _context.Players.Where(p => p.Positions == Positions).ToListAsync();
            if (players is null)
            {
                return null;
            }
            return _mapper.Map<List<PlayerDetail>>(players);
        }
        public async Task<IEnumerable<PlayerDetail>> GetPlayerByNumberAsync(int JerseyNumber)
        {
            var playerNum = await _context.Players.Where(j => j.JerseyNumber == JerseyNumber).ToListAsync();
            if (playerNum is null)
            {
                return null;
            }
            return _mapper.Map<List<PlayerDetail>>(playerNum);
        }
        public async Task<bool> UpdatePlayerAsync(PlayerUpdate req)
        {
            var playerU = await _context.Players.FirstOrDefaultAsync(p => p.Name == req.Name);

            if (playerU == null)
            {
                return false;
            }
            var newPlayer1 = _mapper.Map(req, playerU);
            _context.Players.Update(playerU);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeletePlayer(int Id)
        {
            var playerDelete = await _context.Players.FindAsync(Id);
            if (playerDelete == null)
            {
                return false;
            }
            _context.Players.Remove(playerDelete);
            return await _context.SaveChangesAsync() == 1;
        }

    }
