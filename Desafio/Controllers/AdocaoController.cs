using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Domain.DTO;
using Desafio.Domain.Entity;
using Desafio.Services;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdocaoController : ControllerBase
    {
        private readonly AdocaoService adotaService;

        public AdocaoController(AdocaoService AdocaoService)
        {
            this.adotaService = AdocaoService;
        }

        [HttpGet]
        public IEnumerable<Adocao> Get()
        {
            return adotaService.ListarTodos();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = adotaService.PesquisarPorId(id);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }

        [HttpGet("nome/{nomeParam}")]
        public IActionResult GetByNome(string nomeParam) 
        {
            var retorno = adotaService.PesquisarPorNome(nomeParam);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            return NotFound(retorno.Mensagem);
            }

        [HttpPost]
        public IActionResult Post([FromBody] AdocaoCreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = adotaService.CadastrarNovo(postModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdocaoUpdateRequest putModel)
        {
            //Validação modelo de entrada
            if (ModelState.IsValid)
            {
                var retorno = adotaService.Editar(id, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Validação modelo de entrada
            var retorno = adotaService.Deletar(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);
            return Ok();

        }
    }
}
