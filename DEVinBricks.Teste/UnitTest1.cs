using DEVinBricks.Controllers;
using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NUnit.Framework;



namespace DEVinBricks.Teste
{
    public class Tests
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

        [Test]
        public void EditaValorFretePorEstadoIdNaoEcontrado()
        {
            var service = new ValorFretePorEstadoService(new ValorFretePorEstadoRepository(new DEVinBricksContext(_contextOptions)));

            var controller = new FretePorEstadoController(service);
            var dto = new ValorFretePorEstadoDTO
            {
                Id = 1,
                Valor = 100
            };
            var response =  controller.Editar(dto, 1) as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;

            Assert.AreEqual(response.Value,"Dados inconsistentes");
        }
    }
}