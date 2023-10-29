using FeiraConnect.Data;
using FeiraConnect.Model;
using Microsoft.EntityFrameworkCore;

namespace FeiraConnect.Service.Implements
{
    public class UserService : IUserService
    {
        public readonly AppDbContext _context;

            public UserService(AppDbContext context)
            {
                _context = context;

            }

            public async Task<IEnumerable<User>> GetAll()
            {
                return await _context.Users
                    .ToListAsync();
            }

            public async Task<User?> GetById(long id)
            {
                try
                {
                    var Usuario = await _context.Users
                        .FirstAsync(u => u.Id == id);

                    Usuario.Senha = "";

                    return Usuario;
                }
                catch
                {
                    return null;
                }

            }

            public async Task<User?> GetByEmail(string email)
            {
                try
                {
                    var BuscaUsuario = await _context.Users
                        .Where(u => u.Email == email)
                        .FirstOrDefaultAsync();

                    return BuscaUsuario;
                }
                catch
                {
                    return null;
                }
            }

            public async Task<User?> Create(User usuario)
            {
                var BuscaUsuario = await GetByEmail(usuario.Email);

                if (BuscaUsuario is not null)
                    return null;

                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha, workFactor: 10);

                _context.Users.Add(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }

            public async Task<User?> Update(User usuario)
            {

                var UsuarioUpdate = await _context.Users.FindAsync(usuario.Id);

                if (UsuarioUpdate is null)
                    return null;

                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha, workFactor: 10);

                _context.Entry(UsuarioUpdate).State = EntityState.Detached;
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return usuario;
            }
    }
}
