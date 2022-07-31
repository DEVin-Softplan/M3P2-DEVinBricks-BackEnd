using DEVinBricks.Controllers;
using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Seeds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NUnit.Framework;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DEVinBricks.Teste
{
    internal class CompradorControllerTest
    {
        private DbContextOptions<DEVinBricksContext> _contextOptions;

        [SetUp]
        public void Setup()
        {
            _contextOptions = new DbContextOptionsBuilder<DEVinBricksContext>()
                             .UseInMemoryDatabase("CompradorTeste")
                             .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                             .Options;

            using var context = new DEVinBricksContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        public CompradorController retornaCompradorController()
        {
            var context = new DEVinBricksContext(_contextOptions);
            var repository = new CompradorRepository(context);
            var controller = new CompradorController(repository);
            var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Email, "admin@gmail.com"),
                    new Claim("is_admin","True"),
                };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "mock"));
            var controllercontext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = user
                }
            };
            controller.ControllerContext = controllercontext;
            return controller;
        }

        [Test]
        public async Task GetCompradorPeloIdExistente()
        {

            var controller = retornaCompradorController();

            var result = await controller.ObterCompradorPeloId(1);

            var expected = result.Result as ObjectResult;

            Assert.That(expected.Value.ToString(), Is.EqualTo(CompradorSeed.Seed.First().ToString()));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("200"));

        }
        [Test]
        public async Task GetCompradorPeloIdInexistente()
        {

            var controller = retornaCompradorController();

            var result = await controller.ObterCompradorPeloId(-1);

            var expected = result.Result as ObjectResult;

            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("404"));
        }

        [Test]
        public async Task PatchDadosComIdInexistente()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPatchDTO()
            {
                Email = "AlteraComprador@gmail.com",
                Telefone = ""
            };

            var response = controller.EditarComprador(dto, -1);

            var expected = response as ObjectResult;

            Assert.That(expected.Value.ToString(), Is.EqualTo("Id não encontrado"));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("404"));
        }

        [Test]
        public async Task PatchDadosComEmailExistente()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPatchDTO()
            {
                Email = "comprador1@comprador.com.br",
                Telefone = ""
            };

            var response = controller.EditarComprador(dto, 1);

            var expected = response as ObjectResult;

            Assert.That(expected.Value.ToString(), Is.EqualTo($"O Email '{dto.Email}' já existe."));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }
        [Test]
        public async Task PatchDadosComFormatoEmailErrado()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPatchDTO()
            {
                Email = "erradogmail.com",
                Telefone = ""
            };

            var response = controller.EditarComprador(dto, 1);

            var expected = response as ObjectResult;

            Assert.That(expected.Value.ToString(), Is.EqualTo($"O E-mail '{dto.Email}' não é valido. Exemplo: exemplopatch@email.com.br"));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }
        [Test]
        public async Task PatchDadosComIdExistente()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPatchDTO()
            {
                Email = "outroemail@gmail.com",
                Telefone = "(98) 7654-3210"
            };

            var response = controller.EditarComprador(dto, 1);

            var expected = response as ObjectResult;

            Assert.IsNull(expected);
        }
        [Test]
        public async Task PostNovoCompradorCPFErrado()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPostDTO()
            {
                Nome = "Novo Comprador",
                Email = "novo.comprador@comprador.com.br",
                Telefone = "(55) 4321-5678",
                DataDeNascimento = "05/05/2005",
                CPF = "432.156.555-99"
            };

            var dtoCpf = dto.CPF;

            var response = await controller.CriarComprador(dto);

            var expected = response as ObjectResult;

            Assert.That(expected.Value.ToString(), Is.EqualTo($"O CPF '{dtoCpf}' não é válido."));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }
        [Test]
        public async Task PostNovoCompradorEmailErrado()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPostDTO()
            {
                Nome = "Novo Comprador",
                Email = "emailerrado.com.br",
                Telefone = "(55) 4321-5678",
                DataDeNascimento = "05/05/2005",
                CPF = "324.609.560-45"
            };

            var response = await controller.CriarComprador(dto);

            var expected = response as ObjectResult;

            Assert.That(expected.Value.ToString(), Is.EqualTo($"O E-mail '{dto.Email}' não é valido. Exemplo: exemplopost@email.com.br"));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }
        [Test]
        public async Task PostNovoCompradorDataNascimentoErrada()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPostDTO()
            {
                Nome = "Novo Comprador",
                Email = "novo.comprador@comprador.com.br",
                Telefone = "(55) 4321-5678",
                DataDeNascimento = "05/05/05",
                CPF = "324.609.560-45"
            };

            var response = await controller.CriarComprador(dto);

            var expected = response as ObjectResult;

            Assert.That(expected.Value.ToString(), Is.EqualTo($"A Data de Nascimento '{dto.DataDeNascimento}' não está no formato adequado (dd/MM/yyyy). Exemplo: 01/01/2000"));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }
        [Test]
        public async Task PostNovoCompradorEmailExistente()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPostDTO()
            {
                Nome = "Novo Comprador",
                Email = "comprador1@comprador.com.br",
                Telefone = "(55) 4321-5678",
                DataDeNascimento = "05/05/2005",
                CPF = "324.609.560-45"
            };

            var response = await controller.CriarComprador(dto);

            var expected = response as ObjectResult;

            Assert.That(expected.Value.ToString(), Is.EqualTo($"O E-mail '{dto.Email}' já está cadastrado."));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }
        [Test]
        public async Task PostNovoCompradorCPFExistente()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPostDTO()
            {
                Nome = "Novo Comprador",
                Email = "novo.comprador@comprador.com.br",
                Telefone = "(55) 4321-5678",
                DataDeNascimento = "05/05/2005",
                CPF = "346.020.220-30"
            };

            var dtoCpf = dto.CPF;

            var response = await controller.CriarComprador(dto);

            var expected = response as ObjectResult;

            Assert.That(expected.Value.ToString(), Is.EqualTo($"O CPF '{dtoCpf}' já está cadastrado."));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }
        [Test]
        public async Task PostNovoComprador()
        {

            var controller = retornaCompradorController();

            var dto = new CompradorPostDTO()
            {
                Nome = "Novo Comprador",
                Email = "novo.comprador@comprador.com.br",
                Telefone = "(55) 4321-5678",
                DataDeNascimento = "05/05/2005",
                CPF = "324.609.560-45"
            };

            var dtoCpf = dto.CPF;

            var response = await controller.CriarComprador(dto);

            var expected = response as ObjectResult;

            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("201"));
        }
    }
}
