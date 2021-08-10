using Clientes.Data;
using Clientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clientes.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteDB context;

        public ClientesController(ClienteDB context)
        {
            this.context = context;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public IEnumerable<Cliente> ObtenerTodos()
        {
            return context.Clientes.ToList();
        }

        // GET: api/<ClientesController>/Prospectos
        [HttpGet]
        [Route("Prospectos")]
        public IEnumerable<Cliente> ListarPromocionesMensuales()
        {   //Al menos 2 A/C comprados 
            // AND
            //Compras recientes mayor a 1.000.000

            var resultado = from c in context.Clientes
                            where (c.CantidadAcComprados > 2 || c.CantidadAcComprados == 2)
                            && c.ComprasRecientes > 1000000
                            select c;

            return resultado.ToList();
        }

        // GET: api/<ClientesController>/Peores
        [HttpGet]
        [Route("Peores")]
        public IEnumerable<Cliente> ListaPeoresClientes()
        {   //Ultimo año menos de 300.000
            // OR
            //Compras recientes igual a 0

            var resultado = from c in context.Clientes
                            where c.ComprasUltimoAno < 300000
                            || c.ComprasRecientes == 0
                            select c;

            return resultado.ToList();
        }

        // GET api/<ClientesController>/5
        [HttpGet]
        [Route("clt/{cedula}")]
        public IActionResult ObtenerUno(string cedula)
        {
            var cliente = context.Clientes.FirstOrDefault((c) => c.Cedula == cedula);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult AgregarCliente([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
                return Ok(cliente);
            }

            return BadRequest(ModelState);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{cedula}")]
        public IActionResult EditarCliente([FromBody] Cliente cliente)
        {
            
            try
            {
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }
    }
}
