using Microsoft.EntityFrameworkCore;
using sislte.Core;
using sislte.Models;

namespace sislte.Repositories;

public class CourseRepository(SisContext context) : ICourseRepository
{
    public async Task<Course?> GetByIdAsync(int id)
    {
        return await context.Courses.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Course>> GetAll()
    {
        return await context.Courses.ToListAsync();
    }

    public async Task AddAsync(Course course)
    {
        context.Courses.Add(course);
        await context.SaveChangesAsync();
    }
}