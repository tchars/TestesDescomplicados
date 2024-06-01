namespace TestesDescomplicados.UseCases.Usuarios.BuscarTodos;

public sealed class UsuarioDto(Guid id, Guid idUnico, string nome, string email)
{
    public Guid Id { get; set; } = id;

    public Guid IdUnico { get; set; } = idUnico;

    public string Nome { get; set; } = nome;

    public string Email { get; set; } = email;
}
