﻿using Library.API.Data;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class AlugueisController : ControllerBase {


        private readonly IRepository _repo;


        // aaaaaaaaaaaaaabbbbbbbbbbaaa



       //sprivate readonly Imapper _mapper;
        public AlugueisController(IRepository repo //, IMapper mapper
        ) {

            _repo = repo;
           // _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get() {
            var result = _repo.GetAllAlugueis();
            return Ok(result);
        }

        // GET api/Alugueis/1
         [HttpGet("{id}")]
         public IActionResult GetById(int id) {

            var aluguel = _repo.GetAluguelById(id);
            if (aluguel == null) return BadRequest("O aluguel não foi encontrado!");

            return Ok(aluguel);
        }

        /*// GET api/Alugueis/nome
         [HttpGet("ByName")]
         public IActionResult GetByName(int LivroId) {

            var aluguel = _context.Alugueis.FirstOrDefault(client => client.Id == id);
            if (aluguel == null) return BadRequest("O aluguel não foi encontrado!");

            return Ok(aluguel);
         }*/
        
        // POST api/Alugueis/name
         [HttpPost]
         public IActionResult Post(Alugueis alugueis) {

            _repo.Add(alugueis);
            if (_repo.SaveChanges()) {
                return Ok(alugueis);

            }
            return BadRequest("O aluguel não foi Cadastrado!");
        }

        // PUT api/Alugueis/id
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

        // PATCH  api/Alugueis/id
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
