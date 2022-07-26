using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IValorFretePorEstadoService

    {
       bool VerificarSeExiste(int id);

        ValorFretePorEstadoModel Atualizar(ValorFretePorEstadoDTO dto, int idUsuarioAlteracao);
       

        IEnumerable<ValorFretePorEstadoModel> Consultar(string? nome, int page, int size);
        bool VerificarSeExisteCadastroDoEstado(int estadoId);

        ValorFretePorEstadoPostDTO Adicionar(ValorFretePorEstadoPostDTO dto);
    }
}
