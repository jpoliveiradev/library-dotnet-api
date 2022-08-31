using Library.API.Data;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.API.V2.Controllers {

    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class LivrosController : ControllerBase {
        private readonly ILivroService _service;
        private readonly IRepository _repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repo"></param>
        public LivrosController(ILivroService service, IRepository repo) {
            _service = service;
            _repo = repo;
        }


        /// <summary>
        /// Método para retornar todos os Livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams) {
            var result = await _repo.GetAllLivrosAsync(pageParams, true);
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
        /// <param name="livro"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Livros livro) {

            var result = _service.LivroCreate(livro);
            DateTime dataAtual = DateTime.Now;

            if (livro.Lancamento > dataAtual) {
                return BadRequest("Erro: Data de lançamento depois do dia atual, não pode ser cadastrado");
            }
            else if (result == null) return BadRequest("Livro já cadastrado!");


            return Ok(result);
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

            var livroAluguel = _repo.GetLivroByAluguel(id);
            if (livroAluguel != null) {
                return BadRequest("Erro: Livro alugado, não pode ser apagado!");
            }

            var livro = _repo.GetLivroById(id);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            _repo.Delete(livro);
            _repo.SaveChanges();
            return Ok("Livro Deletado!");
        }

























    }
}
