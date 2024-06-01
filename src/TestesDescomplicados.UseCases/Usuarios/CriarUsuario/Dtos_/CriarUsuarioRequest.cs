using MediatR;
using System.ComponentModel.DataAnnotations;
using TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;

namespace TestesDescomplicados.UseCases.Usuarios.CriarUsuario;

public class CriarUsuarioRequest(string nome, string email, ETipoUsuario tipoUsuario) : IRequest<CriarUsuarioResponse>
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; } = nome;

    [Required(ErrorMessage = "E-mail é obrigatório")]
    public string Email { get; set; } = email;

    [Required(ErrorMessage = "Tipo de usuario é obrigatório")]
    public ETipoUsuario TipoUsuario { get; set; } = tipoUsuario;
}
