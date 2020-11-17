using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IProAgilRepository _repo;

        public PalestranteController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet("getByNome/{nome}")]
        public async Task<IActionResult> Get(string nome) 
        {
            
            try
            {
                var results = await _repo.GetAllPalestranteAsyncByName(nome,true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou");
            }
            
        }
        [HttpGet("{palestranteId}")]
        public async Task<IActionResult> Get(int palestranteId) 
        {
            
            try
            {
                var results = await _repo.GetAllPalestranteAsyncBy(palestranteId,true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou");
            }
         
        }

        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model) 
        {
            
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/palestrante/{model.Id}",model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int palestranteId, Palestrante model) 
        {
            
            try
            {
                var palestrante = await _repo.GetAllEventoAsyncById(palestranteId,false);
                if(palestrante == null) return NotFound();
                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/palestrante/{model.Id}",model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou");
            }

            return BadRequest();
        }

         [HttpDelete]
        public async Task<IActionResult> Delete(int eventoId) 
        {
            
            try
            {
                var palestrante = await _repo.GetAllEventoAsyncById(eventoId,false);
                if(palestrante == null) return NotFound();
                
                _repo.Delete(palestrante);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou");
            }

            return BadRequest();
        }
    }
}