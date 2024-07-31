using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learn.Interfaces;
using Learn.Data;
using Learn.Models;
using Microsoft.EntityFrameworkCore;

namespace learn.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context){
            _context = context;
        }
        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }

        public Task<Stock> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}