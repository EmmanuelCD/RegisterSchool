using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using RegisterSchoolAPI.Dto;
using RegisterSchoolAPI.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RegisterSchoolAPI.Services
{
    public class ServicioAutenticacion :IRepositoryAuth
    {
        private readonly AplicacionContexto Contexto;
        private readonly IConfiguration _configuration;
        public ServicioAutenticacion(AplicacionContexto contexto, IConfiguration configuration)
        {
            Contexto = contexto;
            _configuration = configuration;
        }

        public async Task<AccountDto> Authenticate(AuthDto auth)
        {
            
            try
            {

                var result = await Contexto.Usuario.FirstOrDefaultAsync(user => user.Email.ToLower() == auth.Email.ToLower()
                && user.Password == auth.Password);
                if (result == null)
                {
                    return null;
                }
                var token = GenerateToken(result);
                AccountDto userResult = new()
                {
                    Nombre = result.Nombre,
                    Email = result.Email,
                    PerfilId = result.PerfilId,
                    Token = token,
                };
                return userResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        private string GenerateToken(Usuario result)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, result.Nombre),
                new Claim(ClaimTypes.Email,result.Email),
                new Claim(ClaimTypes.Role, result.PerfilId.ToString())
            };
            //Token
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
