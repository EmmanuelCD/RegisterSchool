using Microsoft.EntityFrameworkCore;
using Models;
using RegisterSchoolAPI.Repositories;
using System.Reflection.Metadata;

namespace RegisterSchoolAPI.Services
{
    public class ServicioUsuario : IRepositorioUsuario
    {
        readonly AplicacionContexto Contexto;
        private readonly IConfiguration _configuration;
        public ServicioUsuario(AplicacionContexto contexto, IConfiguration configuration)
        {
            Contexto = contexto;
            _configuration = configuration;
        }
        public async Task<IEnumerable<Usuario>> Filter(string parametro)
        {
            List<Usuario> Result = await Contexto.Usuario.Where(x => x.Nombre == parametro).ToListAsync();
            if (Result == null)
            {
                return new List<Usuario>();
            }
            return Result;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            List<Usuario> Result = await Contexto.Usuario.ToListAsync();
            if (Result == null)
            {
                return new List<Usuario>();
            }
            return Result;
        }

        public async Task<Usuario> GetById(int id)
        {
            Usuario Result = await Contexto.Usuario.Where(x => x.Id == id).FirstAsync();
            if (Result == null)
            {
                return null;
            }
            return Result;
        }

        public async Task<Usuario> GetByName(string name)
        {
            Usuario Result = await Contexto.Usuario.Where(x => x.Nombre == name).FirstAsync();
            if (Result == null)
            {
                return null;
            }
            return Result;

        }

        public async Task<bool> Insert(Usuario usuario)
        {
            await Contexto.Usuario.AddAsync(usuario);
            if (await Contexto.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> Updated(Usuario usuario)
        {
            var UserValid = await Contexto.Usuario.AsNoTracking().Where(x => x.Id == usuario.Id).FirstOrDefaultAsync();
            if (UserValid == null)
                return false;
            var result = new Usuario()
            {
                Id = usuario.Id,
                Email = usuario.Email != "" ? usuario.Email : UserValid.Email,
                Nombre = usuario.Nombre != "" ? usuario.Nombre : UserValid.Nombre,
                Password = usuario.Password != "" ? usuario.Password : UserValid.Password,
                PerfilId = usuario.PerfilId != 0 ? usuario.PerfilId : UserValid.PerfilId,
                Estado = usuario.Estado,
                FechaActualizacion = usuario.FechaActualizacion,
                FechaCreacion = UserValid.FechaCreacion,
            };

            Contexto.Usuario.Update(result);
            if (await Contexto.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;

        }
    }
}
