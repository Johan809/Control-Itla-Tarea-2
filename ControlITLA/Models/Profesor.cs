using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlITLA.Models
{
    public class Profesor
    {
        [Key]
        public int ProfesorID { get; set; }
        [Column(TypeName = "varchar(15)")]
        [Required(ErrorMessage = "Por favor llenar los datos")]
        public string Area { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string Genero { get; set; }
        [Column(TypeName = "int")]
        public int Edad { get; set; }
    }
}
