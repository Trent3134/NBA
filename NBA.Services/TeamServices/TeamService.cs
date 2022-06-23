using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public TeamService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateTeamAsync(TeamCreate req)
        {
            var newTeam = _mapper.Map<TeamEntity>(req);
            _context.Add(newTeam);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<TeamListItem>> GetTeamListItemsAsync()
        {
            var teamListItem = await _context.Teams.ToListAsync();
            var teamList = _mapper.Map<List<TeamListItem>>(teamListItem);

            return teamList;
        }

        public async Task<bool> UpdateTeamAsync (TeamUpdate req)
        {
            var teamEntity = await _context.Teams
            .FirstOrDefaultAsync(e =>
            e.Id == req.Id);
            if (teamEntity == null)
            {
                return false;
            }
            var newEntity = _mapper.Map(req, teamEntity);
            _context.Teams.Update(newEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteTeamAsync(int teamId)
        {
            var teamEntity = await _context.Teams.FindAsync(teamId);
            if (teamEntity == null)
            {
                return false;
            }
            _context.Teams.Remove(teamEntity);
            return await _context.SaveChangesAsync() == 1;
        }

    public Task<IEnumerable<TeamListItem>> GetAllTeamsAsync()
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteTeamByIdAsync(int teamId)
    {
        throw new NotImplementedException();
    }
}
