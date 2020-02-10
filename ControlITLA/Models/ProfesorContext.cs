using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlITLA.Models
{
    public class ProfesorContext:DbContext
    {
        public ProfesorContext(DbContextOptions<ProfesorContext> options):base(options)
        {
        }

        public DbSet<Profesor> Profesores { get; set; }
    }
}
