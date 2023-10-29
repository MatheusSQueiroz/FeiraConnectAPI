using FeiraConnect.Model;

namespace FeiraConnect.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<User?> GetById(long id);

        Task<User?> GetByEmail(string email);

        Task<User?> Create(User usuario);

        Task<User?> Update(User usuario);
    }
}
