using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pi.PlataformaWeb.Enchente.Data;
using System;
using System.Threading.Tasks;
using WebPush;

namespace Pi.PlataformaWeb.Enchente.Controllers
{
    public class WebPushController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public WebPushController(ILogger<HomeController> logger, ApplicationDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send(int? id)
        {
            return View();
        }

        [HttpPost, ActionName("Send")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(Guid id)
        {
            var payload = Request.Form["payload"];
            var device = await _context.Inscritos.SingleOrDefaultAsync(m => m.InscritoID == id);

            string vapidPublicKey = _configuration.GetSection("VapidKeys")["PublicKey"];
            string vapidPrivateKey = _configuration.GetSection("VapidKeys")["PrivateKey"];

            var pushSubscription = new PushSubscription(device.PushEndpoint, device.PushP256DH, device.PushAuth);
            var vapidDetails = new VapidDetails("mailto:example@example.com", vapidPublicKey, vapidPrivateKey);

            var webPushClient = new WebPushClient();
            webPushClient.SendNotification(pushSubscription, payload, vapidDetails);

            return View();
        }

        public IActionResult GenerateKeys()
        {
            var keys = VapidHelper.GenerateVapidKeys();
            ViewBag.PublicKey = keys.PublicKey;
            ViewBag.PrivateKey = keys.PrivateKey;
            return View();
        }
    }
}
