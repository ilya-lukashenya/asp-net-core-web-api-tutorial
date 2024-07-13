using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Market;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Helpers;

namespace api.Repository
{
    public class MarketRepository : IMarketRepository
    {
        private readonly ApplicationDBContext _context;
        public MarketRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Market> CreateAsync(Market marketModel)
        {
            await _context.Markets.AddAsync(marketModel);
            await _context.SaveChangesAsync();
            return marketModel;
        }

        public async Task<Market?> GetByIdAsync(int id)
        {
            return await _context.Markets.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Market?> UpdateAsync(int id, UpdateMarketRequestDto marketDto)
        {
            var existingMarket = await _context.Markets.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMarket == null)
            {
                return null;
            }

            existingMarket.Name = marketDto.Name;
            existingMarket.Code = marketDto.Code;
            existingMarket.City = marketDto.City;

            await _context.SaveChangesAsync();

            return existingMarket;
        }

         public async Task<Market?> DeleteAsync(int id)
        {
            var marketModel = await _context.Markets.FirstOrDefaultAsync(x => x.Id == id);

            if (marketModel == null)
            {
                return null;
            }

            _context.Markets.Remove(marketModel);
            await _context.SaveChangesAsync();
            return marketModel;  
        }
    }
}