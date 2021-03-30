using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pi.PlataformaWeb.Enchente.Data;
using Pi.PlataformaWeb.Enchente.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.PlataformaWeb.Enchente.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RecebeDadosController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public RecebeDadosController(ILogger<HomeController> logger, ApplicationDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(Decimal valor)
        {
            var model = new DadoVolumetrico();
            model.DataCadastro = DateTime.Now;
            model.Valor = valor;

            _context.DadosVolumetricos.Add(model);
            await _context.SaveChangesAsync();

            return Ok("Ainda não tem nda não fiote");
        }
    }
}
