using TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;

namespace TestesDescomplicados.Tests.Unit.Domain;

public sealed class UsuarioTests
{
    [Fact(DisplayName = "DADO uma solicitação para criar um usuário \n" +
                        "QUANDO for um e-mail válido \n" +
                        "ENTÃO cria o usuário")]
    [Trait("Domain", "Usuario")]
    public void Domain_Usuario_Email_Valido_Tipo_Especifico_Sucesso()
    {
        // Arrange
        var usuarioBuilder = new UsuarioBuilder()
                                    .ComNome("Charles J")
                                    .ComEmail("cbjamil@gmail.com")
                                    .ComTipoUsuario(ETipoUsuario.ADMINISTRADOR)
                                    .Build();

        // Act
        var usuario = Usuario.Criar(usuarioBuilder.Nome, usuarioBuilder.Email, usuarioBuilder.TipoUsuario);

        // Assert
        Assert.NotNull(usuario);
    }

    [Theory(DisplayName = "DADO uma solicitação para criar um usuário \n" +
                          "QUANDO for fornecido e-mail inválido \n" +
                          "ENTÃO não deve criar usuario ")]
    [Trait("Domain", "Usuario")]
    [ClassData(typeof(UsuarioClassData))]
    public void Domain_Usuario_Email_Invalido_Todos_Perfis_Erro(string emailInvalido, ETipoUsuario tipoUsuario)
    {
        // Arrange
        var nome = "Charles J";

        // Act
        var usuario = Usuario.Criar(nome, emailInvalido, tipoUsuario);

        // Assert
        Assert.Null(usuario);
    }
}
