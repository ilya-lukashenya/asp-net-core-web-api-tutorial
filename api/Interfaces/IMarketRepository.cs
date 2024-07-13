using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Market;
using api.Models;

namespace api.Interfaces
{
    public interface IMarketRepository
    {
        Task<Market?> GetByIdAsync(int id);
        Task<Market> CreateAsync(Market marketModel);
        Task<Market?> UpdateAsync(int id, UpdateMarketRequestDto marketkDto);
        Task<Market?> DeleteAsync(int id);
    }
}