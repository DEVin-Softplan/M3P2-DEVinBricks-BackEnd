using DEVinBricks.Controllers;
using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Seeds;
using DEVinBricks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBricks.Teste
{
    internal class CompradorControllerTest
    {
        private DbContextOptions<DEVinBricksContext> _contextOptions;

        public CompradorControllerTest()
        {
            _contextOptions = new DbContextOptionsBuilder<DEVinBricksContext>()
          .UseInMemoryDatabase("CompradorTeste")
          .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
          .Options;

            using var context = new DEVinBricksContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public async Task GetCompradorPeloIdExistente()
        {

            var context = new DEVinBricksContext(_contextOptions);

            var repository = new CompradorRepository(context);

            var controller = new CompradorController(repository);

            var result = await controller.ObterCompradorPeloId(1);

            var expected = (result.Result as ObjectResult);

            Assert.Pass();
            Assert.That(expected.Value.ToString(), Is.EqualTo(UsuarioSeed.Seed.First().ToString()));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("200"));

        }
        [Test]
        public async Task GetCompradorPeloIdInexistente()
        {

            var context = new DEVinBricksContext(_contextOptions);

            var repository = new CompradorRepository(context);

            var controller = new CompradorController(repository);

            var result = await controller.ObterCompradorPeloId(124321352);

            var expected = (result.Result as ObjectResult);

            //Assert.That(expected.Value.ToString(), Is.EqualTo(UsuarioSeed.Seed.First().ToString()));

            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("404"));
        }

        [Test]
        public async Task PatchDadosComIdInexistente()
        {

            var context = new DEVinBricksContext(_contextOptions);

            var repository = new CompradorRepository(context);

            var controller = new CompradorController(repository);

            var dto = new CompradorPatchDTO()
            {
                Email = "jaexiste@gmail.com",
                Telefone = ""
            };

            var response = controller.Editar(dto, 1231231);

            var expected = (response as ObjectResult);

            Assert.That(expected.Value.ToString(), Is.EqualTo("Id não encontrado"));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("404"));
        }

        [Test]
        public async Task PatchDadosComEmailExistente()
        {

            var context = new DEVinBricksContext(_contextOptions);

            var repository = new CompradorRepository(context);

            var controller = new CompradorController(repository);

            var dto = new CompradorPatchDTO()
            {
                Email = "jaexiste@gmail.com",
                Telefone = ""
            };

            var response = controller.Editar(dto, 1);

            var expected = (response as ObjectResult);

            Assert.Pass();
            Assert.That(expected.Value.ToString(), Is.EqualTo("O Email informado já existe."));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }
        [Test]
        public async Task PatchDadosComIdExistente()
        {

            var context = new DEVinBricksContext(_contextOptions);

            var repository = new CompradorRepository(context);

            var controller = new CompradorController(repository);

            var dto = new CompradorPatchDTO()
            {
                Email = "outroemail@gmail.com",
                Telefone = ""
            };

            var response = controller.Editar(dto, 1);

            var expected = (response as ObjectResult);

            Assert.Pass();
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("200"));
        }
    }
}
