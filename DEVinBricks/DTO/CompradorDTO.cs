using DEVinBricks.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace DEVinBricks.DTO
{
    public class CompradorPostDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "DataDeNascimento é obrigatório.")]
        public string DataDeNascimento { get; set; }
        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string CPF { get; set; }

        public static Comprador ConverterParaEntidadeComprador(CompradorPostDTO requisicao, int authUserId, DateTime dataDeNascimento)
        {
            if (requisicao == null)
                return null;

            return new Comprador()
            {
                UsuarioInclusaoId = authUserId,
                DataDeInclusao = DateTime.Now,
                Nome = requisicao.Nome,
                Email = requisicao.Email,
                Telefone = requisicao.Telefone,
                DataDeNascimento = dataDeNascimento,
                CPF = requisicao.CPF,
                Ativo = true
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
