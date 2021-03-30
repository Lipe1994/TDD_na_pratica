using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Vendas.Domain
{
    public class Pedido
    {
        public Pedido()
        {
            _pedidoItems = new List<PedidoItem>();
        }

        public decimal ValorTotal { get; private set; }

        private List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => PedidoItems;
        

        public void AdicionarItem(PedidoItem pedidoItem) 
        {
            if (_pedidoItems.Any(x => x.ProdutoId == pedidoItem.ProdutoId)) 
            {
                var itemExistente = _pedidoItems.FirstOrDefault(x => x.ProdutoId == pedidoItem.ProdutoId);
                pedidoItem.SomarItem(pedidoItem.Quantidade);
                _pedidoItems.Remove(itemExistente);
            }

            _pedidoItems.Add(pedidoItem);
            ValorTotal = _pedidoItems.Sum(x => x.ValorUnitario * x.Quantidade);
        }
    }
}
