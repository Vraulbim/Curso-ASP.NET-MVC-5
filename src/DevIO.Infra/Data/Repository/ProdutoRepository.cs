using DevIO.Bussines.Models.Produtos;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DevIO.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public async Task<Produto> ObterProdutoPorFornecedor(Guid id)
        {
            return await context.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosDeFornecedores()
        {
            return await context.Produtos.AsNoTracking()
                .Include(p => p.Fornecedor).OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid id)
        {
            return await Buscar(p => p.FornecedorId == id);
        }
    }
}
