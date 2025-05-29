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
        //Injetando o repository
        private readonly IUsuarioRepository _repository; // Criar uma variavel para guardar a interface IAssinaturaRepository 

        public UsuarioController(IUsuarioRepository repository) //Esse seria o CTOR para ligar o repository com o controller
        {
            _repository = repository;
        }

        [HttpGet]//Aqui seria um endpoint de leitura
        public IActionResult ListaTodos() //Criando um metodo de leitura 
        {
            var usuario = _repository.ListaTodos(); //Aqui vai criar uma variavel onde vai entrar no repository para listar todos
            return Ok(usuario); //Se der tudo certo ele vai lançar o ok pra informar que deu tudo certo
        }

        [HttpPost] //O HttpPost ele seria um endpoint de cadastrar 
        public IActionResult Cadastrar(Usuario usuario) //Aqui esta começando a ser criado um metodo de cadastrar
        {
            _repository.Cadastrar(usuario); //Aqui ele vai entrar no repository e vai pegar o metodo de cadastrar
            return Ok(); //Aqui se o metodo acima funcionar ele vai retornar um ok
        }

        [HttpPut("{id}")] //O HttpPut seria o endpoint de editar/atualizar
        public IActionResult Atualizar(int id, Usuario usuarioNovo) //Seria o começo do metodo atualizar 
        {
            var usuarioAtualizar = _repository.Atualizar(id, usuarioNovo); //Aqui vai ser criado uma variavel onde ele vai entrar no repository e vai pegar o metodo atualizar

            if (usuarioAtualizar == null) return NotFound(); //Se a variavel acima retornar nulo, ele vai gerar o erro not found

            return Ok();//Aqui se o metodo acima funcionar ele vai retornar um ok
        }

        [HttpDelete("{id}")] //O HttpDelete ele um endpoint de deletar 
        public IActionResult Deletar(int id) //Aqui esta começando o metodo de deletar
        {
            var usuarioDeletar = _repository.Deletar(id); //Vai criar uma variavel onde vai pegar o metodo deletar do repository
            if (usuarioDeletar == null) return null; //Se a varivel acima ser nulo, ele vai retornar um erro 
            return Ok();//Aqui se o metodo acima funcionar ele vai retornar um ok
        }
        [HttpGet("{id}")] //O HttpGet seria o endpoint de leitura 
        public IActionResult BuscarPorId(int id) //Aqui seria o começo do metodo de buscar por id
        {
            var usuarioBuscar = _repository.BuscarPorId(id); //Aqui vai ser criado uma variavel que vai pegar o metodo do repository
            if (usuarioBuscar == null) return NotFound(); //Se a variavel acima der nulo, ele vai retornar um erro
            return Ok();//Aqui se o metodo acima funcionar ele vai retornar um ok
        }
    }
}
