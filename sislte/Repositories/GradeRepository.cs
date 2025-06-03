using Microsoft.EntityFrameworkCore;
using sislte.Core;
using sislte.Models;

namespace sislte.Repositories;

public class GradeRepository(SisContext context) : IGradeRepository
{
    public async Task<Grade?> GetByIdAsync(int id)
    {
        return await context.Grades
            .Include(e => e.Course)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Grade>> GetAll()
    {
        return await context.Grades
            .Include(e => e.Course)
            .ToListAsync();
    }

    public async Task AddAsync(Grade course)
    {
        context.Grades.Add(course);
        await context.SaveChangesAsync();
    }
}