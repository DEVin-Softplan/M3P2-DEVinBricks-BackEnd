using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{
    public class CompradorPostDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }

        public static Comprador ConverterParaEntidadeComprador(CompradorPostDTO requisicao, int authUserId, int id = 0)
        {
            if (requisicao == null)
                return null;

            return new Comprador()
            {
                Id = id,
                UsuarioInclusaoId = authUserId,
                DataDeInclusao = DateTime.UtcNow,
                Nome = requisicao.Nome,
                Email = requisicao.Email,
                Telefone = requisicao.Telefone,
                DataDeNascimento = requisicao.DataDeNascimento,
                CPF = requisicao.CPF,
                Ativo = requisicao.Ativo,
            };
        }
    }
    public class CompradorGetDTO
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }

        public static CompradorGetDTO ConverterParaEntidadeCompradorGetDTO(string? nome, string? cpf, int pagina, int tamanhopagina)
        {
            return new CompradorGetDTO()
            {
                Nome = nome,
                CPF = cpf,
                Pagina = pagina,
                TamanhoPagina = tamanhopagina
            };
        }
    }
    public class CompradorPatchDTO
    {
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
