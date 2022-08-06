using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{
    public class VendaPostDTO
    {
        public int CompradorId { get; set; }
        public Comprador Comprador { get; set; }
        public int VendedorId { get; set; }
        public Usuario Vendedor { get; set; }
        //public int FreteId { get; set; }
        //public FreteModel Frete { get; set; }

        public int Id { get; set; }
        public DateTime DataDeInclusao { get; set; }        
        public int UsuarioInclusaoId { get; set; }
        public Usuario UsuarioInclusao { get; set; }
        public DateTime? DataDeAlteracao { get; set; }        
        public int? UsuarioAlteracaoId { get; set; }
        public Usuario? UsuarioAlteracao { get; set; }

        public static VendaModel ConverterParaEntidadeVenda(VendaPostDTO requisicao, int id = 0)
        {
            if (requisicao == null)
                return null;            
            

            return new VendaModel()
            {
                Id = id,                
                CompradorId = requisicao.CompradorId,                
                VendedorId = requisicao.VendedorId
            };
        }

        public static VendaPostDTO ConverterParaVendaPostDTO(VendaModel entidade)
        {
            return new VendaPostDTO()
            {
                Id = entidade.Id,
                CompradorId = entidade.CompradorId,
                Comprador = entidade.Comprador,
                VendedorId = entidade.VendedorId,
                Vendedor = entidade.Vendedor,
                UsuarioInclusaoId = entidade.UsuarioInclusaoId,
                UsuarioInclusao = entidade.UsuarioInclusao,
                DataDeInclusao = entidade.DataDeInclusao,
                UsuarioAlteracaoId = entidade.UsuarioAlteracaoId,
                UsuarioAlteracao = entidade.UsuarioAlteracao,
                DataDeAlteracao = entidade.DataDeAlteracao,
            };
        }
    }

    public class VendaGetDTO
    {        
        public int CompradorId { get; set; }
        public int VendedorId { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }

        public static VendaGetDTO ConverterParaEntidadeVendaGetDTO(int compradorId, int vendedorId, int pagina, int tamanhopagina)
        {
            return new VendaGetDTO()
            {               
                CompradorId = compradorId,
                VendedorId = vendedorId,
                Pagina = pagina,
                TamanhoPagina = tamanhopagina
            };
        }
    }
}
