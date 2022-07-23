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

        [HttpGet]
        public ActionResult ObterProduto(int id)
        {
            var response = _service.ObterProdutoPorId(id);
            return Ok(response);
        }
    }
}
