using Library.API.Data;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class LivrosController : ControllerBase {


        private readonly DataContext _context;
        public LivrosController(DataContext context) {
            _context = context;
        }
               

        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.Livros);
        }

        // GET api/Livros/1
         [HttpGet("byId/{id}")]
         public IActionResult GetById(int id) {

            var cliente = _context.Livros.FirstOrDefault(client => client.Id == id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
         }

        // GET api/Livros/nome
         [HttpGet("ByName")]
         public IActionResult GetByName(string NomeLivro) {

            var cliente = _context.Livros.FirstOrDefault(client => client.NomeLivro.Contains(NomeLivro));
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
         }
        
        // POST api/Livros/name
         [HttpPost]
         public IActionResult Post(Livros Livros) {
            return Ok(Livros);
         }

        // PUT api/Livros/name
         [HttpPut("{id}")]
         public IActionResult Put(int id, Livros Livros) {
            return Ok(Livros);
        }

        // PATCH  api/Livros/name
        [HttpPatch("{id}")]
         public IActionResult Patch(int id, Livros Livros) {
            return Ok(Livros);
        }

        // DELETE api/<LivrosController>/5
        [HttpDelete("{id}")]
         public IActionResult Delete(int id) {
            return Ok();
        }
        
























    }
}
