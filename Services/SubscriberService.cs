using System.Threading.Tasks;
using Crito.Contexts;
using Crito.Models;

namespace Crito.Services
{
    public class SubscriberService
    {
        private readonly DataContext _context;

        public SubscriberService(DataContext context)
        {
            _context = context;
        }

        public async Task AddSubscriberAsync(NewsletterForm form)
        {
            var subscriber = new SubscriberEntity
            {
                Email = form.Email
            };

            _context.Subscribers.Add(subscriber);
            await _context.SaveChangesAsync();
        }
    }
}
