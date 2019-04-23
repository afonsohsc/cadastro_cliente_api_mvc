using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiCliente.Models
{
	public class ClienteContext : DbContext
	{
		public ClienteContext() : base("ClienteCadastro")
		{
		}
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Telefone> Telefones { get; set; }

	}
}