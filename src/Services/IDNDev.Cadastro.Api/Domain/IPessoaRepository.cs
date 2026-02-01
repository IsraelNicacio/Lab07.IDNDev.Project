using IDN.Core.Data;

namespace IDNDev.Cadastro.Api.Domain;

public interface IPessoaRepository : IRepository<Pessoa>
{
    Task<IEnumerable<Pessoa>> RetornarLista();
    Task<Pessoa> RecuperarPorId(Guid id);
    Task Adicionar(Pessoa pessoa);
    void Remover(Pessoa pessoa);
}
