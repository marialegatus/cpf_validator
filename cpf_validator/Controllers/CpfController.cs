using cpf_validator.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace cpf_validator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpfController : ControllerBase
    {
        private CpfAppService _cpfAppService = new CpfAppService();

        /// <summary>
        /// Valida valor de cpf informado.
        /// </summary>
        /// <param name="cpf">CPF com ou sem máscara.</param>
        /// <returns>Retorna se o valor informado é válido ou não</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Validate([FromQuery]string value)
        {
            try
            {
                bool retorno =  _cpfAppService.Validate(value);

                return Ok("CPF válido");
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
