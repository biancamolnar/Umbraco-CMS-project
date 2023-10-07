using Crito.Contexts;
using Crito.Models;

namespace Crito.Services;

public class ContactService
{
    private readonly DataContext _context;

    public ContactService(DataContext context)
    {
        _context = context;
    }

    public async Task AddMessageAsync(ContactForm form)
    {
        var message = new MessageEntity
        {
            Name = form.Name,
            Email = form.Email,
            Message = form.Message
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }
}
