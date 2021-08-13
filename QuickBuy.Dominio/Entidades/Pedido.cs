using System;
using System.Linq;
using System.Collections.Generic;
using QuickBuy.Dominio.ObjetoDeValor;

namespace QuickBuy.Dominio.Entidades
{
	public class Pedido : Entidade
	{
		public int Id { get; set; }
		public DateTime DataPedido { get; set; }
		public int UsuarioId { get; set; }
		public virtual Usuario Usuario { get; set; }
		public DateTime DataPrevisaoEntrega { get; set; }
		public string CEP { get; set; }
		public string Estado { get; set; }
		public string Cidade { get; set; }
		public string EnderecoCompleto { get; set; }
		public int NumEndereco { get; set; }

		public int FormaPagamentoId { get; set; }
		public virtual FormaPagamento FormaPagamento { get; set; }

		// Pedido deve ter pelo menos um item de pedido
		// ou muitos itens de pedidos.
		public virtual ICollection<ItemPedido> ItensPedido { get; set; }

		public override void Validate() 
		{
			LimparMensagensValidacao();
			if ( !ItensPedido.Any() )
			{
				AdicionarCritica("Crítica - Pedido não pode ficar sem item de pedido");
			}
			if ( string.IsNullOrEmpty(CEP) )
			{
				AdicionarCritica("Crítica - CEP deve estar preenchido");
			}
			if (FormaPagamentoId == 0)
				AdicionarCritica("Crítica - Não foi informado a forma de pagamento");
		}
	}
}
