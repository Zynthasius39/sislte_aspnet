using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sislte.Models;
public class Announce
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string? Message { get; set; }
    public DateOnly? Date { get; set; }
}

