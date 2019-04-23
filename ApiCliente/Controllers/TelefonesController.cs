using ApiCliente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCliente.Controllers
{
    public class TelefonesController : ApiController
    {
		private ClienteContext db = new ClienteContext();

		public IHttpActionResult GetTelefones(int idCliente)
		{
			var cliente = db.Clientes.Find(idCliente);

			if (cliente == null)
				return NotFound();

			return Ok(cliente.Telefones.ToList());
		}

		public IHttpActionResult GetTelefone(int idCliente, int idTelefone)
		{
			var cliente = db.Clientes.Find(idCliente);

			if (cliente == null)
				return NotFound();

			var telefone = cliente.Telefones.FirstOrDefault(t => t.Id == idTelefone);

			if (telefone == null)
				return NotFound();

			return Ok(telefone);
		}

		public IHttpActionResult DeleteTelefone(int idCliente, int idTelefone)
		{
			var cliente = db.Clientes.Find(idCliente);

			if (cliente == null)
				return NotFound();

			var telefone = cliente.Telefones.FirstOrDefault(t => t.Id == idTelefone);

			if (telefone == null)
				return NotFound();

			db.Entry(telefone).State = EntityState.Deleted;

			db.SaveChanges();

			return StatusCode(HttpStatusCode.NoContent);
		}

		public IHttpActionResult PostTelefone(int idCliente, Telefone telefone)
		{
			var cliente = db.Clientes.Find(idCliente);

			if (cliente == null)
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			cliente.Telefones.Add(telefone);

			db.SaveChanges();

			return CreatedAtRoute("Telefones", new { idCliente = telefone.IdCliente }, telefone);
		}

		public IHttpActionResult PutTelefone(int idCliente, int idTelefone, Telefone telefone)
		{
			var cliente = db.Clientes.Find(idCliente);

			if (cliente == null)
				return NotFound();

			var telefoneAtual = cliente.Telefones.FirstOrDefault(t => t.Id == idTelefone);

			if (telefoneAtual == null)
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			telefoneAtual.DDD = telefone.DDD;
			telefoneAtual.Numero = telefone.Numero;

			db.SaveChanges();

			return StatusCode(HttpStatusCode.NoContent);
		}
	}
}
