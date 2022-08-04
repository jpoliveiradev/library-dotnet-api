using Library.API.Data;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var livro = _context.Livros.FirstOrDefault(livr => livr.Id == id);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            return Ok(livro);
         }

        // GET api/Livros/nome
         [HttpGet("ByName")]
         public IActionResult GetByName(string NomeLivro) {

            var livro = _context.Livros.FirstOrDefault(livr => livr.NomeLivro.Contains(NomeLivro));
            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            return Ok(livro);
         }
        
        // POST api/Livros/name
         [HttpPost]
         public IActionResult Post(Livros Livros) {

            _context.Add(Livros);
            _context.SaveChanges();
            return Ok(Livros);
         }

        // PUT api/Livros/name
         [HttpPut("{id}")]
         public IActionResult Put(int id, Livros Livros) {

            var livro = _context.Livros.AsNoTracking().FirstOrDefault(livr => livr.Id == id);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");
            _context.Update(Livros);
            _context.SaveChanges();
            return Ok(Livros);
        }

        // PATCH  api/Livros/name
        [HttpPatch("{id}")]
         public IActionResult Patch(int id, Livros Livros) {

            var livro = _context.Livros.AsNoTracking().FirstOrDefault(livr => livr.Id == id);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");
            _context.Update(Livros);
            _context.SaveChanges();
            return Ok(Livros);
        }

        // DELETE api/<LivrosController>/5
        [HttpDelete("{id}")]
         public IActionResult Delete(int id) {

            var livro = _context.Livros.FirstOrDefault(livr => livr.Id == id);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");
            _context.Remove(livro);
            _context.SaveChanges();
            return Ok();
        }
        
























    }
}
