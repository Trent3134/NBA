using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

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
    }
