using FeiraConnect.Model;
using FeiraConnect.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FeiraConnect.Controller
{
    [Route("~/produtos")]
    [ApiController]
    public class FeiraController : ControllerBase
    {
        private readonly IFeiraService _feiraService;
        private readonly IValidator<Feira> _feiraValidator;

        public FeiraController(IFeiraService feiraService, IValidator<Feira> feiraValidator)
        {
            _feiraService = feiraService;
            _feiraValidator = feiraValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _feiraService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _feiraService.GetById(id);

            if (Resposta is null)
            {
                return NotFound("Feira não encontrada!");
            }

            return Ok(Resposta);
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            return Ok(await _feiraService.GetByNome(nome));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Feira feira)
        {
            var validarProduto = await _feiraValidator.ValidateAsync(feira);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);


            return CreatedAtAction(nameof(GetById), new { id = feira.Id }, feira);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Feira feira)
        {
            if (feira.Id == 0)
                return BadRequest("Id da Feira é inválido!");

            var validarProduto = await _feiraValidator.ValidateAsync(feira);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _feiraService.Update(feira);

            if (Resposta is null)
                return NotFound("Feira não encontrada!");

            return Ok(Resposta);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscaFeira = await _feiraService.GetById(id);

            if (BuscaFeira is null)
                return NotFound("Feira não encontrada!");

            await _feiraService.Delete(BuscaFeira);

            return NoContent();

        }

    }
}
