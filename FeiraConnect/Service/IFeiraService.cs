using FeiraConnect.Model;

namespace FeiraConnect.Service
{
    public interface IFeiraService
    {
        Task<IEnumerable<Feira>> GetAll();

        Task<Feira?> GetById(long id);

        Task<IEnumerable<Feira>> GetByNome(string nome);

        Task<Feira?> Create(Feira feira);

        Task<Feira?> Update(Feira feira);

        Task Delete(Feira feira);
    }
}
