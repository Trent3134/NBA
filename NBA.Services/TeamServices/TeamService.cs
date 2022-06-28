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
    
    public async Task<TeamEntity> GetTeamByTeamName(string teamName)
    {
        var team = await _context.Teams.Where(team => team.TeamName == teamName).ToListAsync();
        if (team is null)
        {
            return null;
        }
        return _mapper.Map<TeamEntity>(team);
    }

    public async Task<IEnumerable<TeamDetail>> GetTeamByLocation(Locations locations)
    {
        var teams = await _context.Teams.Where(teams => teams.Location == locations).ToListAsync();
        if (teams is null)
        {
            return null;
        }
        return _mapper.Map<List<TeamDetail>>(teams);
    }


    public async Task<TeamEntity> GetTeamByOwnerAsync(string teamOwner)
    {
        var team = await _context.Teams.Where(team => team.TeamOwner == teamOwner).ToListAsync();
        if (team is null)
        {
            return null;
        }
        return _mapper.Map<TeamEntity>(team);
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
