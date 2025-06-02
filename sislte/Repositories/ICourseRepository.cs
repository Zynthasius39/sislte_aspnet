using sislte.Models;

namespace sislte.Repositories;

public interface ICourseRepository
{
    Task<Course?> GetByIdAsync(int id);
    Task<ICollection<Course>> GetAll();
    Task AddAsync(Course course);
}