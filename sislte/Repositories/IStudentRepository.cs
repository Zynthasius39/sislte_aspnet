using sislte.ViewModels;

namespace sislte.Models;

public interface IStudentRepository
{
    Student? GetById(int id);
    Student? GetByEmail(string email);
    void Add(Student student);
    void Update(Student student);
    void UpdateDetailed(DetailedStudent detailedStudent);
}