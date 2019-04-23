using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiCliente.Models
{
	[Table("Clientes")]
	public class Cliente
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "O nome deve ser preenchido.")]
		[MaxLength(300, ErrorMessage = "O nome deve ter até 300 caracteres.")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O CPF deve ser preenchido.")]
		[MaxLength(15, ErrorMessage = "O CPF deve ter até 15 caracteres.")]
		public string CPF { get; set; }

		[Required(ErrorMessage = "A data de nascimento nome deve ser preenchido.")]
		public DateTime DataNascimento { get; set; }

		[Required(ErrorMessage = "O genero deve ser preenchido.")]
		[MaxLength(1, ErrorMessage = "O Genero deve ser preenchdio com M ou F.")]
		public string Genero { get; set; }

		[JsonIgnore]
		public virtual ICollection<Telefone> Telefones { get; set; }
	}
}