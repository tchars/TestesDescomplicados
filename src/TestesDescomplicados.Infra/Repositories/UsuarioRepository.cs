using Microsoft.EntityFrameworkCore;
using TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;
using TestesDescomplicados.Infra.Contexts;

namespace TestesDescomplicados.Infra.Repositories;

public sealed class UsuarioRepository(InMemoryContext context) 
    : IUsuarioRepository
{
    private readonly InMemoryContext _context = context;

    public async Task<IEnumerable<Usuario>> BuscarTodosAsync() 
        => await _context.Usuarios.ToListAsync();

    public Task<Usuario?> BuscarPeloNomeAsync(string nome) 
        => _context.Usuarios.FirstOrDefaultAsync(usr => usr.Nome == nome);

    public async Task<bool> SalvarUsuarioAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        var salvo = await _context.SaveChangesAsync();

        return salvo > 0;
    }
}
