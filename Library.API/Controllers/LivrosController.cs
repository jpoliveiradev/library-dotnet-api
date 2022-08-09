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


        private readonly IRepository _repo;

        public LivrosController(IRepository repo) {

            _repo = repo;
        }



        [HttpGet]
        public IActionResult Get() {
            var result = _repo.GetAllLivros(true);
            return Ok(result);
        }

        // GET api/Livros/1
         [HttpGet("{id}")]
         public IActionResult GetById(int id) {

            var livro = _repo.GetLivroById(id, true);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            return Ok(livro);
         }

        /*// GET api/Livros/nome
         [HttpGet("ByName")]
         public IActionResult GetByName(string NomeLivro) {

            var livro = _context.Livros.FirstOrDefault(livr => livr.NomeLivro.Contains(NomeLivro));
            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            return Ok(livro);
         }*/
        
        // POST api/Livros/name
         [HttpPost]
         public IActionResult Post(Livros livros) {

            _repo.Add(livros);
            if (_repo.SaveChanges()) {
                return Ok(livros);

            }
            return BadRequest("O Livro não foi Cadastrado!");
        }

        // PUT api/Livros/name
         [HttpPut("{id}")]
         public IActionResult Put(int id, Livros livros) {

            var livro = _repo.GetLivroById(id);
            if (livro == null) return BadRequest("O Cliente não foi encontrado!");

            _repo.Update(livros);
            if (_repo.SaveChanges()) {
                return Ok(livros);

            }
            return BadRequest("O Livro não foi Atualizado!");
        }

        // PATCH  api/Livros/name
        [HttpPatch("{id}")]
         public IActionResult Patch(int id, Livros livros) {

            var livro = _repo.GetLivroById(id);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");
            _repo.Update(livros);
            if (_repo.SaveChanges()) {
                return Ok(livros);

            }
            return BadRequest("O Livro não foi Atualizado!");
        }

        // DELETE api/<LivrosController>/5
        [HttpDelete("{id}")]
         public IActionResult Delete(int id) {

            var livro = _repo.GetLivroById(id);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            _repo.Delete(livro);
            if (_repo.SaveChanges()) {
                return Ok("Livro Deletado!");

            }
            return BadRequest("O Livro não foi Deletado!");
        }
        
























    }
}
