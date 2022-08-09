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


        private readonly IRepository _repo;

        public ClientesController(IRepository repo) {
            
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get() {
            var result = _repo.GetAllClientes();
            return Ok(result);
        }

        // GET api/clientes/
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var cliente = _repo.GetClienteById(id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
        }

        /*// GET api/clientes/nome
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome) {

            var cliente = _context.Clientes.FirstOrDefault(client => client.Nome.Contains(nome));
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
        }*/

        // POST api/clientes/name
        [HttpPost]
        public IActionResult Post(Clientes cliente) {

            _repo.Add(cliente);
            if (_repo.SaveChanges()) {
                return Ok(cliente);

            }
            return BadRequest("O Cliente não foi Cadastrado!");

        }

        // PUT api/clientes/name
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clientes cliente) {

            var clien = _repo.GetClienteById(id);
            if (clien == null) return BadRequest("O Cliente não foi encontrado!");
           
            _repo.Update(cliente);
            if (_repo.SaveChanges()) {
                return Ok(cliente);

            }
            return BadRequest("O Cliente não foi Atualizado!");
        }

        // PATCH  api/clientes/name
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Clientes cliente) {

            var clien = _repo.GetClienteById(id);
            if (clien == null) return BadRequest("O Cliente não foi encontrado!");

            _repo.Update(cliente);
            if (_repo.SaveChanges()) {
                return Ok(cliente);

            }
            return BadRequest("O Cliente não foi Atualizado!");
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var clien = _repo.GetClienteById(id);
            if (clien == null) return BadRequest("O Cliente não foi encontrado!");

            _repo.Delete(clien);
            if (_repo.SaveChanges()) {
                return Ok("Cliente Deletado!");

            }
            return BadRequest("O Cliente não foi Deletado!");
        }

























    }
}
