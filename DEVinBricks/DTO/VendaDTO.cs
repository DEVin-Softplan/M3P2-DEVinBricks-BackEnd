using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{
    public class VendaPostDTO
    {
        public int CompradorId { get; set; }
        //public Comprador Comprador { get; set; }
        public int VendedorId { get; set; }
        //public Usuario Vendedor { get; set; }
        //public int FreteId { get; set; }
        //public FreteModel Frete { get; set; }

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
    }









    public class VendaGetDTO
    {        
        public int CompradorId { get; set; }
        public int VendedorId { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }

        public static VendaGetDTO ConverterParaEntidadeVendaGetDTO(//string? nome, string? cpf, 
            int compradorId, int vendedorId, int pagina, int tamanhopagina)
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
