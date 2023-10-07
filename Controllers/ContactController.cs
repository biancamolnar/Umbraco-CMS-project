using Crito.Contexts;
using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers;

public class ContactController : SurfaceController
{
    private readonly ContactService _contactService;

    public ContactController(
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            DataContext dataContext,
            ILogger<SubscribersController> logger) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        _contactService = new ContactService(dataContext);
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactForm contactForm)
    {
        if (!ModelState.IsValid)
            return CurrentUmbracoPage();

        await _contactService.AddMessageAsync(contactForm);

        return LocalRedirect(contactForm.RedirectUrl ?? "/");
    }
}
