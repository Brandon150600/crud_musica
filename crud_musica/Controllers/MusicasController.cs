using crud_musica.Data;
using crud_musica.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_musica.Controllers
{
    public class MusicasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MusicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Musica> listamusica = _context.Musica;
            return View(listamusica);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Musica musica)
        {
            if (ModelState.IsValid)
            {
                _context.Musica.Add(musica);
                _context.SaveChanges();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            var cancion = _context.Musica.Find(id);

            if (cancion == null)
            {
                return NotFound();
            }

            return View(cancion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Musica musica)
        {
            if (ModelState.IsValid)
            {
                _context.Musica.Update(musica);
                _context.SaveChanges();
                TempData["mensaje"] = "Actualizado Correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var cancion = _context.Musica.Find(id);

            if (cancion == null)
            {
                return NotFound();
            }

            return View(cancion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMusica(int? id)
        {
            var cancion = _context.Musica.Find(id);
            if (cancion == null)
            {
                return NotFound();
            }
            _context.Musica.Remove(cancion);
            _context.SaveChanges();
            TempData["mensaje"] = "Eliminado Correctamente";
            return RedirectToAction("Index");
        }


    }
}
