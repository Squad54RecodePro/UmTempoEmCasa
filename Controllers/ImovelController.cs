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
    public class ImovelController : Controller
    {
        private readonly MVCContext _context;

        public ImovelController(MVCContext context)
        {
            _context = context;
        }

        // GET: Imovel
        public async Task<IActionResult> Index()
        {
            var mVCContext = _context.Imoveis.Include(i => i.Anfitrioes);
            return View(await mVCContext.ToListAsync());
        }

        // GET: Imovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Anfitrioes)
                .FirstOrDefaultAsync(m => m.ImovelID == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imovel/Create
        public IActionResult Create()
        {
            ViewData["AnfitriaoForeignKey"] = new SelectList(_context.Anfitrioes, "AnfitriaoID", "CEP");
            return View();
        }

        // POST: Imovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImovelID,AnfitriaoForeignKey,Endereco,Cidade,Cep")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnfitriaoForeignKey"] = new SelectList(_context.Anfitrioes, "AnfitriaoID", "CEP", imovel.AnfitriaoForeignKey);
            return View(imovel);
        }

        // GET: Imovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["AnfitriaoForeignKey"] = new SelectList(_context.Anfitrioes, "AnfitriaoID", "CEP", imovel.AnfitriaoForeignKey);
            return View(imovel);
        }

        // POST: Imovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImovelID,AnfitriaoForeignKey,Endereco,Cidade,Cep")] Imovel imovel)
        {
            if (id != imovel.ImovelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.ImovelID))
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
            ViewData["AnfitriaoForeignKey"] = new SelectList(_context.Anfitrioes, "AnfitriaoID", "CEP", imovel.AnfitriaoForeignKey);
            return View(imovel);
        }

        // GET: Imovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Anfitrioes)
                .FirstOrDefaultAsync(m => m.ImovelID == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Imoveis.Any(e => e.ImovelID == id);
        }
    }
}
