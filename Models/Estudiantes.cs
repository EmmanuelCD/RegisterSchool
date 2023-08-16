using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Estudiantes
    {
        [Key]
        public int Id { get; set; }
        public string CodigoEstudiante { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string LugarNacimiento { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;




    }
}
