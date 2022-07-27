using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinBricks.Repositories
{
    public class CompradorRepository : ICompradorRepository
    {
        private DEVinBricksContext _compradorContext;
        public CompradorRepository(DEVinBricksContext compradorContext)
        {
            _compradorContext = compradorContext;
        }

        public async Task<int> CadastrarComprador(CompradorPostDTO comprador, int authUserId)
        {
            var newComprador = CompradorPostDTO.ConverterParaEntidadeComprador(comprador, authUserId);
            var resultado = await _compradorContext.Compradores.AddAsync(newComprador);
            await _compradorContext.SaveChangesAsync();
            return resultado.Entity.Id;
        }

        public IEnumerable<Comprador> ListarGetComprador(CompradorGetDTO comprador)
        {
            var queryableComprador = _compradorContext.Compradores.Include(ui => ui.UsuarioInclusao).Include(ua => ua.UsuarioAlteracao) as IQueryable<Comprador>;
            if (!string.IsNullOrWhiteSpace(comprador.Nome))
                queryableComprador = queryableComprador.Where(c => c.Nome.Contains(comprador.Nome));
            if (!string.IsNullOrWhiteSpace(comprador.CPF))
                queryableComprador = queryableComprador.Where(c => c.CPF.Contains(comprador.CPF));
            if (comprador.Pagina > 0)
                queryableComprador = queryableComprador
                                    .Skip((comprador.Pagina - 1) * comprador.TamanhoPagina)
                                    .Take(comprador.TamanhoPagina);
            var resultado = queryableComprador.OrderBy(c => c.Nome).ToList();
            return resultado;
        }

        public Comprador EditarComprador(CompradorPatchDTO dto, int id)
        {
            var model = ObterPeloId(id);
            if (VerificaSeTemConteudo(dto.Email)) model.Email = dto.Email;
            if (VerificaSeTemConteudo(dto.Telefone)) model.Telefone = dto.Telefone;
            _compradorContext.Update(model);
            _compradorContext.SaveChanges();

            return model;
        }

        public bool VerificaSeExisteCPFComprador(string cpf)
        {
            return _compradorContext.Compradores.Any(x => x.CPF == cpf);
        }

        public bool VerificaSeExisteEmailComprador(string email)
        {
            return _compradorContext.Compradores.Any(x => x.Email == email);
        }

        public Comprador ObterPeloId(int id)
        {
            return _compradorContext.Compradores.FirstOrDefault(x => x.Id == id);
        }

        public bool VerificaSeTemConteudo(string texto)
        {
            if (texto == null || texto == "" || texto == " " || texto == "string") return false;
            return true;
        }
    }
}
