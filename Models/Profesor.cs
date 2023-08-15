using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }
        public string CodigoProfesor { get; set; }
        public string Identificacion { get; set; } 
        public string Nombre { get; set; }
        public string Apellido { get; set; } 
        public int Nacionalidad { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;



    }
}
