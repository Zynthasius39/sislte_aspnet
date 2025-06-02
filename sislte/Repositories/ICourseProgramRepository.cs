using sislte.Models;

namespace sislte.Repositories;

public interface ICourseProgramRepository
{
    Task<CourseProgram?> GetByIdAsync(int id);
    Task<ICollection<CourseProgram>> GetAll();
    Task AddAsync(CourseProgram courseProgram);
}