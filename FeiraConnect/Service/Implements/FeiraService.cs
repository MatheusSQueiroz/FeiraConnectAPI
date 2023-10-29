using FeiraConnect.Data;
using FeiraConnect.Model;
using Microsoft.EntityFrameworkCore;

namespace FeiraConnect.Service.Implements
{
    public class FeiraService : IFeiraService
    {
        private readonly AppDbContext _context;
        public FeiraService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Feira>> GetAll()
        {
            return await _context.Feiras.ToListAsync();
        }

        public async Task<Feira?> GetById(long id)
        {
            try
            {
                var Feira = await _context.Feiras
                    .FirstAsync(i => i.Id == id);

                return Feira;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Feira>> GetByNome(string nome)
        {
            var Feira = await _context.Feiras
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();

            return Feira;
        }

        public async Task<Feira?> Create(Feira feira)
        {
            await _context.Feiras.AddAsync(feira);
            await _context.SaveChangesAsync();

            return feira;
        }
        public async Task<Feira?> Update(Feira feira)
        {
            var FeiraUpdate = await _context.Feiras.FindAsync(feira.Id);

            if (FeiraUpdate is null)
                return null;

            _context.Entry(FeiraUpdate).State = EntityState.Detached;
            _context.Entry(feira).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return feira;

        }

        public async Task Delete(Feira feira)
        {
            _context.Feiras.Remove(feira);
            await _context.SaveChangesAsync();
        }

    }
}
