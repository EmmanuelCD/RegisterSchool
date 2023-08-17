using System.ComponentModel.DataAnnotations;

namespace RegisterSchoolAPI.Dto
{
    public class DtoCreateUsuario
    {
      
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int PerfilId { get; set; }
    }
    public class DtoUpdateUsuario
    {
        public string Nombre { get; set; } = string.Empty;
       
        public string Password { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        public int PerfilId { get; set; }
        public int Estado { get; set; } = 1;
    }
}
