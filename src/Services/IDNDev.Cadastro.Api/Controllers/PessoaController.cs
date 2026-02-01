using IDNDev.Cadastro.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IDNDev.Cadastro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository) => _pessoaRepository = pessoaRepository;

        [HttpGet(Name = "listartodos")]
        public async Task<IActionResult> Get()
        {
            var pessoa = await _pessoaRepository.RetornarLista();

            return Ok(pessoa);
        }
    }
}
