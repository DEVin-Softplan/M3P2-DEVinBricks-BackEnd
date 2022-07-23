using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IValorFretePorEstadoService

    {
       bool VerificarSeExiste(int id);

        ValorFretePorEstadoModel Atualizar(ValorFretePorEstadoDTO dto, int idUsuarioAlteracao);
       
    }
}
