using DevIO.Bussines.Core.Data;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussines.Models.Fornecedores
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid id);
    }
}
