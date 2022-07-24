﻿using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public class CompradorRepository : ICompradorRepository
    {
        private DEVinBricksContext _context;
        public CompradorRepository(DEVinBricksContext context)
        {
            _context = context;
        }
        public async Task<int> CadastrarComprador(CompradorPostDTO comprador)
        {
            var newComprador = CompradorPostDTO.ConverterParaEntidade(comprador);
            var resultado = await _context.Compradores.AddAsync(newComprador);
            await _context.SaveChangesAsync();
            return resultado.Entity.Id;
        }
        public IEnumerable<Comprador> ListarComprador(CompradorGetDTO comprador)
        {
            var queryableComprador = _context.Compradores as IQueryable<Comprador>;
            var resultado = queryableComprador.OrderBy(c => c.Nome).ToList();
            return resultado;
        }
        public bool VerificaSeExisteCPFComprador(string cpf)
        {
            return _context.Compradores.Any(x => x.CPF == cpf);
        }
        public bool VerificaSeExisteEmailComprador(string email)
        {
            return _context.Compradores.Any(x => x.Email == email);
        }
    }
}
