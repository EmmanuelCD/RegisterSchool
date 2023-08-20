using Models;
using RegisterSchoolAPI.Dto;

namespace RegisterSchoolAPI.Domain
{
    public interface IUsuario
    {
        /// <summary>
        /// Metodo para Inserta nuevo usuario
        /// </summary>
        /// <param name="usuario">Objecto usuario</param>
        /// <returns>Un booleano y un objeto <see cref="Usuario" /></returns>
        Task<bool> Insert(DtoCreateUsuario usuario);
        /// <summary>
        /// Metodo para Editar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<bool> Updated(DtoUpdateUsuario usuario, int id);
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
        Task<Usuario> GetById(int id);
        /// <summary>
        /// Metodo para optener un usuario
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Usuario> GetByName(string name);
        Task<IEnumerable<Usuario>> Filter(string parametro);
    }
}
