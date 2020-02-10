using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlITLA.Models;

namespace ControlITLA.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly ProfesorContext _context;

        public ProfesorController(ProfesorContext context)
        {
            _context = context;
        }

        // GET: Profesor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesores.ToListAsync());
        }

        // GET: Profesor/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Profesor());
            else
                return View(_context.Profesores.Find(id));
        }

        // POST: Profesor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("ProfesorID,Area,Nombre,Genero,Edad")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                if (profesor.ProfesorID == 0)
                    _context.Add(profesor);
                else
                    _context.Update(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }


        // GET: Profesor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var elegido = await _context.Profesores.FindAsync(id);
            _context.Profesores.Remove(elegido);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
