using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListaTodos()
        {
            var usuario = _repository.ListaTodos();
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _repository.Cadastrar(usuario);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuarioNovo)
        {
            var usuarioAtualizar = _repository.Atualizar(id, usuarioNovo);

            if (usuarioAtualizar == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var usuarioDeletar = _repository.Deletar(id);
            if (usuarioDeletar == null) return null;
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var usuarioBuscar = _repository.BuscarPorId(id);
            if (usuarioBuscar == null) return NotFound();
            return Ok();
        }
    }
}
