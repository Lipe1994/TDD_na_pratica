using System;
using System.Linq;
using Xunit;

namespace Vendas.Domain.Tests
{
    public class PedidoTests
    {
        [Fact(DisplayName = "Adicionar item ao pedido vazio")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_NovoPedido_DeveAtualizarValor()
        {
            //arrange
            var pedido = new Pedido();
            var pedidoItem = new PedidoItem(Guid.NewGuid(), "Produto teste", 2, 150);

            //act
            pedido.AdicionarItem(pedidoItem);

            //assert
            Assert.Equal(300, pedido.ValorTotal);

        }

        [Fact(DisplayName = "Adicionar Item existente")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_ItemExistente_DeveIncrementarItem()
        {
            //arrange
            var produtoId = Guid.NewGuid();
            var pedido = new Pedido();

            var pedidoItem = new PedidoItem(produtoId, "Produto teste", 2, 150);
            pedido.AdicionarItem(pedidoItem);

            var pedidoItem2 = new PedidoItem(produtoId, "Produto teste 2", 2, 150);

            //act
            pedido.AdicionarItem(pedidoItem2);


            //assert
            Assert.Equal(600, pedido.ValorTotal);
            Assert.Equal(1, pedido.PedidoItems.Count);
            Assert.Equal(600, pedido.PedidoItems.First().ValorUnitario * pedido.PedidoItems.First().Quantidade);
        }
    }
}
