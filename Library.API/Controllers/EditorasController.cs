using Library.API.Data;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class EditorasController : ControllerBase {
        private readonly IRepository _repo;

        public EditorasController(IRepository repo) {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get() {
            var result = _repo.GetAllEditoras();
            return Ok(result);
        }

        // GET api/Editoras/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var ed = _repo.GetEditoraById(id);
            if (ed == null) return BadRequest("A Editora não foi encontrado!");

            return Ok(ed);
        }

        // POST api/Editoras/name
        [HttpPost]
        public IActionResult Post(Editoras editoras) {

            _repo.Add(editoras);
            if (_repo.SaveChanges()) {
                return Ok(editoras);

            }
            return BadRequest("O Cliente não foi Cadastrado!");
        }

        // PUT api/Editoras/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Editoras editoras) {

            var ed = _repo.GetEditoraById(id);
            if (ed == null) return BadRequest("A Editora não foi encontrado!");
            
            return Ok(editoras);
        }

        // PATCH  api/Editoras/id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Editoras editoras) {

            var ed = _repo.GetEditoraById(id);
            if (ed == null) return BadRequest("A Editora não foi encontrado!");

            return Ok(editoras);
        }

        // DELETE api/<EditorasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var editora = _repo.GetEditoraById(id);
            if (editora == null) return BadRequest("A Editora não foi encontrado!");
            _repo.Delete(editora);
            return Ok();
        }

























    }
}
