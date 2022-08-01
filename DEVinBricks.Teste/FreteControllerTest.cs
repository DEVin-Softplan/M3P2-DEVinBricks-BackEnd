using DEVinBricks.Controllers;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Seeds;
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
    internal class FreteControllerTest
    {
        private DbContextOptions<DEVinBricksContext> _contextOptions;
        [SetUp]
        public void Setup()
        {
            _contextOptions = new DbContextOptionsBuilder<DEVinBricksContext>()
           .UseInMemoryDatabase("FreteTest")
           .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
           .Options;

            using var context = new DEVinBricksContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public void GetFreteByIdNotNull()
        {
            var repository = new FreteRepository(new DEVinBricksContext(_contextOptions));

            var controller = new FreteController(repository);

            var response = repository.ObterFretePorId(1);

            Assert.IsNotNull(response);
        }

        [Test]
        public void GetFreteById()
        {
            var repository = new FreteRepository(new DEVinBricksContext(_contextOptions));

            var controller = new FreteController(repository);

            var response = repository.ObterFretePorId(1);

            Assert.That(response.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task GetFreteByIdExistente()
        {
            var context = new DEVinBricksContext(_contextOptions);

            var controller = new FreteController(new FreteRepository(context));

            var result = await controller.ObterFretePorId(1);

            var expected = (result.Result as ObjectResult);

            Assert.That(expected.Value.ToString(), Is.EqualTo(FreteSeed.Seed.First().ToString()));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("200"));
        }

        [Test]
        public async Task GetFreteByIdInexistente()
        {
            var context = new DEVinBricksContext(_contextOptions);

            var controller = new FreteController(new FreteRepository(context));

            var result = await controller.ObterFretePorId(99);

            var expected = (result.Result as ObjectResult);

            Assert.That(expected.Value.ToString(), Is.EqualTo("Frete não encontrado no sistema."));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("404"));
        }
    }
}
