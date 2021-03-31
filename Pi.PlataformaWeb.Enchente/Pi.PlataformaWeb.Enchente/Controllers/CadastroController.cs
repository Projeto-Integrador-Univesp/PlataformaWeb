using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CadastroController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public CadastroController(ILogger<HomeController> logger, ApplicationDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Inscritos.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.PublicKey = _configuration.GetSection("VapidKeys")["PublicKey"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inscrito inscrito)
        {
            if (ModelState.IsValid)
            {
                _context.Inscritos.Add(inscrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscrito);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var inscrito = await _context.Inscritos
                .SingleOrDefaultAsync(m => m.InscritoID == id);
            if (inscrito == null)
            {
                return NotFound();
            }

            return View(inscrito);
        }

        // POST: Inscritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var inscrito = await _context.Inscritos.SingleOrDefaultAsync(m => m.InscritoID == id);
            _context.Inscritos.Remove(inscrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscritoExists(Guid id)
        {
            return _context.Inscritos.Any(e => e.InscritoID == id);
        }
    }
}
