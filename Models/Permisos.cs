using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Permisos: ModeloBase
    {
        public int PerfilId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
