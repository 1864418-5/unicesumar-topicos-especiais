using MeuGestorFinanceiro.Domains;
using MeuGestorFinanceiro.Repositories;
using MeuGestorFinanceiro.Utils;
using MeuGestorFinanceiro.Validators;
using Microsoft.AspNetCore.Mvc;

namespace MeuGestorFinanceiro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesaController : ControllerBase
    {
        [HttpPost("salvar")]
        public IActionResult Salvar(DespesaDomain despesa)
        {
            var validador = new TransacaoValidator().Validate(despesa);
            try
            {
                if (validador.IsValid)
                    new DespesaRepository().Salvar(despesa);
                else
                    return BadRequest(validador.ToString("\n"));
            }
            catch
            {
                return BadRequest();
            }
            return Ok(Constantes.msgSucessoAtualizarRegistro);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(new DespesaRepository().Listar());
        }

        [HttpGet("listar-pendentes")]
        public IActionResult ListarPendentes()
        {
            return Ok(new DespesaRepository().Listar(false));
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                new DespesaRepository().Deletar(id);
            }
            catch
            {
                return BadRequest(Constantes.msgErroDeletar);
            }
            return Ok(Constantes.msgSucessoDeletar);
        }
    }
}
