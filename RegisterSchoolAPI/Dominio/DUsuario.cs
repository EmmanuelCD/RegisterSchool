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

        public async Task<Usuario> GetById(int id)
        {
            var result = await Repositorio.GetById(id);
            if (result == null)
                return null;

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

        public async Task<bool> Insert(DtoCreateUsuario usuario)
        {
            var Result = new Usuario()
            {
                Email = usuario.Email != "string" ? usuario.Email : "",
                Nombre = usuario.Nombre != "string" ? usuario.Nombre : "",
                Password = usuario.Password != "string" ? usuario.Password : "",
                PerfilId = usuario.PerfilId,
            };
            return await Repositorio.Insert(Result);
        }

        public async Task<bool> Updated(DtoUpdateUsuario usuario, int id)
        {
            var Result = new Usuario()
            {
                Id = id,
                Email = usuario.Email != "string" ? usuario.Email : "",
                Nombre = usuario.Nombre != "string" ? usuario.Nombre : "",
                Password = usuario.Password != "string" ? usuario.Password : "",
                PerfilId = usuario.PerfilId,
                Estado = usuario.Estado,
                FechaActualizacion = DateTime.Now
            };
            return await Repositorio.Updated(Result);
        }
    }
}
