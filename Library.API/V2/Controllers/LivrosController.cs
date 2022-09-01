using Library.API.Data;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services.Interfaces;
using Library.API.V2.Dtos.LivroDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.API.V2.Dtos.ClienteDto;
using Library.API.Services;
using Library.API.V2.Dtos.LivroCreateDto;

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
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public LivrosController(ILivroService service, IRepository repo, IMapper mapper) {
            _service = service;
            _repo = repo;
            _mapper = mapper;
        }


        /// <summary>
        /// Método para retornar todos os Livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams) {
            var livro = await _repo.GetAllLivrosAsync(pageParams);

            var livroResult = _mapper.Map<IEnumerable<LivroDto>>(livro);
            Response.AddPagination(livro.CurrentPage, livro.PageSize, livro.TotalCount, livro.TotalPages);


            return Ok(livroResult);
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

            var livroDto = _mapper.Map<LivroDto>(livro);

            return Ok(livroDto);
        }

        /// <summary>
        /// Método para adicionar um Livro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(LivroCreateDto model) {

            var livro = _mapper.Map<Livros>(model);

            var result = _service.LivroCreate(livro);

            DateTime dataAtual = DateTime.Now;

            if (livro.Lancamento > dataAtual) {
                return BadRequest("Erro: Data de lançamento depois do dia atual, não pode ser cadastrado");
            }
            else if (result == null) return BadRequest("Livro já cadastrado!");


            return Ok(result);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <param name="model"></param>
       /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, LivroDto model) {

            var livro = _repo.GetLivroById(id);
            _mapper.Map(model, livro);
            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            _repo.Update(livro);
            if (_repo.SaveChanges()) {
                return Ok(livro);

            }
            return BadRequest("O Livro não foi Atualizado!");
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <param name="model"></param>
       /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, LivroDto model) {


            var livro = _repo.GetLivroById(id);
            _mapper.Map(model, livro);

            if (livro == null) return BadRequest("O Livro não foi encontrado!");

            _repo.Update(livro);
            if (_repo.SaveChanges()) {
                return Ok(livro);

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
