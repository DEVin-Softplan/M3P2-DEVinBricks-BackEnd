using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using Microsoft.EntityFrameworkCore;

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
                
        public IEnumerable<VendaProdutoGetDTO> ConsultarVendaProdutoPorIdVenda(int idVenda)
        {
            //var vendaProtudo = _context.VendasProdutos
                //.Include(p => p.Produto) as IQueryable<VendaProdutoModel>;
                //.FirstOrDefault(x => x.IdVenda == idVenda);            
            //return VendaProdutoGetDTO.ConverterParaVendaProdutoGetDTO(vendaProtudo);

            var collection = _context.VendasProdutos
                .Include(p => p.Produto) as IQueryable<VendaProdutoModel>;

            var resultado = collection.OrderBy(p => p.Produto.Id)
                                        //.Skip(size * (page - 1))
                                        //.Take(size)
                                        .ToList();
            var retorno = new List<VendaProdutoGetDTO>();
            foreach (var item in resultado)
            {
                retorno.Add(VendaProdutoGetDTO.ConverterParaVendaProdutoGetDTO(item));
            }
            return retorno;
        }

        public IEnumerable<VendaPostDTO> ConsultarVendaPorComprador(string? nome, string? cpf, int page, int size)
        {
            var collection = _context.Vendas
                   .Include(c => c.Comprador)
                   .Include(v => v.Vendedor) as IQueryable<VendaModel>;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                nome = nome.Trim();
                collection = collection.Where(c => c.Comprador.Nome.Contains(nome));
            }

            if (!string.IsNullOrWhiteSpace(cpf))
            {
                cpf = cpf.Trim();
                collection = collection.Where(c => c.Comprador.CPF.Equals(cpf));
            }

            var total = collection.Count();

            var resultado = collection.OrderBy(c => c.Comprador.Nome)
                                        .Skip(size * (page - 1))
                                        .Take(size)
                                        .ToList();
            var retorno = new List<VendaPostDTO>();
            foreach (var item in resultado)
            {
                retorno.Add(VendaPostDTO.ConverterParaVendaPostDTO(item));
            }
            return retorno;
        }

        public VendaModel ObterPeloId(int id)
        {
            return _context.Vendas.FirstOrDefault(x => x.Id == id);
        }

        public VendaProdutoModel ObterVendaProdutoPorIdVenda(int idVenda)
        {
            return _context.VendasProdutos.FirstOrDefault(x => x.Id == idVenda);
        }
    }
}