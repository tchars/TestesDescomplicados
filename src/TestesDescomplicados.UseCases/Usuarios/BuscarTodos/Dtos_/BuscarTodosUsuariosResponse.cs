namespace TestesDescomplicados.UseCases.Usuarios.BuscarTodos;

public sealed class BuscarTodosUsuariosResponse(IEnumerable<UsuarioDto> usuarios)
{
    public IEnumerable<UsuarioDto> Usuarios { get; set; } = usuarios;
}
