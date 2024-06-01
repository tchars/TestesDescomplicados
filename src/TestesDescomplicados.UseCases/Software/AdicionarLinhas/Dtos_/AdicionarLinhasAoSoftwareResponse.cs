namespace TestesDescomplicados.UseCases.Software.AdicionarLinhas;

public sealed class AdicionarLinhasAoSoftwareResponse
{
    public string LinhaAdicionada { get; set; }

    public Guid DesenvolvedorResponsavel { get; set; }

    public Guid SoftwareId { get; set; }
}