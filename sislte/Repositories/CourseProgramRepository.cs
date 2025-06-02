using Microsoft.EntityFrameworkCore;
using sislte.Core;
using sislte.Models;

namespace sislte.Repositories;

public class CourseProgramRepository(SisContext context) : ICourseProgramRepository
{
    public async Task<CourseProgram?> GetByIdAsync(int id)
    {
        return await context.CoursePrograms.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<CourseProgram>> GetAll()
    {
        return await context.CoursePrograms.ToListAsync();
    }

    public async Task AddAsync(CourseProgram entity)
    {
        context.CoursePrograms.Add(entity);
        await context.SaveChangesAsync();
    }
}