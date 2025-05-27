using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssinaturaController : ControllerBase
    {
        private readonly IAssinaturaRepository _repository;

        public AssinaturaController(IAssinaturaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var assinaturaListas = _repository.ListarTodos();

            return Ok(assinaturaListas);
        }

        [HttpPost]
        public IActionResult Cadastrar(Assinatura assinatura)
        {
            _repository.Cadastrar(assinatura);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Assinatura assinatura)
        {
            var assinaturaAtualizar = _repository.Atualizar(id, assinatura);
            if (assinaturaAtualizar == null) return null;
            return Ok(assinaturaAtualizar);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var assinaturaDeletar = _repository.Deletar(id);
            if (assinaturaDeletar == null) return NotFound();
            return Ok(assinaturaDeletar);
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var assinatura = _repository.ListarPorId(id);
            if (assinatura == null) return NotFound();
            return Ok(assinatura);
        }
    }
}
