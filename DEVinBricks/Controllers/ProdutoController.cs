using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IObterProdutoService _service;

        public ProdutoController(IObterProdutoService service)
        {
            _service = service;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult ObterProduto(int id)
        {
            try
            {
                var response = _service.ObterProdutoPorId(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("Produto Inexistente");
            }
        }
    }
}
