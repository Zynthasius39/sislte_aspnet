using System.ComponentModel.DataAnnotations;

namespace sislte.Models;

public class ResetForm
{
    [Required]
    public string ResetId { get; set; }
}