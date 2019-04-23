using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroCliente.Models
{
	public class Telefone
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O DDD deve ser preenchido.")]
		public string DDD { get; set; }

		[Required(ErrorMessage = "O número deve ser preenchido.")]
		public string Numero { get; set; }
	}
}