using Lista4.Models;
using Lista4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lista4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        public IActionResult AdicionarPessoa(Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Cpf))
            {
                return BadRequest("O CPF não pode ser vazio");
            }

            _pessoaRepository.AdicionarPessoa(pessoa);

            return Created(string.Empty, "Pessoa cadastrada com sucesso");
        }

        [HttpPut]
        public IActionResult AtualizarPessoa(Pessoa pessoa)
        {
            try
            {
                _pessoaRepository.AtualizarPessoa(pessoa);
                return Ok("Pessoa atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult RemoverPessoa(string cpf)
        {
            try
            {
                _pessoaRepository.RemoverPessoa(cpf);
                return Ok("Pessoa removida com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetPessoas()
        {
            return Ok(_pessoaRepository.GetPessoas());
        }

        [HttpGet]
        [Route("getByCpf")]
        public IActionResult GetByCpf(string cpf)
        {
            var pessoaPesquisada = _pessoaRepository.GetByCpf(cpf);

            if (pessoaPesquisada is null)
            {
                return BadRequest("Não existe nenhuma pessoa com esse CPF");
            }

            return Ok(pessoaPesquisada);
        }

        [HttpGet]
        [Route("getByImc")]
        public IActionResult GetByImc()
        {
            var listaImcBom = _pessoaRepository.GetByImc();

            if (listaImcBom.Count == 0)
            {
                return Ok("Nenhuma pessoa com IMC bom foi encontrada");
            }

            return Ok(listaImcBom);
        }

        [HttpGet]
        [Route("getByNome")]
        public IActionResult GetByNome(string nome)
        {
            var pessoaPesquisada = _pessoaRepository.GetByNome(nome);

            if (pessoaPesquisada is null)
            {
                return BadRequest("Não existe nenhuma pessoa com esse nome");
            }

            return Ok(pessoaPesquisada);
        }
    }
}
