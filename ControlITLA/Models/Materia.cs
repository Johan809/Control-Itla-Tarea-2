using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlITLA.Models
{
    public class Materia
    {
        [Key]
        public int MateriaID { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Required(ErrorMessage = "Por favor llenar los datos")]
        public string Codigo { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Nombre { get; set; }
        [Column(TypeName = "int")]
        public int Creditos { get; set; }
    }
}
