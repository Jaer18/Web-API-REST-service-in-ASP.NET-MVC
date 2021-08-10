using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Aplicacion.Models;
using Aplicacion.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Aplicacion.Controllers
{
    public class ClientesController : Controller
    {
        ClienteAPI api = new ClienteAPI();

        // GET: ClientesController
        public async Task<IActionResult> Index()
        {
            List<Cliente> Clientes = new List<Cliente>();
            HttpClient cliente = api.Inicializa();
            HttpResponseMessage Respuesta = await cliente.GetAsync("api/Clientes");
            if (Respuesta.IsSuccessStatusCode)
            {
                var resultados = Respuesta.Content.ReadAsStringAsync().Result;
                Clientes = JsonConvert.DeserializeObject<List<Cliente>>(resultados);
            }
            return View(Clientes);
        }

        // GET: ClientesController/Prospectos
        public async Task<IActionResult> Prospectos()
        {
            List<Cliente> Clientes = new List<Cliente>();
            HttpClient cliente = api.Inicializa();
            HttpResponseMessage Respuesta = await cliente.GetAsync("api/Clientes/Prospectos");
            if (Respuesta.IsSuccessStatusCode)
            {
                var resultados = Respuesta.Content.ReadAsStringAsync().Result;
                Clientes = JsonConvert.DeserializeObject<List<Cliente>>(resultados);
            }
            return View(Clientes);
        }

        // GET: ClientesController/Peores
        public async Task<IActionResult> Peores()
        {
            List<Cliente> Clientes = new List<Cliente>();
            HttpClient cliente = api.Inicializa();
            HttpResponseMessage Respuesta = await cliente.GetAsync("api/Clientes/Peores");
            if (Respuesta.IsSuccessStatusCode)
            {
                var resultados = Respuesta.Content.ReadAsStringAsync().Result;
                Clientes = JsonConvert.DeserializeObject<List<Cliente>>(resultados);
            }
            return View(Clientes);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        public IActionResult Create(Cliente pCliente)
        {
            HttpClient cliente = api.Inicializa();

            var postTask = cliente.PostAsJsonAsync<Cliente>("api/Clientes", pCliente);
            postTask.Wait();

            var Respuesta = postTask.Result;
            if (Respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ClientesController/Edit/5
        public async Task<IActionResult> Edit(string cedula)
        {
            Cliente pCliente = new Cliente();
            HttpClient cliente = api.Inicializa();
            HttpResponseMessage Respuesta = await cliente.GetAsync($"api/Clientes/clt/{cedula}");
            if (Respuesta.IsSuccessStatusCode)
            {
                var resultados = Respuesta.Content.ReadAsStringAsync().Result;
                pCliente = JsonConvert.DeserializeObject<Cliente>(resultados);
            }
            return View(pCliente);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        public IActionResult Edit(Cliente pCliente)
        {
            HttpClient cliente = api.Inicializa();

            var postTask = cliente.PutAsJsonAsync<Cliente>($"api/Clientes/{pCliente.Cedula}", pCliente);
            postTask.Wait();

            var Respuesta = postTask.Result;
            if (Respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        } 
    }
}
