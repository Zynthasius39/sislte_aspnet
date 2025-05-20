using sislte.Models;

namespace sislte.ViewModels;

public class StudentHomeViewModel
{
    public Student Student { get; set; }
    public List<DetailedInfo> DetailedInfos { get; set; }
}