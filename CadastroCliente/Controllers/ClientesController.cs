using CadastroCliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace CadastroCliente.Controllers
{
    public class ClientesController : Controller
    {
		HttpClient apiClient = new HttpClient();

		public ClientesController()
		{
			apiClient.BaseAddress = new Uri("http://localhost:52531");
			apiClient.DefaultRequestHeaders.Accept.Clear();
			apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

        // GET: Clientes
        public ActionResult Index()
        {
			List<Cliente> clientes = new List<Cliente>();
			HttpResponseMessage response = apiClient.GetAsync("/api/clientes").Result;
			if (response.IsSuccessStatusCode)
			{
				clientes = response.Content.ReadAsAsync<List<Cliente>>().Result;
			}
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
			List<Telefone> telefones = new List<Telefone>();
			HttpResponseMessage responseTelefones = apiClient.GetAsync($"/api/clientes/{id}/telefones").Result;
			if (responseTelefones.IsSuccessStatusCode)
			{
				telefones = responseTelefones.Content.ReadAsAsync<List<Telefone>>().Result;
			}


			HttpResponseMessage response = apiClient.GetAsync($"/api/clientes/{id}").Result;
			Cliente cliente = response.Content.ReadAsAsync<Cliente>().Result;

			cliente.Telefones = telefones;

			if (cliente != null)
				return View(cliente);
			else
				return HttpNotFound();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
				HttpResponseMessage response = apiClient.PostAsJsonAsync<Cliente>("/api/clientes", cliente).Result;

				if (response.StatusCode == HttpStatusCode.Created)
				{
					if (cliente.Telefones != null)
					{
						foreach (var telefone in cliente.Telefones)
						{
							if (telefone.DDD != null && telefone.Numero != null)
							{
								HttpResponseMessage responseTelefones = apiClient.PostAsJsonAsync<Telefone>($"{response.Headers.Location.AbsolutePath}/telefones", telefone).Result;
							}

						}
					}

					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.Error = "Error while creating note.";
					return View();
				}
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
			List<Telefone> telefones = new List<Telefone>();
			HttpResponseMessage responseTelefones = apiClient.GetAsync($"/api/clientes/{id}/telefones").Result;
			if (responseTelefones.IsSuccessStatusCode)
			{
				telefones = responseTelefones.Content.ReadAsAsync<List<Telefone>>().Result;
			}

			HttpResponseMessage response = apiClient.GetAsync($"/api/clientes/{id}").Result;
			Cliente cliente = response.Content.ReadAsAsync<Cliente>().Result;

			cliente.Telefones = telefones;

			if (cliente != null)
				return View(cliente);
			else
				return HttpNotFound();
		}

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
				HttpResponseMessage response = apiClient.PutAsJsonAsync<Cliente>($"/api/clientes/{id}", cliente).Result;
				HttpResponseMessage responseTelefones;
				if (response.StatusCode == HttpStatusCode.NoContent)
				{
					if (cliente.Telefones != null)
					{
						foreach (var telefone in cliente.Telefones)
						{
							if (telefone.DDD != null && telefone.Numero != null)
							{
								if (telefone.Id < 0)
									responseTelefones = apiClient.PostAsJsonAsync<Telefone>($"/api/clientes/{id}/telefones", telefone).Result;
								else
									responseTelefones = apiClient.PutAsJsonAsync<Telefone>($"/api/clientes/{id}/telefones", telefone).Result;
							}

						}
					}

					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.Error = "Error while editing note.";
					return View();
				}
			}
            catch
            {
                return View();
            }
        }

		[HttpPost]
		public void RemoverTelefone(int idTelefone, int idCliente)
		{
			HttpResponseMessage response = apiClient.DeleteAsync($"/api/clientes/{idCliente}/telefones/{idTelefone}").Result;
		}

		// GET: Clientes/Delete/5
		public ActionResult Delete(int id)
        {
			List<Telefone> telefones = new List<Telefone>();
			HttpResponseMessage responseTelefones = apiClient.GetAsync($"/api/clientes/{id}/telefones").Result;
			if (responseTelefones.IsSuccessStatusCode)
			{
				telefones = responseTelefones.Content.ReadAsAsync<List<Telefone>>().Result;
			}

			HttpResponseMessage response = apiClient.GetAsync($"/api/clientes/{id}").Result;
			Cliente cliente = response.Content.ReadAsAsync<Cliente>().Result;

			cliente.Telefones = telefones;
			
			if (cliente != null)
				return View(cliente);
			else
				return HttpNotFound();
		}

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				HttpResponseMessage response = apiClient.DeleteAsync($"/api/clientes/{id}").Result;
				if (response.StatusCode == HttpStatusCode.OK)
				{
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.Error = "Error while deleting note.";
					return View();
				}
			}
            catch
            {
                return View();
            }
        }
    }
}
