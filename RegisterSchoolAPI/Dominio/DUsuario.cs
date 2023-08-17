using Models;
using RegisterSchoolAPI.Dto;
using RegisterSchoolAPI.Repositorios;

namespace RegisterSchoolAPI.Dominio
{
    public class DUsuario:IUsuario
    {
        readonly IRepositorioUsuario Repositorio;
        public DUsuario(IRepositorioUsuario repositorio) 
        {
            Repositorio = repositorio;
        }

        public  async Task<IEnumerable<Usuario>> Filter(string parametro)
        {   
            return await Repositorio.Filter(parametro);
        }

        public  async Task<IEnumerable<Usuario>> GetAll()
        {
            return  await Repositorio.GetAll();
        }

        public Usuario GetById(int id)
        {
             var result = Repositorio.GetById(id).Result;
            return new Usuario()
            {
                Id = result.Id,
                Nombre = result.Nombre,
                Email = result.Email,
                Password = "********",
                PerfilId = result.PerfilId,
                Estado = result.Estado,
            };
        }

        public Task<Usuario> GetByName(string name)
        {
            return Repositorio.GetByName(name);
        }

        public Task<(bool, Usuario)> Insert(DtoCreateUsuario usuario)
        {
            var Result = new Usuario()
            {
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Password = usuario.Password,
                PerfilId = usuario.PerfilId,
            };
            return Repositorio.Insert(Result);
        }

        public Task<(bool, Usuario)> Updated(DtoUpdateUsuario usuario, int id)
        {
            var Result = new Usuario()
            {
                Id = id,
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Password = usuario.Password,
                PerfilId = usuario.PerfilId,
                Estado = usuario.Estado,
            };
            return Repositorio.Updated(Result);
        }
    }
}
