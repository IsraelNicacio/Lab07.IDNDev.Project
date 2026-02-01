using IDNDev.Cadastro.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace IDNDev.Cadastro.Api.Data;

public class PessoaRepository : IPessoaRepository
{
    private readonly CadastroContext _context;

    public PessoaRepository(CadastroContext context) => _context = context;

    public async Task<IEnumerable<Pessoa>> RetornarLista() 
        => await _context.Pessoas.ToListAsync();

    public async Task<Pessoa?> RecuperarPorId(Guid id) 
        => await _context.Pessoas.Where(w => w.Id == id).FirstOrDefaultAsync();

    public async Task Adicionar(Pessoa pessoa) 
        => await _context.Pessoas.AddAsync(pessoa);

    public void Remover(Pessoa pessoa) 
        => _context.Remove(pessoa);

    public void Dispose() => _context.Dispose();
}