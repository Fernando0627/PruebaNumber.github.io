using Ejercicio_Tecnivo.Models;
using Ejercicio_Tecnivo.Services;
using Microsoft.AspNetCore.Mvc;


namespace Ejercicio_Tecnivo.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class NumberController : ControllerBase
    {
        private readonly NumberService _numberService;

        public NumberController()
        {
            _numberService = new NumberService();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NumberModel model)
        {
            if (model.Number < 0 || model.Number > 999999999999)
                return BadRequest(new NumberResponseModel { Message = "El número debe estar en el rango de 0 a 999,999,999,999." });

            var pronunciation = _numberService.GetPronunciation(model.Number);
            return Ok(new NumberResponseModel { Pronunciation = pronunciation, Message = "Éxito" });
        }
    }
}

