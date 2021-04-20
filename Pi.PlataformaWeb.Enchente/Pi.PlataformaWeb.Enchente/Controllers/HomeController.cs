using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pi.PlataformaWeb.Enchente.Data;
using Pi.PlataformaWeb.Enchente.Models;
using Pi.PlataformaWeb.Enchente.ViewModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.PlataformaWeb.Enchente.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();
            model.DadosVolumetricos = await _context.DadosVolumetricos.OrderByDescending(o => o.DataCadastro).Take(50).ToListAsync();
            model.Enchentes = await _context.Enchentes.OrderByDescending(o => o.DataCadastro).Take(50).ToListAsync();

            ViewBag.PublicKey = _configuration.GetSection("VapidKeys")["PublicKey"];
            return View(model);
        }
        [HttpGet]
        public IActionResult QuemSomos()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Stats()
        {
            var dados = await _context.DadosVolumetricos.OrderByDescending(o => o.DataCadastro).Take(100).ToListAsync();
            return View(dados);
        }

        [HttpGet]
        public async Task<IActionResult> Stats1()
        {
            var dados = await _context.Enchentes.OrderByDescending(o => o.DataCadastro).Take(100).ToListAsync();
            return View(dados);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
