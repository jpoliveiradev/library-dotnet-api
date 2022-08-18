using Library.API.Data;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.V1.Controllers {

    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class LivrosController : ControllerBase {


        private readonly IRepository _repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public LivrosController(IRepository repo) {

            _repo = repo;
        }


        /// <summary>
        /// Método para retornar todos os Livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() {
            var result = _repo.GetAllLivros(true);
            return Ok(result);
        }

        /// <summary>
        /// Método para retornar um Livro pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var livro = _repo.GetLivroById(id, true);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            return Ok(livro);
        }

        /// <summary>
        /// Método para adicionar um Livro
        /// </summary>
        /// <param name="livros"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Livros livros) {

            _repo.Add(livros);
            if (_repo.SaveChanges()) {
                return Ok(livros);

            }
            return BadRequest("O Livro não foi Cadastrado!");
        }

        /// <summary>
        /// Método para atualizar um Livro através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="livros"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Livros livros) {

            var livro = _repo.GetLivroById(id);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            _repo.Update(livros);
            if (_repo.SaveChanges()) {
                return Ok(livros);

            }
            return BadRequest("O Livro não foi Atualizado!");
        }

        /// <summary>
        /// Método para atualizar um Livro através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="livros"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para deletar um Livro através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
