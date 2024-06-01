namespace TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;

public sealed class Usuario
{
    public Guid Id { get; private set; }
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

    public static Usuario? Criar(string nome, string email, ETipoUsuario tipoUsuario)
    {
        // Refatorando para validar o email
        if (string.IsNullOrWhiteSpace(email))
            return default;

        return new Usuario(Guid.NewGuid(), nome, email, tipoUsuario);
    }
}
