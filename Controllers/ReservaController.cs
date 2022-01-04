#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UmTempoEmCasa.Context;
using UmTempoEmCasa.Models;

namespace UmTempoEmCasa.Controllers
{
    public class ReservaController : Controller
    {
        private readonly MVCContext _context;

        public ReservaController(MVCContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var mVCContext = _context.Reservas.Include(r => r.Anuncios).Include(r => r.Refugiados);
            return View(await mVCContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Anuncios)
                .Include(r => r.Refugiados)
                .FirstOrDefaultAsync(m => m.ReservaID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewData["AnuncioForeignKey"] = new SelectList(_context.Anuncios, "AnuncioID", "AnuncioID");
            ViewData["RefugiadoForeignKey"] = new SelectList(_context.Refugiados, "RefugiadoID", "Nome");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaID,RefugiadoForeignKey,AnuncioForeignKey,Nome,DateInicio,DataFim")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnuncioForeignKey"] = new SelectList(_context.Anuncios, "AnuncioID", "AnuncioID", reserva.AnuncioForeignKey);
            ViewData["RefugiadoForeignKey"] = new SelectList(_context.Refugiados, "RefugiadoID", "Nome", reserva.RefugiadoForeignKey);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["AnuncioForeignKey"] = new SelectList(_context.Anuncios, "AnuncioID", "AnuncioID", reserva.AnuncioForeignKey);
            ViewData["RefugiadoForeignKey"] = new SelectList(_context.Refugiados, "RefugiadoID", "Nome", reserva.RefugiadoForeignKey);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaID,RefugiadoForeignKey,AnuncioForeignKey,Nome,DateInicio,DataFim")] Reserva reserva)
        {
            if (id != reserva.ReservaID)
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
                    if (!ReservaExists(reserva.ReservaID))
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
            ViewData["AnuncioForeignKey"] = new SelectList(_context.Anuncios, "AnuncioID", "AnuncioID", reserva.AnuncioForeignKey);
            ViewData["RefugiadoForeignKey"] = new SelectList(_context.Refugiados, "RefugiadoID", "Nome", reserva.RefugiadoForeignKey);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Anuncios)
                .Include(r => r.Refugiados)
                .FirstOrDefaultAsync(m => m.ReservaID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.ReservaID == id);
        }
    }
}
