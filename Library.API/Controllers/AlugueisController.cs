using Library.API.Data;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var aluguel = _context.Alugueis.FirstOrDefault(aluga => aluga.Id == id);
            if (aluguel == null) return BadRequest("O Aluguel não foi encontrado!");

            return Ok(aluguel);
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

            _context.Add(Alugueis);
            _context.SaveChanges();
            return Ok(Alugueis);
         }

        // PUT api/Alugueis/id
         [HttpPut("{id}")]
         public IActionResult Put(int id, Alugueis Alugueis) {

            var aluguel = _context.Alugueis.AsNoTracking().FirstOrDefault(aluga => aluga.Id == id);
            if (aluguel == null) return BadRequest("O Aluguel não foi encontrado!");
            _context.Update(Alugueis);
            _context.SaveChanges();
            return Ok(Alugueis);
        }

        // PATCH  api/Alugueis/id
        [HttpPatch("{id}")]
         public IActionResult Patch(int id, Alugueis Alugueis) {

            var aluguel = _context.Alugueis.AsNoTracking().FirstOrDefault(aluga => aluga.Id == id);
            if (aluguel == null) return BadRequest("O Aluguel não foi encontrado!");
            _context.Update(Alugueis);
            _context.SaveChanges();
            return Ok(Alugueis);
        }

        // DELETE api/<AlugueisController>/5
        [HttpDelete("{id}")]
         public IActionResult Delete(int id) {

            var aluguel = _context.Alugueis.FirstOrDefault(aluga => aluga.Id == id);
            if (aluguel == null) return BadRequest("O Aluguel não foi encontrado!");
            _context.Remove(aluguel);
            _context.SaveChanges();
            return Ok();
        }
        
























    }
}
