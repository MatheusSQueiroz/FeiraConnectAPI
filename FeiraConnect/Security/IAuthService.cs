using FeiraConnect.Model;

namespace FeiraConnect.Security
{
    public interface IAuthService
    {
        Task<UserLogin?> Autenticar(UserLogin userLogin);
    }
}
