using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class StadiumService : IStadiumService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public StadiumService(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task<bool> CreateStadiumAsync(StadiumCreate request)
        {
            var stadiumEntity = new StadiumEntity
            {
                StadiumCapacity = request.StadiumCapacity,
                StadiumLocation = request.StadiumLocation,
                StadiumName = request.StadiumName
            };
            _dbContext.Stadiums.Add(stadiumEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<StadiumListItem>> GetAllStadiumsAsync()
        {
            var stadiums = await _dbContext.Stadiums
                .Select(entity => new StadiumListItem
                {
                    Id = entity.Id,
                    StadiumCapacity = entity.StadiumCapacity,
                    StadiumLocation = entity.StadiumLocation,
                    StadiumName = entity.StadiumName
                })
                .ToListAsync();

            return stadiums;
        }
        public async Task<IEnumerable<TeamListItem>> GetAllTeamsByStadiumAsync(int stadiumId)
    {
        var stadiumTeam = await _dbContext.Teams.Where(p => p.Id == stadiumId).ToListAsync();
        if (stadiumTeam is null)
        {
            return null;
        }
        return _mapper.Map<List<TeamListItem>>(stadiumTeam);
    }

        public async Task<StadiumDetail> GetStadiumById(int stadiumId)
        {
            var stadiumEntity = await _dbContext.Stadiums
                .FirstOrDefaultAsync(e =>
                    e.Id == stadiumId);
            return stadiumEntity is null ? null : new StadiumDetail
            {
                Id = stadiumEntity.Id,
                StadiumCapacity = stadiumEntity.StadiumCapacity,
                StadiumLocation = stadiumEntity.StadiumLocation,
                StadiumName = stadiumEntity.StadiumName,
                Teams = stadiumEntity.Teams
                
            };
        }

        public async Task<bool> UpdateStadiumAsync(StadiumUpdate request)
        {
            var stadiumEntity = await _dbContext.Stadiums.FindAsync(request.Id);

            
            stadiumEntity.StadiumCapacity = request.StadiumCapacity;
            stadiumEntity.StadiumName = request.StadiumName;
            stadiumEntity.StadiumLocation = request.StadiumLocation;

            var numberOfChanges= await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        } 

        public async Task<bool> DeleteStadiumAsync(int stadiumId)
        {
            var stadiumEntity = await _dbContext.Stadiums
                .FirstOrDefaultAsync(e =>
                    e.Id == stadiumId);
            
            _dbContext.Stadiums.Remove(stadiumEntity);

            var numberOfChanges= await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }
    }
