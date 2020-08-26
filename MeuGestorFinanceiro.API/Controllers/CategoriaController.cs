using MeuGestorFinanceiro.Domains;
using MeuGestorFinanceiro.Repositories;
using MeuGestorFinanceiro.Utils;
using MeuGestorFinanceiro.Validators;
using Microsoft.AspNetCore.Mvc;

namespace MeuGestorFinanceiro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        [HttpPost("salvar")]
        public IActionResult Salvar(CategoriaDomain categoria)
        {
            try
            {
                var validador = new CategoriaValidator().Validate(categoria);
                if (validador.IsValid)
                    new CategoriaRepository().Salvar(categoria);
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
            return Ok(new CategoriaRepository().Listar());
        }
    }
}
