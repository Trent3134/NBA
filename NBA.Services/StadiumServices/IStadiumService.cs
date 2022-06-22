using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IStadiumService
    {
        Task<bool> CreateStadiumAsync(StadiumCreate request);
        Task<IEnumerable<StadiumListItem>> GetAllStadiumsAsync();
    }
