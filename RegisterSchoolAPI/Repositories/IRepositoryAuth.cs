using RegisterSchoolAPI.Dto;

namespace RegisterSchoolAPI.Repositories
{
    public interface IRepositoryAuth
    {
        Task<AccountDto> Authenticate(AuthDto account);
    }
}
