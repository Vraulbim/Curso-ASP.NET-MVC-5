using DevIO.Bussines.Core.Data;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussines.Models.Fornecedores
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {

        Task<Fornecedor> ObterFornecedorEEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEEndereco(Guid id);
    }
}
