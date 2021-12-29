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
    public class RefugiadoesController : Controller
    {
        private readonly UmTempoEmCasaContext _context;

        public RefugiadoesController(UmTempoEmCasaContext context)
        {
            _context = context;
        }

        // GET: Refugiadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Refugiado.ToListAsync());
        }

        // GET: Refugiadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refugiado = await _context.Refugiado
                .FirstOrDefaultAsync(m => m.ID == id);
            if (refugiado == null)
            {
                return NotFound();
            }

            return View(refugiado);
        }

        // GET: Refugiadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refugiadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Nascimento,CPF,Telefone,Email,Endereco,CEP,Senha")] Refugiado refugiado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refugiado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refugiado);
        }

        // GET: Refugiadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refugiado = await _context.Refugiado.FindAsync(id);
            if (refugiado == null)
            {
                return NotFound();
            }
            return View(refugiado);
        }

        // POST: Refugiadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Nascimento,CPF,Telefone,Email,Endereco,CEP,Senha")] Refugiado refugiado)
        {
            if (id != refugiado.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refugiado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefugiadoExists(refugiado.ID))
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
            return View(refugiado);
        }

        // GET: Refugiadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refugiado = await _context.Refugiado
                .FirstOrDefaultAsync(m => m.ID == id);
            if (refugiado == null)
            {
                return NotFound();
            }

            return View(refugiado);
        }

        // POST: Refugiadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refugiado = await _context.Refugiado.FindAsync(id);
            _context.Refugiado.Remove(refugiado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefugiadoExists(int id)
        {
            return _context.Refugiado.Any(e => e.ID == id);
        }
    }
}
