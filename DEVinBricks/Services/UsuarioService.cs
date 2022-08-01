using DEVinBricks.Repositories.Models;
using DEVinBricks.Repositories;
using DEVinBricks.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using DEVinBricks.DTO;

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

        public async Task<Usuario> CriarUsuario(CadastrarUsuarioDTO usuario, int idInclusao)
        {
            string senha = GerarSenha();
            var usuarioInclusao = _usuarioRepository.ObterUsuarioPorId(idInclusao);

            var novoUsuario = new Usuario()
            {
                Nome = usuario.Nome,
                Senha = senha,
                Email = usuario.Email,
                Login = usuario.Login,
                Admin = usuario.Admin,
                Ativo = true,
                UsuarioInclusaoId = idInclusao,
                UsuarioInclusao = usuarioInclusao,
                DataDeInclusao = DateTime.Now,
            };

            return novoUsuario;
        }

        public string GerarSenha()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz023456789";
            string pass = "";
            Random random = new Random();
            for (int f = 0; f < 6; f++)
            {
                pass = pass + chars.Substring(random.Next(0, chars.Length - 1), 1);
            }
            return pass;
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
