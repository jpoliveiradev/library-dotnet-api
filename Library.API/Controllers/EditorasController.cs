using Library.API.Data;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class EditorasController : ControllerBase {


        private readonly DataContext _context;
        public EditorasController(DataContext context) {
            _context = context;
        }
               

        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.Editoras);
        }

        // GET api/Editoras/1
         [HttpGet("byId/{id}")]
         public IActionResult GetById(int id) {

            var editora = _context.Editoras.FirstOrDefault(editora => editora.Id == id);
            if (editora == null) return BadRequest("A Editora não foi encontrado!");

            return Ok(editora);
         }

        // GET api/Editoras/nome
         [HttpGet("ByName")]
         public IActionResult GetByName(string nome) {

            var editora = _context.Editoras.FirstOrDefault(client => client.NomeEditora.Contains(nome));
            if (editora == null) return BadRequest("A Editora não foi encontrado!");

            return Ok(editora);
         }
        
        // POST api/Editoras/name
         [HttpPost]
         public IActionResult Post(Editoras Editoras) {
            return Ok(Editoras);
         }

        // PUT api/Editoras/id
         [HttpPut("{id}")]
         public IActionResult Put(int id, Editoras Editoras) {
            return Ok(Editoras);
        }

        // PATCH  api/Editoras/id
        [HttpPatch("{id}")]
         public IActionResult Patch(int id, Editoras Editoras) {
            return Ok(Editoras);
        }

        // DELETE api/<EditorasController>/5
        [HttpDelete("{id}")]
         public IActionResult Delete(int id) {
            return Ok();
        }
        
























    }
}
