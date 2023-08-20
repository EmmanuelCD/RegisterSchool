using RegisterSchoolAPI.Dto;

namespace RegisterSchoolAPI.Domain.Auth
{
    public interface IAuth
    {
        Task<AccountDto> Autenticate(AuthDto account);
    }
}
