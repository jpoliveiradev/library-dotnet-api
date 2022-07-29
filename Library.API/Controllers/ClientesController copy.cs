/*using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : ControllerBase {


        public List<Clientes> Clientes = new List<Clientes> {
            new Clientes {
                Id = 1,
                Nome = "Carlos",
                Endereco = "Rua al",
                Cidade = "Fortaleza",
                Email = "clli@gmail.com"
            },
            new Clientes {
                Id = 2,
                Nome = "JP",
                Endereco = "Rua Tal123",
                Cidade = "SP",
                Email = "jp@gmail.com"
            },
            new Clientes {
                Id = 3,
                Nome = "Oliveira",
                Endereco = "Rua 123",
                Cidade = "RJ",
                Email = "oliver@gmail.com"
            }
        };



        public ClientesController() { }

        [HttpGet]
        public IActionResult Get() {
            return Ok(Clientes);
        }

        // GET api/clientes/1
         [HttpGet("byId/{id}")]
         public IActionResult GetById(int id) {

            var cliente = Clientes.FirstOrDefault(client => client.Id == id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
         }

        // GET api/clientes/nome
         [HttpGet("ByName")]
         public IActionResult GetByName(string nome) {

            var cliente = Clientes.FirstOrDefault(client => client.Nome.Contains(nome));
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            return Ok(cliente);
         }
        
        // POST api/clientes/name
         [HttpPost]
         public IActionResult Post(Clientes clientes) {
            return Ok(clientes);
         }

        // PUT api/clientes/name
         [HttpPut("{id}")]
         public IActionResult Put(int id, Clientes clientes) {
            return Ok(clientes);
        }

        // PATCH  api/clientes/name
        [HttpPatch("{id}")]
         public IActionResult Patch(int id, Clientes clientes) {
            return Ok(clientes);
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
         public IActionResult Delete(int id) {
            return Ok();
        }
        
























    }
}*/
