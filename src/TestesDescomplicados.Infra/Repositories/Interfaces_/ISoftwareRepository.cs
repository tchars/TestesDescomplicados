using TestesDescomplicados.Domain.Aggregates.SoftwareAggregate;

namespace TestesDescomplicados.Infra.Repositories;

public interface ISoftwareRepository
{
    Task<bool> SalvarSoftwareAsync(Software usuario);

    Task<bool> AdicionarLinhasAsync(Software usuario);

    Task<Software?> BuscarPeloIdUnicoAsync(Guid idUnico);
}
