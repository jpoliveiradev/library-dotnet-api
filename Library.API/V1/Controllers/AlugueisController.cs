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

    public class AlugueisController : ControllerBase {


        private readonly IRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>


        //sprivate readonly Imapper _mapper;
        public AlugueisController(IRepository repo //, IMapper mapper
        ) {

            _repo = repo;
            // _mapper = mapper;
        }

        /// <summary>
        /// Método para retornar todos os Alugueis
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get() {
            var result = _repo.GetAllAlugueis();
            return Ok(result);
        }

        /// <summary>
        /// Método para retornar um Aluguel pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/Alugueis/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var aluguel = _repo.GetAluguelById(id);
            if (aluguel == null) return BadRequest("O aluguel não foi encontrado!");

            return Ok(aluguel);
        }

        /// <summary>
        /// Método para Adicionar um Aluguel
        /// </summary>
        /// <param name="alugueis"></param>
        /// <returns></returns>
        // POST api/Alugueis/name
        [HttpPost]
        public IActionResult Post(Alugueis alugueis) {

            _repo.Add(alugueis);
            if (_repo.SaveChanges()) {
                return Ok(alugueis);

            }
            return BadRequest("O aluguel não foi Cadastrado!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alugueis"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Alugueis alugueis) {

            var alu = _repo.GetAluguelById(id);
            if (alu == null) return BadRequest("O aluguel não foi encontrado!");

            _repo.Update(alugueis);
            if (_repo.SaveChanges()) {
                return Ok(alugueis);

            }
            return BadRequest("O aluguel não foi Atualizado!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alugueis"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Alugueis alugueis) {

            var alu = _repo.GetAluguelById(id);
            if (alu == null) return BadRequest("O aluguel não foi encontrado!");

            _repo.Update(alugueis);
            if (_repo.SaveChanges()) {
                return Ok(alugueis);

            }
            return BadRequest("O aluguel não foi Atualizado!");
        }

        /// <summary>
        /// Método para deletar um Aluguel através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE api/<AlugueisController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var alu = _repo.GetAluguelById(id);
            if (alu == null) return BadRequest("O aluguel não foi encontrado!");

            _repo.Delete(alu);
            if (_repo.SaveChanges()) {
                return Ok("aluguel Deletado!");

            }
            return BadRequest("O aluguel não foi Deletado!");
        }

























    }
}
