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
        private readonly IRepository _repo;

        public ClientesController(DataContext context, IRepository repo) {
            _context = context;
            _repo = repo;
        }


        //[HttpGet]
        //public IActionResult repositorio() {
        //    return Ok(_repo.Clientes);
        //}      

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

            _repo.Add(clientes);
            if (_repo.SaveChanges()) {
                return Ok(clientes);

            }
            return BadRequest("O Cliente não foi Cadastrado!");

        }

        // PUT api/clientes/name
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clientes clientes) {

            var clien = _context.Clientes.AsNoTracking().FirstOrDefault(client => client.Id == id);
            if (clien == null) return BadRequest("O Cliente não foi encontrado!");
           
            _repo.Update(clientes);
            if (_repo.SaveChanges()) {
                return Ok(clientes);

            }
            return BadRequest("O Cliente não foi Atualizado!");
        }

        // PATCH  api/clientes/name
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Clientes clientes) {

            var clien = _context.Clientes.AsNoTracking().FirstOrDefault(client => client.Id == id);
            if (clien == null) return BadRequest("O Cliente não foi encontrado!");

            _repo.Update(clientes);
            if (_repo.SaveChanges()) {
                return Ok(clientes);

            }
            return BadRequest("O Cliente não foi Atualizado!");
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var cliente = _context.Clientes.FirstOrDefault(client => client.Id == id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            _repo.Delete(cliente);
            if (_repo.SaveChanges()) {
                return Ok("Cliente Deletado!");

            }
            return BadRequest("O Cliente não foi Deletado!");
        }

























    }
}
