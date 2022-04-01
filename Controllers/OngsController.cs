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
    public class OngsController : Controller
    {
        private readonly MVCContext _context;

        public OngsController(MVCContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Ongs.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ong = await _context.Ongs
                .FirstOrDefaultAsync(m => m.OngsID == id);
            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        // GET: ONGs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ONGso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OngsID,Nome,CNPJ, Endereco,Telefone,Email")] Ongs ongs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ongs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ongs);
        }

        // GET: ONGs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ongs = await _context.Ongs.FindAsync(id);
            if (ongs == null)
            {
                return NotFound();
            }
            return View(ongs);
        }

        // POST: ONGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OngsID,Nome,CNPJ, Endereco,Telefone,Email")] Ongs ongs)
        {
            if (id != ongs.OngsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ongs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OngsExists(ongs.OngsID))
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
            return View(ongs);
        }

        // GET: ONGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ongs = await _context.Ongs
                .FirstOrDefaultAsync(m => m.OngsID == id);
            if (ongs == null)
            {
                return NotFound();
            }

            return View(ongs);
        }

        // POST: ONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ongs = await _context.Ongs.FindAsync(id);
            _context.Ongs.Remove(ongs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OngsExists(int id)
        {
            return _context.Ongs.Any(e => e.OngsID == id);
        }
    }
}
    

