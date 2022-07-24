using DEVinBricks.Controllers;
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
    internal class UsuarioControllerTest
    {
        private DbContextOptions<DEVinBricksContext> _contextOptions;

        public UsuarioControllerTest()
        {
            _contextOptions = new DbContextOptionsBuilder<DEVinBricksContext>()
          .UseInMemoryDatabase("UsuarioTeste")
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
        public void listarUsuarios()
        {
            var service = new UsuarioService(new UsuarioRepository(new DEVinBricksContext(_contextOptions)));
            var repository = new UsuarioRepository(new DEVinBricksContext(_contextOptions));

            var controller = new UsuarioController(repository, service);

            var response = repository.listarUsuarios("sem nome", "sem login", 0, 1);

            Assert.IsNotNull(response);


        }
        [Test]
        public void listarUsuariosNome()
        {
            var service = new UsuarioService(new UsuarioRepository(new DEVinBricksContext(_contextOptions)));
            var repository = new UsuarioRepository(new DEVinBricksContext(_contextOptions));

            var controller = new UsuarioController(repository, service);

            var response = repository.listarUsuarios("Admin", "sem login", 0, 1);

            Assert.AreSame(response[0].Nome, "Admin");


        }

        [Test]
        public void listarUsuariosLogin()
        {
            var service = new UsuarioService(new UsuarioRepository(new DEVinBricksContext(_contextOptions)));
            var repository = new UsuarioRepository(new DEVinBricksContext(_contextOptions));

            var controller = new UsuarioController(repository, service);

            var response = repository.listarUsuarios("sem nome", "admin", 0, 1);

            Assert.AreSame(response[0].Login, "admin");


        }

        [Test]
        public async Task GetUsuarioPeloIdExistente()
        {

            var context = new DEVinBricksContext(_contextOptions);

            var service = new UsuarioService(new UsuarioRepository(new DEVinBricksContext(_contextOptions)));

            var controller = new UsuarioController(new UsuarioRepository(context), service);

            var result = await controller.ObterUsuarioPorId(1);

            var expected = (result.Result as ObjectResult);

            Assert.That(expected.Value.ToString(), Is.EqualTo(UsuarioSeed.Seed.First().ToString()));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("200"));
        }

        [Test]
        public async Task GetUsuarioPeloIdInexistente()
        {

            var context = new DEVinBricksContext(_contextOptions);

            var service = new UsuarioService(new UsuarioRepository(new DEVinBricksContext(_contextOptions)));

            var controller = new UsuarioController(new UsuarioRepository(context), service);

            var result = await controller.ObterUsuarioPorId(2);

            var expected = (result.Result as ObjectResult);

            Assert.That(expected.Value.ToString(), Is.EqualTo("Usuario não encontrado"));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("404"));
        }
    }
}

