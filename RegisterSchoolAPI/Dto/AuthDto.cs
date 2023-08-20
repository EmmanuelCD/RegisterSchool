using System.ComponentModel.DataAnnotations;

namespace RegisterSchoolAPI.Dto
{
    public class AuthDto
    {
        [Required(ErrorMessage = "El nombre de usuario no puede estar vacio")]
        [MinLength(4, ErrorMessage = "El nombre de usuario debe contender almenos 5 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña de usuario no puede estar en blanco")]
        [MinLength(8, ErrorMessage = "La contraseña de usuario debe contener almenos 8 caracteres.")]
        public string Password { get; set; } = string.Empty;
    }
}
