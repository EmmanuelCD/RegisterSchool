using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProfesorAula
    {
        [Key]
        public int Id { get; set; }
        public int ProfesorId { get; set; }
        public int AulaId { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualixacion { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;
    }
}
