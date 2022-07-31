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
    internal class ProdutoControllerTest
    {
        private DbContextOptions<DEVinBricksContext> _contextOptions;

        public ProdutoControllerTest()
        {
            _contextOptions = new DbContextOptionsBuilder<DEVinBricksContext>()
            .UseInMemoryDatabase("ProdutoTeste")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            using var context = new DEVinBricksContext(_contextOptions);

            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
        }
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetProdutoPeloIdExistente()
        {
            var context = new DEVinBricksContext(_contextOptions);

            var repository = new CadastroDeProdutoRepository(context);

            var controller = new ProdutoController(repository);

            var result = controller.ObterProduto(1);

            var expected = (result as ObjectResult);

            Assert.Pass();
            Assert.That(expected.Value.ToString(), Is.EqualTo(UsuarioSeed.Seed.First().ToString()));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("200"));

        }
    }
}