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
    public class AnunciosController : Controller
    {
        private readonly UmTempoEmCasaContext _context;

        public AnunciosController(UmTempoEmCasaContext context)
        {
            _context = context;
        }

        // GET: Anuncios
        public async Task<IActionResult> Index()
        {
            var umTempoEmCasaContext = _context.Anuncio.Include(a => a.Anfitriao).Include(a => a.Imovel);
            return View(await umTempoEmCasaContext.ToListAsync());
        }

        // GET: Anuncios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncio
                .Include(a => a.Anfitriao)
                .Include(a => a.Imovel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // GET: Anuncios/Create
        public IActionResult Create()
        {
            ViewData["AnfitriaoID"] = new SelectList(_context.Set<Anfitriao>(), "ID", "CEP");
            ViewData["ImovelID"] = new SelectList(_context.Set<Imovel>(), "ID", "Cep");
            return View();
        }

        // POST: Anuncios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AnfitriaoID,ImovelID,Nome,valor")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anuncio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnfitriaoID"] = new SelectList(_context.Set<Anfitriao>(), "ID", "CEP", anuncio.AnfitriaoID);
            ViewData["ImovelID"] = new SelectList(_context.Set<Imovel>(), "ID", "Cep", anuncio.ImovelID);
            return View(anuncio);
        }

        // GET: Anuncios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncio.FindAsync(id);
            if (anuncio == null)
            {
                return NotFound();
            }
            ViewData["AnfitriaoID"] = new SelectList(_context.Set<Anfitriao>(), "ID", "CEP", anuncio.AnfitriaoID);
            ViewData["ImovelID"] = new SelectList(_context.Set<Imovel>(), "ID", "Cep", anuncio.ImovelID);
            return View(anuncio);
        }

        // POST: Anuncios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AnfitriaoID,ImovelID,Nome,valor")] Anuncio anuncio)
        {
            if (id != anuncio.ID)
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
                    if (!AnuncioExists(anuncio.ID))
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
            ViewData["AnfitriaoID"] = new SelectList(_context.Set<Anfitriao>(), "ID", "CEP", anuncio.AnfitriaoID);
            ViewData["ImovelID"] = new SelectList(_context.Set<Imovel>(), "ID", "Cep", anuncio.ImovelID);
            return View(anuncio);
        }

        // GET: Anuncios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncio
                .Include(a => a.Anfitriao)
                .Include(a => a.Imovel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anuncio = await _context.Anuncio.FindAsync(id);
            _context.Anuncio.Remove(anuncio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioExists(int id)
        {
            return _context.Anuncio.Any(e => e.ID == id);
        }
    }
}
