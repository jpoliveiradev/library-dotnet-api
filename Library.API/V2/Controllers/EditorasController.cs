using AutoMapper;
using Library.API.Data;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services.Interfaces;
using Library.API.V2.Dtos.EditoraDto;
using Library.API.V2.Dtos.EditoraDtos;
using Microsoft.AspNetCore.Components.Forms;
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

    public class EditorasController : ControllerBase {
        private readonly IEditoraService _service;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public EditorasController(IEditoraService service, IRepository repo, IMapper mapper) {
            _service = service;
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método para retornar todas as Editoras
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams) {

            var editora = await _repo.GetAllEditorasAsync(pageParams);

            var editoraResult = _mapper.Map<IEnumerable<EditoraDto>>(editora);
            Response.AddPagination(editora.CurrentPage, editora.PageSize, editora.TotalCount, editora.TotalPages);


            return Ok(editoraResult);
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
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(EditoraCreateDto model) {

            var editora = _mapper.Map<Editoras>(model);

            var result = _service.EditoraCreate(editora);
            if (result == null) return BadRequest("Editora já cadastrada");

            return Ok(result);

        }

        /// <summary>
        /// Método para atualizar uma Editora através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, EditoraDto model) {

            var editora = _mapper.Map<Editoras>(model);

            var ed = _repo.GetEditoraById(id);
            if (ed == null) return BadRequest("A Editora não foi encontrado!");
         
            var result = _service.EditoraUpdate(editora);
            if (result == null) return BadRequest("Editora já cadastrada");
            return Ok(result);
        }


        /// <summary>
        /// Método para atualizar uma Editora através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, EditoraDto model) {

            var editora = _mapper.Map<Editoras>(model);

            var ed = _repo.GetEditoraById(id);
            if (ed == null) return BadRequest("A Editora não foi encontrado!");

            var result = _service.EditoraUpdate(editora);
            if (result == null) return BadRequest("Editora já cadastrada");
            return Ok(result);
        }

        /// <summary>
        /// Método para deletar uma Editora através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var livroCadastrado = _repo.GetEditoraByLivro(id);
            if (livroCadastrado != null) {
                return BadRequest("Editora com livros cadastrados, não poder ser apagada!");
            }

            var editora = _repo.GetEditoraById(id);
            if (editora == null) return BadRequest("A Editora não foi encontrado!");

            _repo.Delete(editora);
            _repo.SaveChanges();
            return Ok("Editora Deletada!");

        }

























    }
}
