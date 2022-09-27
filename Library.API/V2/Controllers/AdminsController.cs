using AutoMapper;
using Library.API.Data;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.V2.Dtos.AdminDto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.V2.Dtos.AdminCreateDto;
using Library.API.Services.Interfaces;

namespace Library.API.V2.Controllers {
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdminsController : ControllerBase {
        private readonly IAdminService _service;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AdminsController(IAdminService service, IRepository repo, IMapper mapper) {
            _repo = repo;
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Método para retornar todos os Admins
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams) {
            var admins = await _repo.GetAllAdminsAsync(pageParams);

            var adminResult = _mapper.Map<IEnumerable<AdminDto>>(admins);

            Response.AddPagination(admins.CurrentPage, admins.PageSize, admins.TotalCount, admins.TotalPages);

            return Ok(adminResult);
        }


        /// <summary>
        ///  Método para retornar um admin pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var admin = _repo.GetAdminById(id);
            if (admin == null) return BadRequest("O admin não foi encontrado!");

            var adminDto = _mapper.Map<AdminDto>(admin);

            return Ok(adminDto);
        }

        [HttpGet("alterarPassword/{email}")]
        public IActionResult GetByEmail(string email) {

            var admin = _repo.GetAdminByEmail(email);
            if (admin == null) return BadRequest("O admin não foi encontrado!");

            var adminDto = _mapper.Map<AdminDto>(admin);

            return Ok(adminDto);
        }

        /// <summary>
        ///  Método para Adicionar um adminDto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(AdminCreateDto model) {

            var admin = _mapper.Map<Admins>(model);

            var result = _service.AdminCreate(admin);
            if (result == null) return BadRequest("Email ou Username já cadastrado");

            return Ok(result);

        }

        /// <summary>
        /// Método para atualizar um admin através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public IActionResult Put(int id, AdminDto model) {

            var admin = _repo.GetAdminById(id);
            if (admin == null) return BadRequest("O admin não foi encontrado!");

            _mapper.Map(model, admin);


            var result = _service.AdminUpdate(admin);
            if (result == null) return BadRequest("Email ou Username já cadastrado");

            return Ok(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AdminDto model) {

            var admin = _repo.GetAdminById(id);
            if (admin == null) return BadRequest("O admin não foi encontrado!");

            _mapper.Map(model, admin);


            var result = _service.AdminUpdate(admin);
            if (result == null) return BadRequest("Email ou Username já cadastrado");

            return Ok(result);
        }

        /// <summary>
        /// Método para deletar um admin através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var admin = _repo.GetAdminById(id);

            if (admin == null) return BadRequest("O admin não foi encontrado!");

            _repo.Delete(admin);
            _repo.SaveChanges();
            return Ok("admin Deletado!");


        }
    }
}
