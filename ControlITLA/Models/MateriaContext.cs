using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlITLA.Models
{
    public class MateriaContext:DbContext 
    {
        public MateriaContext(DbContextOptions<MateriaContext> options):base(options)
        {
        }

        public DbSet<Materia> Materias { get; set; }
    }
}
