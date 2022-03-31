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
    public class RefugiadoController : Controller
    {
        private readonly MVCContext _context;

        public RefugiadoController(MVCContext context)
        {
            _context = context;
        }

        // GET: Refugiado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Refugiados.ToListAsync());
        }
        public IActionResult term()
        {
            return View();
        }

        // GET: Refugiado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refugiado = await _context.Refugiados
                .FirstOrDefaultAsync(m => m.RefugiadoID == id);
            if (refugiado == null)
            {
                return NotFound();
            }

            return View(refugiado);
        }

        // GET: Refugiado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refugiado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RefugiadoID,Nome,Nascimento,CPF,Telefone,Email,Endereco,CEP,Senha")] Refugiado refugiado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refugiado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Anuncio");
            }
            return View(refugiado);
        }

        // GET: Refugiado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refugiado = await _context.Refugiados.FindAsync(id);
            if (refugiado == null)
            {
                return NotFound();
            }
            return View(refugiado);
        }

        // POST: Refugiado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RefugiadoID,Nome,Nascimento,CPF,Telefone,Email,Endereco,CEP,Senha")] Refugiado refugiado)
        {
            if (id != refugiado.RefugiadoID)
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
                    if (!RefugiadoExists(refugiado.RefugiadoID))
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

        // GET: Refugiado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refugiado = await _context.Refugiados
                .FirstOrDefaultAsync(m => m.RefugiadoID == id);
            if (refugiado == null)
            {
                return NotFound();
            }

            return View(refugiado);
        }

        // POST: Refugiado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refugiado = await _context.Refugiados.FindAsync(id);
            _context.Refugiados.Remove(refugiado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefugiadoExists(int id)
        {
            return _context.Refugiados.Any(e => e.RefugiadoID == id);
        }
    }
}
