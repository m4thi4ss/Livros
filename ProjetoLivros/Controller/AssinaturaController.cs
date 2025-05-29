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
        //Injetar o Repository
        private readonly IAssinaturaRepository _repository; // Criar uma variavel para guardar a interface IAssinaturaRepository 

        public AssinaturaController(IAssinaturaRepository repository) // Criar uma variavel para guardar a interface IAssinaturaRepository 
        {
            _repository = repository;
        }

        [HttpGet] //Aqui seria o endpoint de leitura 
        public IActionResult ListarTodos() //Aqui seria o começo do metodo de listar todos
        {
            var assinaturaListas = _repository.ListarTodos(); //Aqui vai ser criado uma variavel que vai pegar o metodo listar todos

            return Ok(assinaturaListas); //Se o metodo estiver funcionando ele vai mandar um ok
        }

        [HttpPost] //Aqui seria o endpoint de cadastrar 
        public IActionResult Cadastrar(Assinatura assinatura) //Aqui e o começo do metodo cadastrar 
        {
            _repository.Cadastrar(assinatura); //Aqui ele vai pegar o metodo cadastrar do repository
            return Ok(); //Se o metodo estiver funcionando ele vai mandar um ok
        }

        [HttpPut("{id}")] //Aqui seria um endpoint de editar/atualizar 
        public IActionResult Atualizar(int id, Assinatura assinatura) //Aqui e o comeco do metodo atualizar 
        {
            var assinaturaAtualizar = _repository.Atualizar(id, assinatura); //Vai criar uma variavel onde vai pegar o metodo atualizar do repository
            if (assinaturaAtualizar == null) return null; //Se o metodo retornar nulo ele vai gerar um erro
            return Ok(assinaturaAtualizar);//Se o metodo estiver funcionando ele vai mandar um ok
        }
        [HttpDelete("{id}")] //Endpoint de deletar
        public IActionResult Deletar(int id) //começo do metodo deletar 
        {
            var assinaturaDeletar = _repository.Deletar(id); //Aqui ele vai criar uma variavel onde ele vai pegar o metodo deletar do repository 
            if (assinaturaDeletar == null) return NotFound(); //Se a variavel acima retornar nulo ele vai gerar um erro
            return Ok(assinaturaDeletar);//Se o metodo estiver funcionando ele vai mandar um ok
        }

        [HttpGet("{id}")] //Endpoint de leitura 
        public IActionResult ListarPorId(int id) //Começo do metodo listar por id
        {
            var assinatura = _repository.ListarPorId(id); //Uma variavel onde ele vai pegar o metodo listar por id do repository
            if (assinatura == null) return NotFound(); //Se a variavela acima de nulo ele vai gerar um erro
            return Ok(assinatura);//Se o metodo estiver funcionando ele vai mandar um ok
        }
    }
}
