using DevIO.Bussines.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Bussines.Models.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {

        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid id);
        Task<IEnumerable<Produto>> ObterProdutosDeFornecedores();
        Task<Produto> ObterProdutoPorFornecedor(Guid id);
    }
}
