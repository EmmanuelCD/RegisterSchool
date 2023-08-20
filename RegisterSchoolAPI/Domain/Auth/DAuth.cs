using RegisterSchoolAPI.Dto;
using RegisterSchoolAPI.Repositories;

namespace RegisterSchoolAPI.Domain.Auth
{
    public class DAuth : IAuth
    {
        readonly IRepositoryAuth _RepositoryAuth;
        public DAuth(IRepositoryAuth repositoryAuth)
        {
            _RepositoryAuth = repositoryAuth;
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public Task<AccountDto> Autenticate(AuthDto account)
        {
            var passwordhash = EncodePasswordToBase64(account.Password);
            account.Password = passwordhash;
            return _RepositoryAuth.Authenticate(account);
        }
    }
}
