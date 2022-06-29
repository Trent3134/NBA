using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface ITeamService
    {
        Task<bool> CreateTeamAsync(TeamCreate req);
        Task<IEnumerable<TeamListItem>> GetTeamByTeamName(string TeamName);
        Task<IEnumerable<TeamListItem>> GetTeamByTeamOwnerAsync(string TeamOwner);
        Task<IEnumerable<TeamListItem>> GetTeamByLocation(Locations Location);
        Task<IEnumerable<TeamListItem>> GetAllTeamsAsync();
        Task<bool> UpdateTeamAsync(TeamUpdate req);
        Task<bool> DeleteTeamByIdAsync(int teamId);
        Task<IEnumerable<PlayerListItem>> GetPlayersByTeam(int Id);
    }
