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
        //Injetando o repository
        private readonly ITipoUsuarioRepository _repository; // Criar uma variavel para guardar a interface IAssinaturaRepository 

        public TipoUsuarioController(ITipoUsuarioRepository repository) //Esse seria o Ctor onde pega os metodos do repository
        {
            _repository = repository;
        }
        [HttpGet] //O HttpGet e um endpoint de leitura
        public IActionResult ListaTodos() //Esse seria o metodo de listar todos
        {
            var tipoUsuario = _repository.ListaTodos(); //Aqui vai ser criado uma variavel onde ele vai listar todos
            return Ok(tipoUsuario); //Aqui ele vai retornar o metodo da variavel acima 
        }

        [HttpPost] //O HttpPost ele seria um de postagem/cadastrar
        public IActionResult Cadastrar(TipoUsuario tipoUsuario) //Aqui seria um metodo de cadastrar 
        {
            _repository.Cadastrar(tipoUsuario); //Aqui ele esta informando que sera feito um cadastro no tipo de usuario
            return Ok(); //Aqui ele vai retornar o metodo acima 
        }
        [HttpPut("{id}")] //O HttpPut seria um endpoint de de edição/Atualizar
        public IActionResult Atualizar(int id, TipoUsuario tipoUsuarioNovo) //Aqui seria o metodo de atualizar
        {
            var tipoUsuarioAtualizado = _repository.Atualizar(id, tipoUsuarioNovo); //Essa variaveç foi criada com intuito de editar/atualizar as informações do id que foi passado

            if (tipoUsuarioAtualizado == null) return NotFound(); //Se a variavel de cima retornar nulo, ela vai gerar um erro

            return Ok(); //Se a variavel pesquiser o id e if verificar que realmente tem esse, ela vai retornar o resultado do metodo
        }
        [HttpDelete("{id}")] //O HttpDelete ele seria um endpoint de deletar
        public IActionResult Deletar(int id) //Aqui esta criando o metodo deletar e os paramentros 
        {
            var tipoUsuarioDeletado = _repository.Deletar(id); //Aqui ele vai criar uma variavel onde ele vai nos metodos do repository e vai pegar ele, buscando as informações com um find buscando id
            if (tipoUsuarioDeletado == null) return NotFound(); //Se variavel for nula, ela vai retornar um erro
            return Ok(tipoUsuarioDeletado); //Se der tudo certo na variavel vai retornar o ok e json
        }
        [HttpGet("{id}")] //O HttpGet e um endpoint de leitura
        public IActionResult BuscarPorId(int id) //Esse seria um metodo buscar por id
        {
            var tipoUsuario = _repository.BuscarPorId(id); //vai criar uma varivel, onde vai entrar no repository e vai buscar o metodo buscar por id 
            if (tipoUsuario == null) return NotFound(); //Se a variavel acima der erro, ele vai lançar um erro
            return Ok(tipoUsuario); //Se der tudo certo ele vai lançar que deu certo ok
        }
    }
}
