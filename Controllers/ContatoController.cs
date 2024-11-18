using AgendaAPI.Dto;
using AgendaAPI.Models;
using AgendaAPI.Services.Contato;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoInterface _contatoInterface;

        public ContatoController(IContatoInterface contatoInterface)
        {
            _contatoInterface = contatoInterface;
        }

        [HttpGet("ListarContatos")]
        public async Task<ActionResult<ResponseModel<List<ContatoModel>>>> ListarContatos()
        {
            var contatos = await _contatoInterface.ListarContatos();
            return Ok(contatos);
        }

        [HttpGet("BuscarPorId/{idContato}")]
        public async Task<ActionResult<ResponseModel<ContatoModel>>> BuscarContatoPorId(int idContato)
        {
            var contato = await _contatoInterface.BuscarContatoPorId(idContato);
            return Ok(contato);
        }

        [HttpPost("CriarContato")]
        public async Task<ActionResult<ResponseModel<List<ContatoModel>>>> CriarContato(CriarContatoDto criarContatoDto)
        {
            var resposta = await _contatoInterface.CriarContato(criarContatoDto);
            return Ok(resposta);
        }

        [HttpPut("EditarContato")]
        public async Task<ActionResult<ResponseModel<List<ContatoModel>>>> EditarContato(EditarContatoDto editarContatoDto)
        {
            var contatos = await _contatoInterface.EditarContato(editarContatoDto);
            return Ok(contatos);
        }

        [HttpDelete("ExcluirContato/{idContato}")]
        public async Task<ActionResult<ResponseModel<List<ContatoModel>>>> ExcluirContato(int idContato)
        {
            var contatos = await _contatoInterface.ExcluirContato(idContato);
            return Ok(contatos);
        }
    }
}
