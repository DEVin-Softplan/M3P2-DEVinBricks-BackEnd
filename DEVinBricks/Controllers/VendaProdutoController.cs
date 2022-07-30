using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Controllers
{
    [Route("api/venda")]
    [ApiController]
    public class VendaProdutoController : ControllerBase
    {
        private readonly IVendaService _service;

        public VendaProdutoController(IVendaService service)
        {
            _service = service;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult ObterVendaProduto(int idVenda)
        {
            try
            {
                var response = _service.ObterVendaProdutoPorIdVenda(idVenda);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("Venda Inexistente");
            }
        }
    }
}
