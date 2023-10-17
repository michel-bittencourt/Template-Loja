using Loja.Persistence.Data.Context;

namespace Loja.Persistence.Repositories.General;

public class General : IGeneral
{
    private readonly ApplicationDbContext _context;

    public General(ApplicationDbContext Context)
    {
        _context = Context;
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

    public void DeleteRange<T>(T entity) where T : class
    {
        _context.RemoveRange(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }
}
