using sislte.Models;

namespace sislte.Repositories;

public interface IGradeRepository
{
    Task<Grade?> GetByIdAsync(int id);
    Task<ICollection<Grade>> GetAll();
    Task AddAsync(Grade grade);
}