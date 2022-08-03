using Library.API.Data;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : ControllerBase {


        private readonly DataContext _context;
        public ClientesController(DataContext context) {
            _context = context;
        }
               

        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.Clientes);
        }

        // GET api/clientes/1
         [HttpGet("byId/{id}")]
         public IActionResult GetById(int id) {

            var cliente = _context.Clientes.FirstOrDefault(client => client.Id == id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
         }

        // GET api/clientes/nome
         [HttpGet("ByName")]
         public IActionResult GetByName(string nome) {

            var cliente = _context.Clientes.FirstOrDefault(client => client.Nome.Contains(nome));
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
         }
        
        // POST api/clientes/name
         [HttpPost]
         public IActionResult Post(Clientes clientes) {

            _context.Add(clientes);
            _context.SaveChanges();
            return Ok(clientes);
         }

        // PUT api/clientes/name
         [HttpPut("{id}")]
         public IActionResult Put(int id, Clientes clientes) {

            var clien = _context.Clientes.AsNoTracking().FirstOrDefault(client => client.Id == id);
            if (clien == null) return BadRequest("O Cliente não foi encontrado!");
            _context.Update(clientes);
            _context.SaveChanges();
            return Ok(clientes);
        }

        // PATCH  api/clientes/name
        [HttpPatch("{id}")]
         public IActionResult Patch(int id, Clientes clientes) {

            var clien = _context.Clientes.AsNoTracking().FirstOrDefault(client => client.Id == id);
            if (clien == null) return BadRequest("O Cliente não foi encontrado!");
            _context.Update(clientes);
            _context.SaveChanges();
            return Ok(clientes);
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
         public IActionResult Delete(int id) {

            var cliente = _context.Clientes.FirstOrDefault(client => client.Id == id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");
            _context.Remove(cliente);
            _context.SaveChanges();
            return Ok();
        }
        
























    }
}
