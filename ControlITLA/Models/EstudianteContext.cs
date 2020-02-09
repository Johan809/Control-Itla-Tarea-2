using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlITLA.Models
{
    public class EstudianteContext:DbContext
    {
        public EstudianteContext(DbContextOptions<EstudianteContext> options): base(options) 
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
