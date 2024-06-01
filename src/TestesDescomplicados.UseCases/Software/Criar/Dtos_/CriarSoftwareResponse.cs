namespace TestesDescomplicados.UseCases.Software.Criar;

public sealed class CriarSoftwareResponse(Guid idUnico, string nomeCliente)
{
    public Guid IdUnico { get; set; } = idUnico;

    public string NomeCliente { get; set; } = nomeCliente;
}
