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
    public class ClientesController : ApiController
    {
		private ClienteContext db = new ClienteContext();

		public IHttpActionResult GetCliente()
		{
			var clientes = db.Clientes.OrderBy(c => c.Nome);

			return Ok(clientes);
		}

		public IHttpActionResult GetCliente(int id)
		{
			if (id <= 0)
				return BadRequest("O id deve ser um número maior que zero");

			var cliente = db.Clientes.Find(id);

			if (cliente == null)
				return NotFound();

			return Ok(cliente);
		}

		public IHttpActionResult PostCliente(Cliente cliente)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			db.Clientes.Add(cliente);
			db.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = cliente.Id }, cliente);
		}

		public IHttpActionResult PutCliente(int id, Cliente cliente)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (id != cliente.Id)
				return BadRequest("O id informado na URL é diferente do id informado no corpo da requisição");

			if (db.Clientes.Count(c => c.Id == id) == 0)
				return NotFound();

			db.Entry(cliente).State = EntityState.Modified;
			db.SaveChanges();

			return StatusCode(HttpStatusCode.NoContent);
		}

		public IHttpActionResult DeleteCliente(int id)
		{
			if (id <= 0)
				return BadRequest("O id de ser um número maior que zero");

			var cliente = db.Clientes.Find(id);

			if (cliente == null)
				return NotFound();

			db.Clientes.Remove(cliente);
			db.SaveChanges();

			return StatusCode(HttpStatusCode.OK);
		}
	}
}
