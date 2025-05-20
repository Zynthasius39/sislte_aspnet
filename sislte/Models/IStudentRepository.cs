using sislte.ViewModels;

namespace sislte.Models;

public interface IStudentRepository
{
    public StudentHomeViewModel Get();
    public EditAboutMeViewModel GetEditAboutMe();
}