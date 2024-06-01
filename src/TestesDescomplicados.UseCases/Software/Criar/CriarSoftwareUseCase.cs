using MediatR;
using TestesDescomplicados.Infra.Repositories;

namespace TestesDescomplicados.UseCases.Software.Criar;

public sealed class CriarSoftwareUseCase(ISoftwareRepository softwareRepository) 
    : IRequestHandler<CriarSoftwareRequest, CriarSoftwareResponse?>
{
    private readonly ISoftwareRepository _softwareRepository = softwareRepository;

    public async Task<CriarSoftwareResponse?> Handle(CriarSoftwareRequest request, CancellationToken cancellationToken)
    {
        var novoSoftware = Domain.Aggregates.SoftwareAggregate.Software.Criar(request.NomeCliente);

        if (novoSoftware is null || novoSoftware.Erros.Any()) 
            return default;

        var criado = await _softwareRepository.SalvarSoftwareAsync(novoSoftware);

        if (!criado)
            return default;

        return new CriarSoftwareResponse(novoSoftware.IdUnico, novoSoftware.NomeCliente);
    }
}
