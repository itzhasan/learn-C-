using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learn.Dtos.Stock;
using learn.Interfaces;
using learn.Mappers;
using Learn.Data;
using Learn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController:ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context , IStockRepository stockRepo){
            _stockRepo = stockRepo;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult>  GetAll(){
            var stocks =await _stockRepo.GetAllAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock =await _context.Stocks.FindAsync(id);
            if(stock == null){
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto){
            var stockModel = stockDto.ToStockFormCreateDTO();
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id});
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateStockRequestDto updateDto){
            var stockModel =await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null){
                return NotFound();
            }
            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stockModel =await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null){
                return NotFound();
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}