using System.Collections;
using TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;

namespace TestesDescomplicados.Tests.Unit.Domain;

public sealed class UsuarioClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "", ETipoUsuario.ADMINISTRADOR };
        yield return new object[] { " ", ETipoUsuario.ADMINISTRADOR };
        yield return new object[] { null, ETipoUsuario.ADMINISTRADOR };

        yield return new object[] { "", ETipoUsuario.DESENVOLVEDOR };
        yield return new object[] { " ", ETipoUsuario.DESENVOLVEDOR };
        yield return new object[] { null, ETipoUsuario.DESENVOLVEDOR };

        yield return new object[] { "", ETipoUsuario.USUARIO };
        yield return new object[] { " ", ETipoUsuario.USUARIO };
        yield return new object[] { null, ETipoUsuario.USUARIO };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
