#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UmTempoEmCasa.Models;

namespace UmTempoEmCasa.Controllers
{
    public class ReservasController : Controller
    {
        private readonly UmTempoEmCasaContext _context;

        public ReservasController(UmTempoEmCasaContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var umTempoEmCasaContext = _context.Reserva.Include(r => r.Anfitriao).Include(r => r.Anuncio).Include(r => r.Imovel).Include(r => r.Refugiado);
            return View(await umTempoEmCasaContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Anfitriao)
                .Include(r => r.Anuncio)
                .Include(r => r.Imovel)
                .Include(r => r.Refugiado)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["AnfitriaoID"] = new SelectList(_context.Anfitriao, "ID", "CEP");
            ViewData["AnuncioID"] = new SelectList(_context.Anuncio, "ID", "Nome");
            ViewData["ImovelID"] = new SelectList(_context.Imovel, "ID", "Cep");
            ViewData["RefugiadoID"] = new SelectList(_context.Set<Refugiado>(), "ID", "CEP");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RefugiadoID,AnfitriaoID,AnuncioID,ImovelID,DateInicio,DataFim")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnfitriaoID"] = new SelectList(_context.Anfitriao, "ID", "CEP", reserva.AnfitriaoID);
            ViewData["AnuncioID"] = new SelectList(_context.Anuncio, "ID", "Nome", reserva.AnuncioID);
            ViewData["ImovelID"] = new SelectList(_context.Imovel, "ID", "Cep", reserva.ImovelID);
            ViewData["RefugiadoID"] = new SelectList(_context.Set<Refugiado>(), "ID", "CEP", reserva.RefugiadoID);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["AnfitriaoID"] = new SelectList(_context.Anfitriao, "ID", "CEP", reserva.AnfitriaoID);
            ViewData["AnuncioID"] = new SelectList(_context.Anuncio, "ID", "Nome", reserva.AnuncioID);
            ViewData["ImovelID"] = new SelectList(_context.Imovel, "ID", "Cep", reserva.ImovelID);
            ViewData["RefugiadoID"] = new SelectList(_context.Set<Refugiado>(), "ID", "CEP", reserva.RefugiadoID);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RefugiadoID,AnfitriaoID,AnuncioID,ImovelID,DateInicio,DataFim")] Reserva reserva)
        {
            if (id != reserva.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnfitriaoID"] = new SelectList(_context.Anfitriao, "ID", "CEP", reserva.AnfitriaoID);
            ViewData["AnuncioID"] = new SelectList(_context.Anuncio, "ID", "Nome", reserva.AnuncioID);
            ViewData["ImovelID"] = new SelectList(_context.Imovel, "ID", "Cep", reserva.ImovelID);
            ViewData["RefugiadoID"] = new SelectList(_context.Set<Refugiado>(), "ID", "CEP", reserva.RefugiadoID);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Anfitriao)
                .Include(r => r.Anuncio)
                .Include(r => r.Imovel)
                .Include(r => r.Refugiado)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.ID == id);
        }
    }
}
