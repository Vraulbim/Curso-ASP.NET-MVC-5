using DevIO.Bussines.Core.Models;
using DevIO.Bussines.Models.Fornecedores;
using System;

namespace DevIO.Bussines.Models.Produtos
{
    public class Produto : Entity
    {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }


        public Fornecedor Fornecedor { get; set; }
        public Guid FornecedorId { get; set; }
    }
}
