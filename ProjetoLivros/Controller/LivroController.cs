using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase //Esse codigo e o codigo acima ele vem automatico quando você cria um controller de API vazio, se nao estiver com essas informações acima, você criou o controller errado.
    {
        private readonly ILivroRepository _repository; //Esse seria a leitura das informações no LivroRepository

        public LivroController(ILivroRepository repository) //Esse seria o construtor que e criado CTOR e apos ele ser criado colocar o _repository = repository;.
        {
            _repository = repository;
        }

        [HttpPost] //O Post seria para postagem, então ele seria usado como end point de Criar.
        public IActionResult Cadastrar(Livro livro) //Aqui ele esta sendo criado para fazer um metodo da interface em endpoint, que seria o de cadastrar
        {
            _repository.Cadastrar(livro); //Aqui seria a logica de programação de cadastrar na tabela livro
            return Ok(); //Aqui ele vai informar o codigo 200, pra caso esteja tudo certo.
        }
        [HttpGet] //O Get seria um endpoint de leitura, então toda lista criado tem que ser com o end point de leitura
        public IActionResult ListaTodos() //Aqui ele esta  informadno que vai ser criado um metodo de listar todas as informações da tabela livro;.
        {
            var livro = _repository.ListaTodos(); //Aqui ele ta criando uma variavel livro, onde ele vai passar no repository e vai entregar todas informações em formato de lista para o usuario 
            return Ok(livro); //Aqui ele vai retornar um o Json 200 para caso esteja tudo certo.
        }
        [HttpPut("{id}")] //Aqui seria um endpoint PUT que seria de atualizar.
        public IActionResult Atualizar(int id, Livro livroNovo) //Aqui ele vai criar uma metodologia de atualizar, onde vai ter o paramentro de um numero inteiro de id, onde vai pegar na tabela de Livro.
        {
            var livroAtualizado = _repository.Atualizar(id, livroNovo); //Aqui ele esta criando uma variavel, onde ele vai usar um metodo de atualizar, e ele vai fazer essa atualização com o id.

            if (livroAtualizado == null) return NotFound(); //Aqui seria um if, onde ele vai verificar na tabela Livro se o id e existente, se ele nao for existente ele vai retornar um erro.

            return Ok(livroAtualizado); //Aqui ele vai retornar o JSON 200, para caso a logica de programção esteja certa.
        }
        [HttpDelete("{id}")] // O delete ele e um endpoint de deletar.
        public IActionResult Deletar(int id) // Aqui ele vai criar o metodo no endpoint fazendo o delete.
        {
            var livroDeletada = _repository.Deletar(id); // Aqui ele esta criando uma variavel, para pegar uma informação pelo id na tabela,
            if (livroDeletada == null) return NotFound(); //Aqui caso nao ache o id na tabela Livro ele vai retornar um erro.
            return Ok(); //Aqui ele vai retornar o JSON 200 para caso a logica de programção esteja certa.
        }
        [HttpGet("{id}")] //Esse seria um EndPoint de leitura, onde ele vai pegar a informações lidas e vai transformar em lista que vai ser puxada por id.
        public IActionResult BuscarPorId(int id) // Aqui seria a criação da metodologia criada no repository.
        {
            var livro = _repository.BuscarPorId(id); //Aqui seria uma variavel, onde ele vai verificar as informações no _repository para verificar os ID do TipoUsuario
            if (livro == null) return NotFound(); // Aqui ele vai retornar um nulo, caso o id não seja encontrado.
            return Ok(livro); // Aqui ele vai retornar um JSON 200 caso a logica de certo 
        }
    }
}
