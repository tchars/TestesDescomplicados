using System.ComponentModel.DataAnnotations.Schema;

namespace TestesDescomplicados.Domain.Aggregates.SoftwareAggregate;

public sealed class Software
{
    public long Id { get; private set; }

    public Guid IdUnico { get; private set; }
    public string NomeCliente { get; private set; }

    [NotMapped]
    public IDictionary<Guid, string>? LinhasDoSoftware { get; private set; }

    [NotMapped]
    public IEnumerable<string> Erros { get; private set; }

    private Software(long id, Guid idUnico, string nomeCliente, IDictionary<Guid, string>? linhasDoSoftware, IEnumerable<string> erros)
    {
        Id = id;
        IdUnico = idUnico;
        NomeCliente = nomeCliente;
        LinhasDoSoftware = linhasDoSoftware;
        Erros = erros;
    }

    private Software(string nomeCliente, IEnumerable<string> erros)
    {
        IdUnico = Guid.NewGuid();
        NomeCliente = nomeCliente;
        LinhasDoSoftware = new Dictionary<Guid, string>();
        Erros = erros;
    }

    private Software(string nomeCliente)
    {
        IdUnico = Guid.NewGuid();
        NomeCliente = nomeCliente;
        LinhasDoSoftware = new Dictionary<Guid, string>();
        Erros = [];
    }

    public static Software Criar(string nomeCliente)
    {
        // Essas validações são apenas para exemplo
        // podem e devem ser melhoradas
        var erros = new List<string>();
        if (string.IsNullOrWhiteSpace(nomeCliente))
        {
            erros.Add("Nome do cliente é obrigatório");
            return new Software(nomeCliente, erros);
        }

        return new Software(nomeCliente);
    }

    public void AdicionarLinha(Guid devResponsavel, string linha)
    {
        // faça as validações necessárias :)

        LinhasDoSoftware.Add(devResponsavel, linha);
    }
}
