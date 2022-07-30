 using DEVinBricks.Controllers;
using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NUnit.Framework;
using System.Security.Claims;
using System.Collections.Generic;

namespace DEVinBricks.Teste
{
    public class FretePorEstadoControllerTest
    {

        private DbContextOptions<DEVinBricksContext> _contextOptions;
        [SetUp]
        public void Setup()
        {
            _contextOptions = new DbContextOptionsBuilder<DEVinBricksContext>()
           .UseInMemoryDatabase("meuTesteUnitario")
           .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
           .Options;

            using var context = new DEVinBricksContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        /// <summary>
        /// Teste que valida adição e validação de não adicionar quando já há cadastro do estado
        /// </summary>
        [Test]
        public void AdicionarValorFretePorEstado()
        {
            var controller = retornaController();
            var dto = new ValorFretePorEstadoPostDTO()
            {
                Valor = 100,
                EstadoId = 1
            };
            var response = controller.Adicionar(dto) as CreatedResult;
            Assert.AreEqual(response.StatusCode, 201);

            dto.Valor = 200;

            var responseCriacaoExistente = controller.Adicionar(dto) as BadRequestObjectResult;

            Assert.AreEqual(responseCriacaoExistente.StatusCode, 400);
        }

        [Test]
        public void EditaValorFretePorEstadoIdNaoEcontrado()
        {
            var controller = retornaController();
            var dto = new ValorFretePorEstadoDTO
            {
                Id = 1656546,
                Valor = 100
            };
            var response =  controller.Editar(dto, 1656546) as Microsoft.AspNetCore.Mvc.NotFoundObjectResult;

            Assert.AreEqual(response.Value, "Id não encontrado");
        }

        [Test]
        public void EditaValorFretePorEstadoIdConflitanteBadRequest()
        {


            var controller = retornaController();
            var dto = new ValorFretePorEstadoDTO
            {
                Id = 2,
                Valor = 100
            };
            var response = controller.Editar(dto, 1) as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;

            Assert.AreEqual(response.Value, "Dados inconsistentes");
        }

        [Test]
        public void ConsultaValorFretePorEstado()
        {
            var controller = retornaController();

            var response = controller.Consultar("Santa") as OkObjectResult;
            
            Assert.AreEqual(response.StatusCode, 200);
            var responseEntity = response.Value as List<ValorFretePorEstadoModel>;
            Assert.IsNotNull(responseEntity);
            Assert.AreEqual(responseEntity[0].Id, 1);
        }

        public void EditaValorFretePorEstadoSucesso()
        {


            var controller = retornaController();
            var dto = new ValorFretePorEstadoDTO
            {
                Id = 1,
                Valor = 200
            };
            var response = (controller.Editar(dto, 1) as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as ValorFretePorEstadoModel;

            Assert.AreEqual(response.Valor, 200);
        }


        public FretePorEstadoController retornaController()
        {
            var context = new DEVinBricksContext(_contextOptions);
            var repository = new ValorFretePorEstadoRepository(context);
            var service = new ValorFretePorEstadoService(repository);
            var controller = new FretePorEstadoController(service);
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
    }
}