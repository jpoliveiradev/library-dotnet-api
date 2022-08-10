using AutoMapper;
using Library.API.Data;
using Library.API.Dtos;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : ControllerBase {


        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ClientesController(IRepository repo, IMapper mapper) {

            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet("getRegister")]
        public IActionResult getRegister() {


            return Ok(new ClienteRegistrarDto());
        }
        

        [HttpGet]
        public IActionResult Get() {
            var clientes = _repo.GetAllClientes();

            return Ok(_mapper.Map<IEnumerable<ClienteDto>>(clientes));
        }

        // GET api/clientes/
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var cliente = _repo.GetClienteById(id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            var clienteDto = _mapper.Map<ClienteDto>(cliente);

            return Ok(clienteDto);
        }

        /*// GET api/clientes/nome
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome) {

            var cliente = _context.Clientes.FirstOrDefault(client => client.Nome.Contains(nome));
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
        }*/

        // POST api/clientes/name
        [HttpPost]
        public IActionResult Post(ClienteDto model) {

            var cliente = _mapper.Map<Clientes>(model);

            _repo.Add(cliente);
            if (_repo.SaveChanges()) {

                return Created($"/api/clientes/{model.Id}", _mapper.Map<ClienteDto>(cliente));
            }

            return BadRequest("O Cliente não foi Cadastrado!");
        }

        // PUT api/clientes/name
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClienteDto model) {

            var cliente = _repo.GetClienteById(id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            _mapper.Map(model, cliente);

            _repo.Update(cliente);
            if (_repo.SaveChanges()) {
                return Created($"/api/clientes/{model.Id}", _mapper.Map<ClienteDto>(cliente));

            }
            return BadRequest("O Cliente não foi Atualizado!");
        }

        // PATCH  api/clientes/name
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ClienteDto model) {

            var cliente = _repo.GetClienteById(id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            _mapper.Map(model, cliente);

            _repo.Update(cliente);
            if (_repo.SaveChanges()) {
                return Created($"/api/clientes/{model.Id}", _mapper.Map<ClienteDto>(cliente));

            }
            return BadRequest("O Cliente não foi Atualizado!");
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var cliente = _repo.GetClienteById(id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            _repo.Delete(cliente);
            if (_repo.SaveChanges()) {

                return Ok("Cliente Deletado!");
            }
            return BadRequest("O Cliente não foi Deletado!");
        }





    }
}
