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

        /// <summary>
        /// Método que adiciona um novo registro de Valor de Frete por Estado
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        ValorFretePorEstadoModel Adicionar(ValorFretePorEstadoPostDTO dto, int idUsuario);
    }
}
