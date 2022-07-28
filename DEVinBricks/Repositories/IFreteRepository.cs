using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Repositories
{
    public interface IFreteRepository
    {
        public FreteModel ObterFretePorId(int id);
    }
}
