﻿using Loja.Domain.Entities;
using Loja.Domain.Repositories;
using Loja.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public void DeleteRange<T>(IEnumerable<T> entity) where T : class
    {
        _context.RemoveRange(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
    {
        var query = await _context.Products
            .Where(p => p.Active == true)
            .ToListAsync();

        return query;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsByInventoryAsync(string inventory)
    {
        var query = await _context.Products
            .Where(p => p.Active == true)
            .Include(p => p.Inventory)
            .OrderBy(p => p.Name)
            .ToListAsync();

        return query;
    }

    public async Task<ProductEntity> GetProductByIdAsync(int productId)
    {
        var query = await _context.Products
            .FirstOrDefaultAsync(p => p.Active == true && p.Id == productId);

        return query;
    }
}
