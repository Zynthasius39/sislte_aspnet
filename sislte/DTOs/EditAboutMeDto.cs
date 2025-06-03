using System.ComponentModel.DataAnnotations;

namespace sislte.DTOs;

public class EditAboutMeDto
{
    [Required, MaxLength(50)]
    public string FullName { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string Education { get; set; }
    [Required]
    public string Notes { get; set; }
    [Display(Name = "Avatar")]
    public IFormFile? Avatar { get; set; }
}