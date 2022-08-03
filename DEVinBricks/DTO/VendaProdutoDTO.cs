using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{    
    public class VendaProdutoGetDTO
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }

        public static VendaProdutoGetDTO ConverterParaEntidadeVendaProdutoGetDTO(string? nome, string? cpf, int pagina, int tamanhopagina)
        {
            return new VendaProdutoGetDTO()
            {
                Nome = nome,
                CPF = cpf,
                Pagina = pagina,
                TamanhoPagina = tamanhopagina
            };
        }
    }
}
