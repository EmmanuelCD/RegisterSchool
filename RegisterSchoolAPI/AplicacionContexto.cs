using Microsoft.EntityFrameworkCore;
using Models;

namespace RegisterSchoolAPI
{
    public abstract class AplicacionContexto : DbContext
    {
        public AplicacionContexto(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
    }
}
