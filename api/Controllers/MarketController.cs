using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Market;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;


namespace api.Controllers
{
    [Route("api/market")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMarketRepository _marketRepo;

        public MarketController(ApplicationDBContext context, IMarketRepository marketRepo)
        {
            _marketRepo = marketRepo;
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var market = await _marketRepo.GetByIdAsync(id);

            if (market == null)
            {
                return NotFound();
            }

            return Ok(market.ToMarketkDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMarketRequestDto marketDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var marketModel = marketDto.ToMarketFromCreateDto();

            await _marketRepo.CreateAsync(marketModel);

            return CreatedAtAction(nameof(GetById), new { id = marketModel.Id }, marketModel.ToMarketkDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMarketRequestDto updateDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var marketModel = await  _marketRepo.UpdateAsync(id, updateDto);

            if (marketModel == null)
            {
                return NotFound();
            }


            await _context.SaveChangesAsync();

            return Ok(marketModel.ToMarketkDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var stockModel = await _marketRepo.DeleteAsync(id);

            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}