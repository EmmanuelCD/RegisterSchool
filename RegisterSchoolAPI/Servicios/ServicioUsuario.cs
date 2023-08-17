using Microsoft.EntityFrameworkCore;
using Models;
using RegisterSchoolAPI.Repositorios;
using System.Reflection.Metadata;

namespace RegisterSchoolAPI.Servicios
{
    public class ServicioUsuario : IRepositorioUsuario
    {
        AplicacionContexto Contexto;
        private readonly IConfiguration _configuration;
        public ServicioUsuario(AplicacionContexto contexto, IConfiguration configuration)
        {
            Contexto = contexto;
            _configuration = configuration;
        }
        public async Task<IEnumerable<Usuario>> Filter(string parametro)
        {
            try
            {
                List<Usuario> Result = await Contexto.Usuario.Where( x => x.Nombre == parametro).ToListAsync();
                if(Result == null)
                {
                    return new List<Usuario>();
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            try
            {
                List<Usuario> Result = await Contexto.Usuario.ToListAsync();
                if (Result == null)
                {
                    return new List<Usuario>();
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Usuario> GetById(int id)
        {
            try
            {
                Usuario Result = await Contexto.Usuario.Where(x => x.Id == id).FirstAsync();
                if (Result == null)
                {
                    return new Usuario();
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Usuario> GetByName(string name)
        {
            try
            {
                Usuario Result = await Contexto.Usuario.Where( x => x.Nombre == name).FirstAsync();
                if (Result == null)
                {
                    return new Usuario();
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<(bool, Usuario)> Insert(Usuario usuario)
        {
            try
            {
                 await Contexto.Usuario.AddAsync(usuario);
                if (Contexto.SaveChanges() > 0)
                {
                    return (true, usuario);
                }
                return (false, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<(bool, Usuario)> Updated(Usuario usuario)
        {
            try
            {
                Contexto.Entry(usuario).State = EntityState.Modified;
                if (await Contexto.SaveChangesAsync() > 0)
                {
                    return (true, usuario);
                }
                return (false, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
