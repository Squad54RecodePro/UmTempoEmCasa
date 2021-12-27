using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UmTempoEmCasa.Controllers
{
    public class teste : Controller
    {
        // GET: teste
        public ActionResult Index()
        {
            return View();
        }

        // GET: teste/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: teste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: teste/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: teste/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: teste/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: teste/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: teste/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
