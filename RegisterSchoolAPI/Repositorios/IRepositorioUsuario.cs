using Models;

namespace RegisterSchoolAPI.Repositorios
{
    public interface IRepositorioUsuario
    {
        /// <summary>
        /// Metodo para Inserta nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<(bool, Usuario)> Insert(Usuario usuario);
        /// <summary>
        /// Metodo para Editar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<(bool, Usuario)> Updated(Usuario usuario);
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
