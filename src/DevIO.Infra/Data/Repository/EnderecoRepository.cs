using DevIO.Bussines.Models.Fornecedores;
using System;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid id)
        {
            return await ObterPorId(id);
        }
    }
}
