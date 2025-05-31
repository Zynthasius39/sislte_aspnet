using sislte.ViewModels;

namespace sislte.Models;

public interface IStudentRepository
{
    public StudentHomeViewModel Get();
    public EditAboutMeViewModel GetEditAboutMe();

    Student? GetById(int id);
    Student? GetByEmail(string email);
    void Add(Student student);
}