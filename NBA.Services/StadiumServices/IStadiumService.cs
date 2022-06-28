using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IStadiumService
    {
        Task<bool> CreateStadiumAsync(StadiumCreate request);
        Task<IEnumerable<StadiumListItem>> GetAllStadiumsAsync();
        Task<StadiumDetail> GetStadiumById(int stadiumId);
        Task<bool> UpdateStadiumAsync(StadiumUpdate request);
        Task<bool> DeleteStadiumAsync(int stadiumId);
    }
