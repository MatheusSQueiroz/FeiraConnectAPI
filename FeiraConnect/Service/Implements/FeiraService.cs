using FeiraConnect.Model;

namespace FeiraConnect.Service.Implements
{
    public class FeiraService : IFeiraService
    {
        public FeiraService()
        {
        }
        public Task<IEnumerable<Feira>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Feira?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Feira>> GetByNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<Feira?> Create(Feira feira)
        {
            throw new NotImplementedException();
        }
        public Task<Feira?> Update(Feira feira)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Feira feira)
        {
            throw new NotImplementedException();
        }

    }
}
