using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface ITeamService
    {
        Task<bool> CreateTeamAsync(TeamCreate req);
        Task<TeamEntity> GetTeamByTeamName(string teamName);
        Task<TeamEntity> GetTeamByOwnerAsync(string teamOwner);
        Task<IEnumerable<TeamDetail>> GetTeamByLocation(Locations locations);
        Task<IEnumerable<TeamListItem>> GetAllTeamsAsync();
        Task<bool> UpdateTeamAsync(TeamUpdate req);
        Task<bool> DeleteTeamByIdAsync(int teamId);
    }
