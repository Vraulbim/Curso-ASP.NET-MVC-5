using DevIO.Bussines.Core.Models;
using DevIO.Bussines.Models.Produtos;
using System.Collections.Generic;

namespace DevIO.Bussines.Models.Fornecedores
{
    public class Fornecedor : Entity
    {

        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }


        public ICollection<Produto> Produtos { get; set; }
    }

    public enum TipoFornecedor
    {
        PessoaFisica = 1,
        PessoaJuridica
    }
}
