using System.Collections.Generic;
namespace QuickBuy.Dominio.Entidades
{
	public class Usuario : Entidade
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public string Nome { get; set; }
		public string SobreNome { get; set; }
		
		public virtual ICollection<Pedido> Pedidos { get; set; }

		public override void Validate()
		{
			LimparMensagensValidacao();

			if (string.IsNullOrEmpty(Email))
			{
				AdicionarCritica("Email não preenchido");
			}
			
			if (string.IsNullOrEmpty(Senha))
			{
				AdicionarCritica("Senha não preenchida");
			}
		}
	}

	
}
