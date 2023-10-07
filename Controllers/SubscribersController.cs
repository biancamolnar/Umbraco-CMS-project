using Crito.Contexts;
using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class SubscribersController : SurfaceController
    {
        private readonly SubscriberService _subscriberService;

        public SubscribersController(
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            DataContext dataContext, 
            ILogger<SubscribersController> logger) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _subscriberService = new SubscriberService(dataContext);
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewsletterForm newsletterForm)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            await _subscriberService.AddSubscriberAsync(newsletterForm);

            return LocalRedirect(newsletterForm.RedirectUrl ?? "/");
        }
    }
}
