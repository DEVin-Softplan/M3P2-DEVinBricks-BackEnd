using DEVinBricks.Controllers;
using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Seeds;
using DEVinBricks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBricks.Teste
{
    internal class ProdutoControllerTest
    {
        private DbContextOptions<DEVinBricksContext> _contextOptions;
        [SetUp]
        public void Setup()
        {
            _contextOptions = new DbContextOptionsBuilder<DEVinBricksContext>()
            .UseInMemoryDatabase("ProdutoTeste")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            using var context = new DEVinBricksContext(_contextOptions);

            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
        }

        public ProdutoController retornaProdutoController()
        {
            var context = new DEVinBricksContext(_contextOptions);
            var repository = new CadastroDeProdutoRepository(context);
            var controller = new ProdutoController(repository, null);
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
        public async Task GetProdutoPeloIdInexistente()
        {
            var controller = retornaProdutoController();

            var result = controller.ObterProduto(-1);

            var expected = (result as ObjectResult);

            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("404"));
        }
    }
}