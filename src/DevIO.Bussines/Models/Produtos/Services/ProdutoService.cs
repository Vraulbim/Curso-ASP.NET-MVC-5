using DevIO.Bussines.Core.Notificacoes;
using DevIO.Bussines.Core.Services;
using DevIO.Bussines.Models.Produtos.Validations;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussines.Models.Produtos.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecValidacao(new ProdutoValidation(), produto)) return;

            await _repository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecValidacao(new ProdutoValidation(), produto)) return;

            await _repository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            await _repository.Remover(id);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
