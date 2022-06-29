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

    public async Task<IEnumerable<PlayerListItem>> GetPlayersByTeam(int teamId)
    {
        var teamPlayer = await _context.Players.Where(p => p.TeamEntityId == teamId).ToListAsync();
        if (teamPlayer is null)
        {
            return null;
        }
        return _mapper.Map<List<PlayerListItem>>(teamPlayer);
    }
    
    public async Task<IEnumerable<TeamListItem>> GetTeamByTeamName(string TeamName)
    {
        var team = await _context.Teams.Where(t => t.TeamName == TeamName).ToListAsync();
        if (team is null)
        {
            return null;
        }
        return _mapper.Map<List<TeamListItem>>(team);
    }

    public async Task<IEnumerable<TeamListItem>> GetTeamByLocation(Locations Location)
    {
        var teams = await _context.Teams.Where(t => t.Locations == Location).ToListAsync();
        if (teams is null)
        {
            return null;
        }
        return _mapper.Map<List<TeamListItem>>(teams);
    }

    public async Task<IEnumerable<TeamListItem>> GetTeamByTeamOwnerAsync(string TeamOwner)
    {
        var team = await _context.Teams.Where(t => t.TeamOwner == TeamOwner).ToListAsync();
        if (team is null)
        {
            return null;
        }
        return _mapper.Map<List<TeamListItem>>(team);
    }
    public async Task<IEnumerable<TeamListItem>> GetAllTeamsAsync()
    {
        var teamListItem = await _context.Teams.ToListAsync();
        var teamList = _mapper.Map<List<TeamListItem>>(teamListItem);

        return teamList;
    }
    public async Task<bool> UpdateTeamAsync(TeamUpdate req)
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
    public async Task<bool> DeleteTeamByIdAsync(int teamId)
    {
        var teamEntity = await _context.Teams.FindAsync(teamId);
        if (teamEntity == null)
        {
            return false;
        }
        _context.Teams.Remove(teamEntity);
        return await _context.SaveChangesAsync() == 1;
    }

}
