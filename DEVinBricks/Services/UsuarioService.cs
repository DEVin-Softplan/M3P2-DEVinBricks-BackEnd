using DEVinBricks.Repositories.Models;
using DEVinBricks.Repositories;
using DEVinBricks.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace DEVinBricks.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private const string nomeFilaEnviarEmail = "EmailUsuarioCriado";

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<int> CadastrarUsuario(Usuario usuario)
        {
            var usuarioId = await _usuarioRepository.CadastrarUsuario(usuario);
            EnviarEmailParaFila(usuario);
            return usuarioId;
        }

        public async Task<bool> VerificarSeEmailExiste(string email)
        {
            return await _usuarioRepository.VerificaSeEmailExiste(email);
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
