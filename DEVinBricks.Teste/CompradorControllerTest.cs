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

            //Assert.That(expected.Value.ToString(), Is.EqualTo(UsuarioSeed.Seed.First().ToString()));
            
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("404"));
        }
    }
}
