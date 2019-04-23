using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiCliente.Models
{
	[Table("Telefones")]
	public class Telefone
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "O DDD do telefone deve ser preenchido.")]
		[MaxLength(5, ErrorMessage = "O DDD deve ter até 5 caracteres.")]
		[MinLength(2, ErrorMessage = "O DDD deve ter no mínimo 2 caracteres.")]
		public string DDD { get; set; }

		[Required(ErrorMessage = "O número do telefone deve ser preenchido.")]
		[MaxLength(10, ErrorMessage = "O DDD deve ter até 10 caracteres.")]
		[MinLength(8, ErrorMessage = "O DDD deve ter no mínimo 2 caracteres.")]
		public string Numero { get; set; }

		[JsonIgnore]
		[ForeignKey(nameof(Cliente))]
		public int IdCliente { get; set; }

		[JsonIgnore]
		public virtual Cliente Cliente { get; set; }
	}
}