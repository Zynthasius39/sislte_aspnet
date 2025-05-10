using System.ComponentModel.DataAnnotations;

namespace sislte.Models;

public class ContactForm
{
    [Required] public string FullName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required] public string Subject { get; set; }
    [Required] public string Message { get; set; }
}