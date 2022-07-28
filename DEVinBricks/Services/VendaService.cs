using DEVinBricks.Repositories.Models;
using DEVinBricks.Repositories;
using DEVinBricks.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using DEVinBricks.DTO;

namespace DEVinBricks.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }
        public async Task<int> CadastrarNovaVenda(Venda venda)
        {
            var usuarioId = await _usuarioRepository.CadastrarUsuario(usuario);
            EnviarEmailParaFila(usuario);
            return usuarioId;
        }

        public async Task<bool> VerificarSeEmailExiste(string email)
        {
            return await _usuarioRepository.VerificarSeEmailExiste(email);
        }

        public async Task<bool> VerificarSeLoginExiste(string login)
        {
            return await _usuarioRepository.VerificarSeLoginExiste(login);
        }

        public async Task<Usuario?> VerificarDadosAlterados(EditarUsuarioDTO usuarioAlterado)
        {
            try
            {
                var usuario = _usuarioRepository.ObterUsuarioPorId(usuarioAlterado.Id);

                if(usuario == null) return null;

                if (verificaSeTemConteudo(usuarioAlterado.Nome))
                {
                    usuario.Nome = usuarioAlterado.Nome;
                }

                if (verificaSeTemConteudo(usuarioAlterado.Email))
                {
                    usuario.Email = usuarioAlterado.Email;
                }

                if (verificaSeTemConteudo(usuarioAlterado.Login))
                {
                    usuario.Login = usuarioAlterado.Login;
                }

                if (usuarioAlterado.Admin != null)
                {
                    usuario.Admin = (bool)usuarioAlterado.Admin;
                }

                if (usuarioAlterado.Ativo != null)
                {
                    usuario.Ativo = (bool)usuarioAlterado.Ativo;
                }

                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException); ;
            }
        }

        public async Task AlterarDadosUsuario(Usuario usuarioAlterado, int idUsuarioAlteracao)
        {
            try
            {
                usuarioAlterado.DataDeAlteracao = DateTime.Now;
                usuarioAlterado.UsuarioAlteracaoId = idUsuarioAlteracao;
                usuarioAlterado.UsuarioAlteracao = _usuarioRepository.ObterUsuarioPorId(idUsuarioAlteracao);

                await _usuarioRepository.AlterarDados(usuarioAlterado);

                return;
            }
            catch (Exception ex)
            {

                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException); ;
            }
        }

        public bool verificaSeTemConteudo(string texto)
        {
            if (texto == null || texto == "" || texto == " ") return false;
            return true;
        }

        public void EnviarEmailParaFila(Usuario usuario)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    UserName = "admin",
                    Password = "admin"
                };

                using (var conexao = factory.CreateConnection())
                using (var canal = conexao.CreateModel())
                {
                    canal.QueueDeclare(queue: nomeFilaEnviarEmail,
                                       durable: false,
                                       exclusive: false,
                                       autoDelete: false,
                                       arguments: null);

                    var mensagem = Encoding.UTF8
                        .GetBytes(JsonConvert.SerializeObject(
                         new EmailUsuarioCriado
                         {
                             ParaEmail = usuario.Email,
                             Conteudo = ("Olá, seu usuário foi criado com sucesso, sua senha de acesso é: " + usuario.Senha),
                             DataCriacao = usuario.DataDeInclusao,
                         }));

                    canal.BasicPublish(exchange: "",
                                       routingKey: nomeFilaEnviarEmail,
                                       basicProperties: null,
                                       body: mensagem);
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException); ;
            }
        }
    }
}
