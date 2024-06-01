using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TestesDescomplicados.Infra.Repositories;
using TestesDescomplicados.UseCases.Software.AdicionarLinhas;

namespace TestesDescomplicados.Tests.Unit.UseCases.Software;

public sealed class AdicionarLinhasAoSoftwareUserCaseTests
{
    private readonly ISoftwareRepository _softwareRepository;
    private readonly AdicionarLinhasAoSoftwareUserCase _sut;
    private readonly CancellationToken _cancellationToken;

    public AdicionarLinhasAoSoftwareUserCaseTests()
    {
        _softwareRepository = Substitute.For<ISoftwareRepository>();
        _sut = new AdicionarLinhasAoSoftwareUserCase(_softwareRepository);
        _cancellationToken = new CancellationToken();
    }

    [Fact(DisplayName = "DADA solicitação de inclusão de linhas em um software \n" +
                        "QUANDO o software não existir \n" +
                        "ENTÃO retorna nulo")]
    [Trait("UseCase", "AdicionarLinhasAoSoftwareUserCase")]
    public async Task Handle_DeveRetornarNulo_QuandoSoftwareNaoExistir()
    {
        // Arrange
        var request = new AdicionarLinhasAoSoftwareRequest(Guid.NewGuid(), Guid.NewGuid(), "Linha");

        _softwareRepository
            .BuscarPeloIdUnicoAsync(request.IdUnicoSoftware)
            .ReturnsNullForAnyArgs();

        // Act
        var response = await _sut.Handle(request, _cancellationToken);

        // Assert
        Assert.Null(response);
    }

    [Fact(DisplayName = "DADA solicitação de inclusão de linhas em um software \n" +
                         "QUANDO o software existir \n" +
                         "ENTÃO adiciona a linha e retorna a resposta")]
    [Trait("UseCase", "AdicionarLinhasAoSoftwareUserCase")]
    public async Task Handle_DeveAdicionarLinha_QuandoSoftwareExistir()
    {
        // Arrange
        var software = TestesDescomplicados.Domain.Aggregates.SoftwareAggregate.Software.Criar("NomeCliente");
        var request = new AdicionarLinhasAoSoftwareRequest(Guid.NewGuid(), software.IdUnico, "Linha");

        _softwareRepository
            .BuscarPeloIdUnicoAsync(request.IdUnicoSoftware)
            .Returns(software);

        // Act
        var response = await _sut.Handle(request, _cancellationToken);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(request.IdUnicoSoftware, response.SoftwareIdUnico);
        Assert.Equal(request.DesenvolvedorResponsavel, response.DesenvolvedorResponsavel);
        Assert.Equal(request.LinhaNova, response.LinhaAdicionada);
    }
}
