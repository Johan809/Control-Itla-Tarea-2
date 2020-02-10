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
    public class EstudianteController : Controller  
    {
        private readonly EstudianteContext _context;

        public EstudianteController(EstudianteContext context)
        {
            _context = context;
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudiantes.ToListAsync());
        }

        // GET: Estudiante/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
                return View(new Estudiante());
            else
                return View(_context.Estudiantes.Find(id));
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EstudianteID,Matricula,Nombre,Genero,Edad")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                if(estudiante.EstudianteID == 0)
                    _context.Add(estudiante);
                else
                    _context.Update(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var elegido = await _context.Estudiantes.FindAsync(id);
            _context.Estudiantes.Remove(elegido);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
