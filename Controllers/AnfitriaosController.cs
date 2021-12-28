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
    public class AnfitriaosController : Controller
    {
        private readonly UmTempoEmCasaContext _context;

        public AnfitriaosController(UmTempoEmCasaContext context)
        {
            _context = context;
        }

        // GET: Anfitriaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anfitriao.ToListAsync());
        }

        // GET: Anfitriaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anfitriao = await _context.Anfitriao
                .FirstOrDefaultAsync(m => m.ID == id);
            if (anfitriao == null)
            {
                return NotFound();
            }

            return View(anfitriao);
        }

        // GET: Anfitriaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anfitriaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Tipo,Nascimento,Telefone,Email,Endereco,Cidade,CEP,CPF,CNPJ,Senha")] Anfitriao anfitriao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anfitriao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anfitriao);
        }

        // GET: Anfitriaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anfitriao = await _context.Anfitriao.FindAsync(id);
            if (anfitriao == null)
            {
                return NotFound();
            }
            return View(anfitriao);
        }

        // POST: Anfitriaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Tipo,Nascimento,Telefone,Email,Endereco,Cidade,CEP,CPF,CNPJ,Senha")] Anfitriao anfitriao)
        {
            if (id != anfitriao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anfitriao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnfitriaoExists(anfitriao.ID))
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
            return View(anfitriao);
        }

        // GET: Anfitriaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anfitriao = await _context.Anfitriao
                .FirstOrDefaultAsync(m => m.ID == id);
            if (anfitriao == null)
            {
                return NotFound();
            }

            return View(anfitriao);
        }

        // POST: Anfitriaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anfitriao = await _context.Anfitriao.FindAsync(id);
            _context.Anfitriao.Remove(anfitriao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnfitriaoExists(int id)
        {
            return _context.Anfitriao.Any(e => e.ID == id);
        }
    }
}
