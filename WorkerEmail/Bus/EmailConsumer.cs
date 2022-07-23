using DEVinBricks.Repositories.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net;
using System.Net.Mail;
using System.Text;
using WorkerEmail.Options;

namespace WorkerEmail.Bus
{
    public class EmailConsumer : BackgroundService
    {
        private readonly CredenciaisConfig _config;
        private readonly IConnection _conexao;
        private readonly IModel _canal;
        private const string nomeFilaEnviarEmail = "EmailUsuarioCriado";
        public EmailConsumer(IOptions<CredenciaisConfig> option)
        {
            _config = option.Value;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "admin"
            };

            _conexao = factory.CreateConnection();
            _canal = _conexao.CreateModel();
            _canal.QueueDeclare(queue: nomeFilaEnviarEmail,
                                       durable: false,
                                       exclusive: false,
                                       autoDelete: false,
                                       arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_canal);

            consumer.Received += (sender, eventArgs) =>
            {
                var conteudo = eventArgs.Body.ToArray();
                var mensagem = JsonConvert.DeserializeObject<EmailUsuarioCriado>(Encoding.UTF8.GetString(conteudo));

                EnviarEmailParaUsuario(mensagem);
            };

            _canal.BasicConsume(queue: nomeFilaEnviarEmail,
                                autoAck: true,
                                consumer: consumer);

            return Task.CompletedTask;
        }

        public void EnviarEmailParaUsuario(EmailUsuarioCriado emailUsuarioCriado)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_config.DeEmail);
                mail.To.Add(emailUsuarioCriado.ParaEmail);
                mail.Subject = _config.AssuntoEmail;
                mail.Body = emailUsuarioCriado.Conteudo;


                using (var smtp = new SmtpClient(_config.Client))
                {
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;

                    smtp.Credentials = new NetworkCredential(_config.CredencialEmail, _config.CredencialSenha);
                    smtp.Send(mail);
                }
            }
        }
    }
}
