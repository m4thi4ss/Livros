using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _repository;

        public TipoUsuarioController(ITipoUsuarioRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult ListaTodos()
        {
            var tipoUsuario = _repository.ListaTodos();
            return Ok(tipoUsuario);
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario tipoUsuario)
        {
            _repository.Cadastrar(tipoUsuario);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoUsuario tipoUsuarioNovo)
        {
            var tipoUsuarioAtualizado = _repository.Atualizar(id, tipoUsuarioNovo);

            if (tipoUsuarioAtualizado == null) return NotFound();

            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tipoUsuarioDeletado = _repository.Deletar(id);
            if (tipoUsuarioDeletado == null) return NotFound();
            return Ok(tipoUsuarioDeletado);
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var tipoUsuario = _repository.BuscarPorId(id);
            if (tipoUsuario == null) return NotFound();
            return Ok(tipoUsuario);
        }
    }
}
