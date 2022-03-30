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
        private readonly IWebHostEnvironment _hostEnvironment;

        public AnuncioController(MVCContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Anuncio
        public async Task<IActionResult> Index()
        {
            var mVCContext = _context.Anuncios.Include(a => a.Imovel);

            return View(await mVCContext.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("AnuncioID,ImovelForeignKey,inicio,valor,NomeAnuncio,ImagemAnuncio")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {   //inserir imagem
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(anuncio.ImagemAnuncio.FileName);
                string extension = Path.GetExtension(anuncio.ImagemAnuncio.FileName);
                anuncio.nomeimagem = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream= new FileStream(path, FileMode.Create))
                {
                    await anuncio.ImagemAnuncio.CopyToAsync(fileStream);
                }
                Console.WriteLine(anuncio.nomeimagem);
                //inserir cadastro
                
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
        public async Task<IActionResult> Edit(int id, [Bind("AnuncioID,ImovelForeignKey,inicio,valor,NomeAnuncio,ImagemAnuncio,nomeimagem")] Anuncio anuncio)
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
