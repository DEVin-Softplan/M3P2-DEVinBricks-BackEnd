using DEVinBricks.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FretePorEstadoController : ControllerBase
    {
        private readonly IFretePorEstadoRepository _repository;
        public FretePorEstadoController(IFretePorEstadoRepository context)
        {
            _repository = context;
        }

       
    }
}
