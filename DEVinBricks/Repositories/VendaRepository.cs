using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private DEVinBricksContext _context;
        public VendaRepository(DEVinBricksContext context)
        {
            _context = context;
        }

        public async Task<int> CadastrarVenda(VendaPostDTO venda, int usuarioInclusaoId)
        {
            var newVenda = VendaPostDTO.ConverterParaEntidadeVenda(venda);
            newVenda.UsuarioInclusaoId = usuarioInclusaoId;
            newVenda.DataDeInclusao = DateTime.Now;
            var resultado = await _context.Vendas.AddAsync(newVenda);
            await _context.SaveChangesAsync();
            return resultado.Entity.Id;
        }

        public IEnumerable<VendaModel> ListarGetVenda(VendaGetDTO venda)
        {
            var queryableVenda = _context.Vendas as IQueryable<VendaModel>;
            if (venda.Pagina > 0)
                queryableVenda = queryableVenda
                                    .Skip((venda.Pagina - 1) * venda.TamanhoPagina)
                                    .Take(venda.TamanhoPagina);
            var resultado = queryableVenda.OrderBy(c => c.Id).ToList();
            return resultado;
        }
        //public bool VerificaSeExisteComprador(int compradorId)
        //{
        //    return _context.Vendas.Any(x => x.CompradorId == compradorId);
        //}

        //public bool VerificaSeExisteCPFComprador(string cpf)
        //{
        //    return _context.Vendas.Any(x => x.CPF == cpf);
        //}

        public VendaModel ObterPeloId(int id)
        {
            return _context.Vendas.FirstOrDefault(x => x.Id == id);
        }

        //public Venda ObterVendaPorIdVenda(int IdVenda)
        //{
        //    var response = _context.Vendas.Find(IdVenda);
        //    return response;
        //}

        public VendaProdutoModel ObterVendaPorIdVenda(int IdVenda)
        {
            return _context.VendasProdutos.Find(IdVenda);
        }
    }
}