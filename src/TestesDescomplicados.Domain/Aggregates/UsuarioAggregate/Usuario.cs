namespace TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;

public sealed class Usuario
{
    public long Id { get; private set; }
    public Guid IdUnico { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public ETipoUsuario TipoUsuario { get; private set; }

    private Usuario(Guid idUnico, string nome, string email, ETipoUsuario tipoUsuario)
    {
        IdUnico = idUnico;
        Nome = nome;
        Email = email;
        TipoUsuario = tipoUsuario;
    }

    public Usuario(long id, Guid idUnico, string nome, string email, ETipoUsuario tipoUsuario)
    {
        Id = id;
        IdUnico = idUnico;
        Nome = nome;
        Email = email;
        TipoUsuario = tipoUsuario;
    }

    public static Usuario Criar(string nome, string email, ETipoUsuario tipoUsuario)
    {
        // Aqui devem ocorrer as validações de domínio, por exemplo:
        // E-mail válido / Nome preenchido
        // removido para facilitar entendimento

        return new Usuario(Guid.NewGuid(), nome, email, tipoUsuario);
    }
}
