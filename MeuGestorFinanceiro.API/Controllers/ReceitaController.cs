using MeuGestorFinanceiro.Domains;
using MeuGestorFinanceiro.Repositories;
using MeuGestorFinanceiro.Utils;
using MeuGestorFinanceiro.Validators;
using Microsoft.AspNetCore.Mvc;

namespace MeuGestorFinanceiro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceitaController : ControllerBase
    {
        [HttpPost("salvar")]
        public IActionResult Salvar(ReceitaDomain receita)
        {
            var validador = new TransacaoValidator().Validate(receita);
            try
            {
                if (validador.IsValid)
                    new ReceitaRepository().Salvar(receita);
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
            return Ok(new ReceitaRepository().Listar());
        }

        [HttpGet("listar-pendentes")]
        public IActionResult ListarPendentes()
        {
            return Ok(new ReceitaRepository().Listar(false));
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                new ReceitaRepository().Deletar(id);
            }
            catch
            {
                return BadRequest(Constantes.msgErroDeletar);
            }
            return Ok(Constantes.msgSucessoDeletar);
        }
    }
}
