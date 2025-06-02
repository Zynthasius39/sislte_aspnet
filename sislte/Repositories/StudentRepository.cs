using Microsoft.EntityFrameworkCore;
using sislte.Core;
using sislte.Models;

namespace sislte.Repositories;

public class StudentRepository(SisContext context) : IStudentRepository
{
    public async Task<Student?> GetByEmailAsync(string email, bool includeRelated = false)
    {
        var query = context.Students.AsQueryable();

        if (includeRelated)
        {
            query = query
                .Include(s => s.DetailedStudent)
                .ThenInclude(e => e.Transcript)
                .ThenInclude(e => e.StudentCourseProgram)
                .ThenInclude(e => e.StudentSemesters)
                .Include(s => s.DetailedStudent)
                .ThenInclude(s => s.Advisor)
                .Include(s => s.DetailedStudent)
                .ThenInclude(s => s.Scholarship);
        }

        return await query.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    public async Task<Student?> GetByEmailAsync(string email, Func<IQueryable<Student>, IQueryable<Student>>? include = null)
    {
        var query = context.Students.AsQueryable();
        if (include != null)
            query = include(query);

        return await query.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Student?> GetByIdAsync(int id, Func<IQueryable<Student>, IQueryable<Student>>? include = null)
    {
        var query = context.Students.AsQueryable();
        if (include != null)
            query = include(query);

        return await query.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateAsync(Student student)
    {
        context.Students.Update(student);
        await context.SaveChangesAsync();
    }

    public async Task AddAsync(Student student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Student student)
    {
        context.Students.Remove(student);
        await context.SaveChangesAsync();
    }
}