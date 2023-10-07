using System.ComponentModel.DataAnnotations;

namespace Crito.Models;

public class MessageEntity
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? RedirectUrl { get; set; } = "/";
}
