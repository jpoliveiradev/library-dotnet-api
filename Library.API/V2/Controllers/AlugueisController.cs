using AutoMapper;
using Library.API.Data;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services;
using Library.API.Services.Interfaces;
using Library.API.V2.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.V2.Controllers {

    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class AlugueisController : ControllerBase {
        private readonly IAluguelService _service;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>


        //sprivate readonly Imapper _mapper;
        public AlugueisController(IAluguelService service, IRepository repo, IMapper mapper) {
            _service = service;
            _repo = repo;
            _mapper = mapper;
            // _mapper = mapper;
        }

        /// <summary>
        /// Método para retornar todos os Alugueis
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams) {
            var result = await _repo.GetAllAlugueisAsync(pageParams);
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
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AluguelDto model) {

            var aluguel = _mapper.Map<Alugueis>(model);

            var livro = _repo.GetLivroById(model.LivroId);
            
            if (livro.Quantidade == 0) {
                return BadRequest("Erro: Livro indisponivel para aluguel, aguarde chegar mais quantidades!");
            }

            var result = _service.AluguelCreate(aluguel);

            if (result == null) return BadRequest("Previsão de Devolução anterior a data de Aluguel!");


            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>,
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(AluguelDtoUpdate model) {

            var aluguel = _mapper.Map<Alugueis>(model);

            var result = _service.AluguelUpdate(aluguel);
            if (result == null) return BadRequest("Data de Devolução anterior a data de Aluguel!");

            return Ok(result);

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
