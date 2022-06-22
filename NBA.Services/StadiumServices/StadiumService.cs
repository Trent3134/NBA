using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class StadiumService : IStadiumService
    {
        private readonly ApplicationDbContext _dbContext;
        public StadiumService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
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
    }
