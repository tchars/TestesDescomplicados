using Microsoft.EntityFrameworkCore;
using TestesDescomplicados.Domain.Aggregates.SoftwareAggregate;
using TestesDescomplicados.Infra.Contexts;

namespace TestesDescomplicados.Infra.Repositories;

public sealed class SoftwareRepository(InMemoryContext context) 
    : ISoftwareRepository
{
    private readonly InMemoryContext _context = context;

    public async Task<bool> AdicionarLinhasAsync(Software software)
    {
        _context.Softwares.Update(software);
        var atualizado = await _context.SaveChangesAsync();

        return atualizado > 0;
    }

    public Task<Software?> BuscarPeloIdUnicoAsync(Guid idUnico)
    {
        return _context.Softwares.FirstOrDefaultAsync(usr => usr.IdUnico == idUnico);
    }

    public async Task<bool> SalvarSoftwareAsync(Software software)
    {
        await _context.Softwares.AddAsync(software);
        var salvo = await _context.SaveChangesAsync();

        return salvo > 0;
    }
}
