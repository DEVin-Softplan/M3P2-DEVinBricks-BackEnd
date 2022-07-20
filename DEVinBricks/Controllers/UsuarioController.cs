using DEVinBricks.Models;
using DEVinBricks.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly DEVinBricksContext _context;

        private IUsuarioRepository _service;

        public UsuarioController(IUsuarioRepository context)
        {
            _service = context;
        }

     
    }
}
