using Microsoft.EntityFrameworkCore;
using sislte.Core;
using sislte.Models;

namespace sislte.Repositories;

public class AnnouncesRepository(SisContext context) : IAnnouncesRepository
{
    public async Task<Announce?> GetByIdAsync(int id)
    {
        return await context.Announces.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Announce>> GetAll()
    {
        return await context.Announces.ToListAsync();
    }
}