using DevIO.Bussines.Core.Notificacoes;
using DevIO.Bussines.Core.Services;
using DevIO.Bussines.Models.Fornecedores.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Bussines.Models.Fornecedores.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        private readonly IEnderecoRepository _repositoryEndereco;

        public FornecedorService(IFornecedorRepository repository, IEnderecoRepository repositoryEndereco, INotificador notificador) : base(notificador)
        {
            _repository = repository;
            _repositoryEndereco = repositoryEndereco;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecValidacao(new FornecedorValidation(), fornecedor)
                || !ExecValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            if (await FornecedorExistente(fornecedor)) return;

            await _repository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecValidacao(new FornecedorValidation(), fornecedor)) return;

            if (await FornecedorExistente(fornecedor)) return;

            await _repository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _repository.ObterFornecedorProdutosEEndereco(id);

            if (fornecedor.Produtos.Any()) {

                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            if(fornecedor.Endereco != null)
            {
                await _repositoryEndereco.Remover(fornecedor.Endereco.Id);
            }

            await _repository.Remover(id);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecValidacao(new EnderecoValidation(), endereco)) return;

            await _repositoryEndereco.Atualizar(endereco);
        }

        private async Task<bool> FornecedorExistente(Fornecedor fornecedor)
        {
            var fornecedorAtual = await _repository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id);

            if (!fornecedorAtual.Any()) return false;

            Notificar("Já existe um fornecedor com este documento infomado.");
            return true;
        }


        public void Dispose()
        {
            _repository?.Dispose();
            _repositoryEndereco?.Dispose();
        }
    }
}
