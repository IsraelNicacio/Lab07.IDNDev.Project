using Microsoft.EntityFrameworkCore;
using IDNDev.Cadastro.Api.Data;
using IDNDev.Cadastro.Api.Domain;

namespace IDNDev.Cadastro.Test;

public class PessoaRepositoryTests
{
    private CadastroContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<CadastroContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new CadastroContext(options);
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Adicionar_DevePersistirPessoa()
    {
        using var context = CreateInMemoryContext();
        var repo = new PessoaRepository(context);

        var pessoa = new Pessoa("João Silva", "12345678901", 30);
        await repo.Adicionar(pessoa);
        await context.SaveChangesAsync();

        var lista = await repo.RetornarLista();

        Assert.That(lista, Is.Not.Null);
        Assert.That(lista.Any(p => p.Documento == "12345678901"), Is.True);
    }

    [Test]
    public async Task RecuperarPorId_DeveRetornarPessoaQuandoExistir()
    {
        using var context = CreateInMemoryContext();
        var repo = new PessoaRepository(context);

        var pessoa = new Pessoa("Maria", "98765432100", 25);
        await repo.Adicionar(pessoa);
        await context.SaveChangesAsync();

        var fetched = await repo.RecuperarPorId(pessoa.Id);

        Assert.That(fetched, Is.Not.Null);
        Assert.That(fetched?.Nome, Is.EqualTo("Maria"));
    }
}
