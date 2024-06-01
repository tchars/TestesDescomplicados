using TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;

namespace TestesDescomplicados.Infra.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> BuscarPeloNomeAsync(string nome);

    Task<IEnumerable<Usuario>> BuscarTodosAsync();

    Task<bool> SalvarUsuarioAsync(Usuario usuario);
}
