using System.ComponentModel.DataAnnotations;

namespace Crito.Models;

public class ContactForm
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Message is required.")]
    public string Message { get; set; } = null!;

    public string? RedirectUrl { get; set; } = "/";

}
