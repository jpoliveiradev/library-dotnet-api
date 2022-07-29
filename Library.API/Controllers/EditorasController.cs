using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class EditorasController : ControllerBase {
        public EditorasController() {

        }

        [HttpGet]
        public IActionResult Get() {
            return Ok("Editoras: RockStar, Marbel, Siena");
        }
    }
}
