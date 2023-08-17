using Models;
using RegisterSchoolAPI.Dto;

namespace RegisterSchoolAPI.Dominio
{
    public interface IUsuario
    {
        /// <summary>
        /// Metodo para Inserta nuevo usuario
        /// </summary>
        /// <param name="usuario">Objecto usuario</param>
        /// <returns>Un booleano y un objeto <see cref="Usuario" /></returns>
        Task<(bool,Usuario)> Insert(DtoCreateUsuario usuario);
        /// <summary>
        /// Metodo para Editar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<(bool, Usuario)> Updated(DtoUpdateUsuario usuario, int id);
        /// <summary>
        /// Metodo para optener una lista de  usuarios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Usuario>> GetAll();
        /// <summary>
        /// Metodo para optener un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario GetById(int id);
        /// <summary>
        /// Metodo para optener un usuario
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Usuario> GetByName(string name);
        Task<IEnumerable<Usuario>> Filter(string parametro);
    }
}
