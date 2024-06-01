using MediatR;
using TestesDescomplicados.Infra.Repositories;

namespace TestesDescomplicados.UseCases.Software.AdicionarLinhas;

public sealed class AdicionarLinhasAoSoftwareUserCase(ISoftwareRepository softwareRepository)
    : IRequestHandler<AdicionarLinhasAoSoftwareRequest, AdicionarLinhasAoSoftwareResponse>
{
    private readonly ISoftwareRepository _softwareRepository = softwareRepository;

    public async Task<AdicionarLinhasAoSoftwareResponse?> Handle(AdicionarLinhasAoSoftwareRequest request, 
        CancellationToken cancellationToken)
    {
        var software = await _softwareRepository.BuscarPeloIdUnicoAsync(request.IdUnicoSoftware);

        if (software is null)
            return default;

        software.AdicionarLinha(request.DesenvolvedorResponsavel, request.LinhaNova);

        await _softwareRepository.AdicionarLinhasAsync(software);

        return new AdicionarLinhasAoSoftwareResponse
        {
            SoftwareId = software.IdUnico,
            DesenvolvedorResponsavel = request.DesenvolvedorResponsavel,
            LinhaAdicionada = request.LinhaNova
        };
    }
}
