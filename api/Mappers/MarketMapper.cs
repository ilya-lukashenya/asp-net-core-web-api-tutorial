using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Market;
using api.Models;


namespace api.Mappers
{
    public static class MarketMapper
    {
        public static MarketDto ToMarketkDto(this Market marketModel)
        {
            return new MarketDto
            {
                Id = marketModel.Id,
                Name = marketModel.Name,
                Code = marketModel.Code,
                City = marketModel.City
            };
        }
        public static Market ToMarketFromCreateDto(this CreateMarketRequestDto marketDto)
        {
            return new Market
            {
                Name = marketDto.Name,
                Code = marketDto.Code,
                City = marketDto.City
            };
        }
    }
}