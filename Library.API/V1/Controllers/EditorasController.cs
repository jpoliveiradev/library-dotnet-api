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

    public class EditorasController : ControllerBase {
        private readonly IRepository _repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public EditorasController(IRepository repo) {
            _repo = repo;
        }

        /// <summary>
        /// Método para retornar todas as Editoras
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() {
            var result = _repo.GetAllEditoras();
            return Ok(result);
        }

        /// <summary>
        /// Método para retornar uma Editora pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var ed = _repo.GetEditoraById(id);
            if (ed == null) return BadRequest("A Editora não foi encontrado!");

            return Ok(ed);
        }

        /// <summary>
        /// Método adicionar adicionar uma Editora
        /// </summary>
        /// <param name="editoras"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(Editoras editoras) {

            _repo.Add(editoras);
            if (_repo.SaveChanges()) {
                return Ok(editoras);

            }
            return BadRequest("O Cliente não foi Cadastrado!");
        }

        /// <summary>
        /// Método para atualizar uma Editora através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editoras"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Editoras editoras) {

            var ed = _repo.GetEditoraById(id);
            if (ed == null) return BadRequest("A Editora não foi encontrado!");

            return Ok(editoras);
        }


        /// <summary>
        /// Método para atualizar uma Editora através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editoras"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Editoras editoras) {

            var ed = _repo.GetEditoraById(id);
            if (ed == null) return BadRequest("A Editora não foi encontrado!");

            return Ok(editoras);
        }

        /// <summary>
        /// Método para deletar uma Editora através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var editora = _repo.GetEditoraById(id);
            if (editora == null) return BadRequest("A Editora não foi encontrado!");
            _repo.Delete(editora);
            return Ok();
        }

























    }
}
