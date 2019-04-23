using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroCliente.Models
{
	public class Cliente
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O nome deve ser preenchido.")]
		public string Nome { get; set; }

		[DisplayName("CPF")]
		[Required(ErrorMessage = "O CPF deve ser preenchido.")]
		public string Cpf { get; set; }

		[DisplayName("Data de Nascimento")]
		[Required(ErrorMessage = "A data de nascimento deve ser preenchido.")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DataNascimento { get; set; }

		public string Genero { get; set; }

		public virtual List<Telefone> Telefones { get; set; }

	}
}