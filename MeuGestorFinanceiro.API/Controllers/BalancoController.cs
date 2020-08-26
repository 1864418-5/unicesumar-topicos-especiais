using MeuGestorFinanceiro.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeuGestorFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new BalancoFinanceiroService().Balanco);
        }
    }
}
