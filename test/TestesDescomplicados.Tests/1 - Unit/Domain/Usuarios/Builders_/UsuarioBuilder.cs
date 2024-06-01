using TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;

namespace TestesDescomplicados.Tests.Unit.Domain;

public sealed class UsuarioBuilder
{
    private string _nome = string.Empty;
    private string _email = string.Empty;
    private ETipoUsuario? _tipoUsuario = null;

    public UsuarioBuilder ComNome(string nome)
    {
        _nome = nome;
        return this;
    }

    public UsuarioBuilder ComEmail(string email)
    {
        _email = email;
        return this;
    }

    public UsuarioBuilder ComTipoUsuario(ETipoUsuario tipoUsuario)
    {
        _tipoUsuario = tipoUsuario;
        return this;
    }

    public Usuario Build()
    {
        return Usuario.Criar(_nome, _email, _tipoUsuario.Value);
    }
}
