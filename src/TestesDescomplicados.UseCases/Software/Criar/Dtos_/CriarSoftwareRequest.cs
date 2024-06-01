using MediatR;

namespace TestesDescomplicados.UseCases.Software.Criar;

public sealed class CriarSoftwareRequest(string nomeCliente)
    : IRequest<CriarSoftwareResponse?>
{
    public string NomeCliente { get; set; } = nomeCliente;
}
