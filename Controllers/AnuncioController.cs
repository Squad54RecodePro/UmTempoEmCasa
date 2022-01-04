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
    public class AnuncioController : Controller
    {
        private readonly MVCContext _context;

        public AnuncioController(MVCContext context)
        {
            _context = context;
        }

        // GET: Anuncio
        public async Task<IActionResult> Index()
        {
            var mVCContext = _context.Anuncios.Include(a => a.Imovel);
            return View(await mVCContext.ToListAsync());
        }



        public IActionResult Catalogo()
        {
            return View(Catalogo);
        }
        // GET: Anuncio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios
                .Include(a => a.Imovel)
                .FirstOrDefaultAsync(m => m.AnuncioID == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // GET: Anuncio/Create
        public IActionResult Create()
        {
            ViewData["ImovelForeignKey"] = new SelectList(_context.Imoveis, "ImovelID", "Cep");
            return View();
        }

        // POST: Anuncio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnuncioID,ImovelForeignKey,inicio,valor")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anuncio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImovelForeignKey"] = new SelectList(_context.Imoveis, "ImovelID", "Cep", anuncio.ImovelForeignKey);
            return View(anuncio);
        }

        // GET: Anuncio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios.FindAsync(id);
            if (anuncio == null)
            {
                return NotFound();
            }
            ViewData["ImovelForeignKey"] = new SelectList(_context.Imoveis, "ImovelID", "Cep", anuncio.ImovelForeignKey);
            return View(anuncio);
        }

        // POST: Anuncio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnuncioID,ImovelForeignKey,inicio,valor")] Anuncio anuncio)
        {
            if (id != anuncio.AnuncioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anuncio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuncioExists(anuncio.AnuncioID))
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
            ViewData["ImovelForeignKey"] = new SelectList(_context.Imoveis, "ImovelID", "Cep", anuncio.ImovelForeignKey);
            return View(anuncio);
        }

        // GET: Anuncio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios
                .Include(a => a.Imovel)
                .FirstOrDefaultAsync(m => m.AnuncioID == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // POST: Anuncio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            _context.Anuncios.Remove(anuncio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioExists(int id)
        {
            return _context.Anuncios.Any(e => e.AnuncioID == id);
        }
    }
}
