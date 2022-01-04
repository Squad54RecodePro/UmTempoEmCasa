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
    public class AnfitriaoController : Controller
    {
        private readonly MVCContext _context;

        public AnfitriaoController(MVCContext context)
        {
            _context = context;
        }

        // GET: Anfitriao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anfitrioes.ToListAsync());
        }

        // GET: Anfitriao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anfitriao = await _context.Anfitrioes
                .FirstOrDefaultAsync(m => m.AnfitriaoID == id);
            if (anfitriao == null)
            {
                return NotFound();
            }

            return View(anfitriao);
        }

        // GET: Anfitriao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anfitriao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnfitriaoID,Nome,Tipo,Nascimento,Telefone,Email,Endereco,Cidade,CEP,CPF,CNPJ,Senha")] Anfitriao anfitriao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anfitriao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Imovel");
            }
            return View(anfitriao);
        }

        // GET: Anfitriao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anfitriao = await _context.Anfitrioes.FindAsync(id);
            if (anfitriao == null)
            {
                return NotFound();
            }
            return View(anfitriao);
        }

        // POST: Anfitriao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnfitriaoID,Nome,Tipo,Nascimento,Telefone,Email,Endereco,Cidade,CEP,CPF,CNPJ,Senha")] Anfitriao anfitriao)
        {
            if (id != anfitriao.AnfitriaoID)
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
                    if (!AnfitriaoExists(anfitriao.AnfitriaoID))
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

        // GET: Anfitriao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anfitriao = await _context.Anfitrioes
                .FirstOrDefaultAsync(m => m.AnfitriaoID == id);
            if (anfitriao == null)
            {
                return NotFound();
            }

            return View(anfitriao);
        }

        // POST: Anfitriao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anfitriao = await _context.Anfitrioes.FindAsync(id);
            _context.Anfitrioes.Remove(anfitriao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnfitriaoExists(int id)
        {
            return _context.Anfitrioes.Any(e => e.AnfitriaoID == id);
        }
    }
}
