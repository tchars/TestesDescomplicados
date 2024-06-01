using MediatR;

namespace TestesDescomplicados.UseCases.Software.AdicionarLinhas;

public sealed class AdicionarLinhasAoSoftwareRequest(Guid desenvolvedorResponsavel, Guid idUnicoSoftware, string linhaNova) 
    : IRequest<AdicionarLinhasAoSoftwareResponse>
{
    public Guid DesenvolvedorResponsavel { get; set; } = desenvolvedorResponsavel;

    public Guid IdUnicoSoftware { get; set; } = idUnicoSoftware;

    public string LinhaNova { get; set; } = linhaNova;
}
