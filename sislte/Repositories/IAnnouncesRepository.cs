using sislte.Models;

namespace sislte.Repositories;

public interface IAnnouncesRepository
{
    Task<Announce?> GetByIdAsync(int id);
    Task<ICollection<Announce>> GetAll();
}