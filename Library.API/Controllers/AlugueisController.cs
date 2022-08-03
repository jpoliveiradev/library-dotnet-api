using Library.API.Data;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class AlugueisController : ControllerBase {


        private readonly DataContext _context;
        public AlugueisController(DataContext context) {
            _context = context;
        }
               

        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.Alugueis);
        }

        // GET api/Alugueis/1
         [HttpGet("byId/{id}")]
         public IActionResult GetById(int id) {

            var cliente = _context.Alugueis.FirstOrDefault(client => client.Id == id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
         }

        /*// GET api/Alugueis/nome
         [HttpGet("ByName")]
         public IActionResult GetByName(int LivroId) {

            var cliente = _context.Alugueis.FirstOrDefault(client => client.Id == id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
         }*/
        
        // POST api/Alugueis/name
         [HttpPost]
         public IActionResult Post(Alugueis Alugueis) {
            return Ok(Alugueis);
         }

        // PUT api/Alugueis/name
         [HttpPut("{id}")]
         public IActionResult Put(int id, Alugueis Alugueis) {
            return Ok(Alugueis);
        }

        // PATCH  api/Alugueis/name
        [HttpPatch("{id}")]
         public IActionResult Patch(int id, Alugueis Alugueis) {
            return Ok(Alugueis);
        }

        // DELETE api/<AlugueisController>/5
        [HttpDelete("{id}")]
         public IActionResult Delete(int id) {
            return Ok();
        }
        
























    }
}
