using System;

namespace Vendas.Domain
{
    public class PedidoItem
    {
        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario) 
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        internal void SomarItem(int quantidade) 
        {
            Quantidade += quantidade;
        }
    }
}
