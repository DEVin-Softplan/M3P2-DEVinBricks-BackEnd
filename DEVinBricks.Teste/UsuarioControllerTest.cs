using DEVinBricks.Controllers;
using DEVinBricks.DTO;
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

            Assert.That(expected.Value.ToString(), Is.EqualTo(CompradorSeed.Seed.First().ToString()));
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

        [Test]
        public async Task EditarDadosComIdInexistente()
        {

            var context = new DEVinBricksContext(_contextOptions);
            var repository = new UsuarioRepository(context);
            var service = new UsuarioService(repository);

            var controller = new UsuarioController(repository, service);

            var usuario = new EditarUsuarioDTO()
            {
                Id = 4
            };

            var response = await controller.EditarDados(usuario);

            var expected = (response as ObjectResult);

            Assert.That(expected.Value.ToString(), Is.EqualTo("Usuario não encontrado"));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("404"));
        }

        [Test]
        public async Task EditarDados()
        {
            var context = new DEVinBricksContext(_contextOptions);
            var repository = new UsuarioRepository(context);
            var service = new UsuarioService(repository);

            var usuario = new Usuario()
            {
                Id = 3,
                Nome = "Teste1",
                Email = "Teste1@gmail.com",
                Senha = "teste123",
                Login = "Teste1",
                Admin = false,
                Ativo = true,
                DataDeInclusao = DateTime.Now,
                UsuarioInclusaoId = 1,
                DataDeAlteracao = DateTime.Now,
                UsuarioAlteracaoId = 1
            };

            await context.Usuarios.AddAsync(usuario);

            await context.SaveChangesAsync();

            var usuarioEditar = new EditarUsuarioDTO()
            {
                Id = 3,
                Nome = "Alterado",
                Email = "Alterado@gmail.com",
                Login = "Alterado",
                Admin = true,
                Ativo = false
            };

            var usuarioAlterado = await service.VerificarDadosAlterados(usuarioEditar);

            await service.AlterarDadosUsuario(usuarioAlterado,1);

            Usuario usuarioDepoisDaAlteracao = await context.Usuarios.FindAsync(usuario.Id);

            Assert.That(usuarioDepoisDaAlteracao.Nome, Is.EqualTo(usuarioEditar.Nome));
            Assert.That(usuarioDepoisDaAlteracao.Email, Is.EqualTo(usuarioEditar.Email));
            Assert.That(usuarioDepoisDaAlteracao.Login, Is.EqualTo(usuarioEditar.Login));
            Assert.That(usuarioDepoisDaAlteracao.Admin, Is.EqualTo(usuarioEditar.Admin));
            Assert.That(usuarioDepoisDaAlteracao.Ativo, Is.EqualTo(usuarioEditar.Ativo));
            Assert.That(usuarioDepoisDaAlteracao.UsuarioAlteracao, Is.Not.Null);
            Assert.That(usuarioDepoisDaAlteracao.UsuarioAlteracaoId, Is.Not.Null);
            Assert.That(usuarioDepoisDaAlteracao.DataDeAlteracao, Is.Not.Null);
        }

        [Test]
        public async Task EditarDadosComEmailExistente()
        {

            var context = new DEVinBricksContext(_contextOptions);
            var repository = new UsuarioRepository(context);
            var service = new UsuarioService(repository);

            var controller = new UsuarioController(repository, service);

            var usuario = new Usuario()
            {
                Id = 5,
                Nome = "Teste2",
                Email = "Teste2@gmail.com",
                Senha = "teste123",
                Login = "Teste2",
                Admin = false,
                Ativo = true,
                DataDeInclusao = DateTime.Now,
                UsuarioInclusaoId = 1,
                DataDeAlteracao = DateTime.Now,
                UsuarioAlteracaoId = 1
            };

            await context.Usuarios.AddAsync(usuario);

            await context.SaveChangesAsync();


            var usuarioEditar = new EditarUsuarioDTO()
            {
                Id = 5,
                Email = "Teste2@gmail.com"
            };

            var response = await controller.EditarDados(usuarioEditar);

            var expected = (response as ObjectResult);

            Assert.That(expected.Value.ToString(), Is.EqualTo("O email informado já existe."));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }

        [Test]
        public async Task EditarDadosComLoginExistente()
        {

            var context = new DEVinBricksContext(_contextOptions);
            var repository = new UsuarioRepository(context);
            var service = new UsuarioService(repository);

            var controller = new UsuarioController(repository, service);

            var usuario = new Usuario()
            {
                Id = 6,
                Nome = "Teste3",
                Email = "Teste3@gmail.com",
                Senha = "teste123",
                Login = "Teste3",
                Admin = false,
                Ativo = true,
                DataDeInclusao = DateTime.Now,
                UsuarioInclusaoId = 1,
                DataDeAlteracao = DateTime.Now,
                UsuarioAlteracaoId = 1
            };

            await context.Usuarios.AddAsync(usuario);

            await context.SaveChangesAsync();


            var usuarioEditar = new EditarUsuarioDTO()
            {
                Id = 6,
                Login = "Teste3"
            };

            var response = await controller.EditarDados(usuarioEditar);

            var expected = (response as ObjectResult);

            Assert.That(expected.Value.ToString(), Is.EqualTo("O login informado já existe."));
            Assert.That(expected.StatusCode.ToString(), Is.EqualTo("400"));
        }
    }
}

