namespace TestesDescomplicados.UseCases.Usuarios.BuscarTodos;

public sealed class UsuarioDto(long id, Guid idUnico, string nome, string email)
{
    public long Id { get; set; } = id;

    public Guid IdUnico { get; set; } = idUnico;

    public string Nome { get; set; } = nome;

    public string Email { get; set; } = email;
}
