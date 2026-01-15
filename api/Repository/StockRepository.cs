using System;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class StockRepository : IStockRepository
{

      private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
        await _context.Stock.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
        if(stockModel == null)
        {
            return null;
        }

        _context.Stock.Remove(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }

    public  async Task<List<Stock>> GetAllAsync()
        {
        
            return await _context.Stock.Include(c => c.Comments).ToListAsync();
        }

    public async Task<Stock?> GetByIdaAsync(int id)
    {
        return await _context.Stock.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<bool> StockExists(int id)
    {
       return _context.Stock.AnyAsync(s => s.Id == id);
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
    {
        var existingStock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id );

        if(existingStock == null)
        {
            return null;
        }
        existingStock.UpdateFromDto(stockDto);
        await  _context.SaveChangesAsync();

        return existingStock;
    }
}
