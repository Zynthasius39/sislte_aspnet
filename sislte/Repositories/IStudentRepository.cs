using sislte.Models;

namespace sislte.Repositories;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(int id, Func<IQueryable<Student>, IQueryable<Student>>? include = null);
    Task<Student?> GetByEmailAsync(string email, Func<IQueryable<Student>, IQueryable<Student>>? include = null);
    Task<Student?> GetByEmailAsync(string email, bool includeRelated = false);
    Task UpdateAsync(Student student);
    Task AddAsync(Student student);
    Task DeleteAsync(Student student);
}