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
    public class MateriaController : Controller
    {
        private readonly MateriaContext _context;

        public MateriaController(MateriaContext context)
        {
            _context = context;
        }

        // GET: Materia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materias.ToListAsync());
        }

        // GET: Materia/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Materia());
            else
                return View(_context.Materias.Find(id));
        }

        // POST: Materia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("MateriaID,Codigo,Nombre,Creditos")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                if (materia.MateriaID == 0)
                    _context.Add(materia);
                else
                    _context.Update(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }

        // GET: Materia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var elegido = await _context.Materias.FindAsync(id);
            _context.Materias.Remove(elegido);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
