using DevIO.Bussines.Models.Fornecedores;
using DevIO.Infra.Data.Context;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DataContext context) : base(context)
        {

        }

        public async Task<Fornecedor> ObterFornecedorEEndereco(Guid id)
        {
            return await context.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEEndereco(Guid id)
        {
            return await context.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public override async Task Remover(Guid id)
        {
            var fornecedor = await ObterPorId(id);
            fornecedor.Ativo = false;

            await Atualizar(fornecedor);
        }
    }
}
