using AutoMapper;
using Library.API.Data;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services.Interfaces;
using Library.API.V2.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.V2.Controllers {

    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]


    public class ClientesController : ControllerBase {


        private readonly IRepository _repo;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public ClientesController(IClienteService service, IRepository repo, IMapper mapper) {

            _repo = repo;
            _clienteService = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Método para retornar todos os Clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams) {
            var clientes = await _repo.GetAllClientesAsync(pageParams);

            var clientesResult = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

            Response.AddPagination(clientes.CurrentPage, clientes.PageSize, clientes.TotalCount, clientes.TotalPages);

            return Ok(clientesResult);
        }


        /// <summary>
        ///  Método para retornar um Cliente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var cliente = _repo.GetClienteById(id);
            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            var clienteDto = _mapper.Map<ClienteDto>(cliente);

            return Ok(clienteDto);
        }

        /// <summary>
        ///  Método para Adicionar um ClienteDto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(ClienteDto model) {

            var cliente = _mapper.Map<Clientes>(model);

            var result = _clienteService.ClienteCreate(cliente);
            if (result == null) return BadRequest("Email já cadastrado");

            return Ok(result);

        }

        /// <summary>
        /// Método para atualizar um Cliente através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Método para atualizar um Cliente através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Método para deletar um Cliente através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var livroAlugado = _repo.GetClienteByAluguel(id);
            if (livroAlugado != null) {
                return BadRequest("Erro: Ação não foi possivel pois há alugueis registrados com esse cliente");

            }

            var cliente = _repo.GetClienteById(id);

            if (cliente == null) return BadRequest("O Cliente não foi encontrado!");

            _repo.Delete(cliente);
            _repo.SaveChanges();
            return Ok("Cliente Deletado!");

        }
    }
}
