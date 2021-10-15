using DevIO.Bussines.Models.Fornecedores;
using DevIO.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataContext context): base(context)
        {

        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid id)
        {
            return await ObterPorId(id);
        }
    }
}
