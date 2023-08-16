using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Asignatura
    {
        [Key]
        public int Id { get; set; }
        public string CodigoAsignatura { get; set; }
        public int Grado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;


    }
}
