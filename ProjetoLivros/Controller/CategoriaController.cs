using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase//Aqui ele esta informando que ta herdando as informacoes da interface Categoria
    {
        //Injetar o Repository
        private readonly ICategoriaRepository _repository;  // Criar uma variavel para guardar a interface ICategoriaRepository 

        public CategoriaController(ICategoriaRepository repository) //Esse seria o construtor que e criado CTOR e apos ele ser criado colocar o _context = context;.
        {
            _repository = repository;
        }

        [HttpGet]//Esse seria o Endpoint de leitura de dados, utilizado para os test de funcionalidade 
        public IActionResult ListarTodos() //Aqui ele ta criando dentro do controller o metodo listar todos
        {
            var categoria = _repository.ListaTodos(); //Aqui ta criando uma variavel para buscar todos as informacoes no repository da categoria

            return Ok(categoria); //Aqui seria o returno do que foi pedido, para retornar a lista 
        }

        [HttpPost] //Esse seria o Endpoint de postagem, ele vai postar algo na tabela e vai ser utilizado para verificar se esta tudo certo.
        public IActionResult Cadastrar(Categoria categoria) //Aqui ele esta criando dentro do controller o metodo de Cadastrar
        {
            _repository.Cadastrar(categoria); //Aqui ele esta informando que sera cadastrado algo no repository
            return Ok(); //E quando for cadastrado ele vai dar um retorno 200
        }

        [HttpPut("{id}")]//Esse seria o endpoint de edicao.
        public IActionResult Atualizar(int id, Categoria categoriaNova) //Aqui seria a metodologia de ID para fazer o teste no swagger ou no postman 
        {
            var categoriaAtualizada = _repository.Atualizar(id, categoriaNova); //Aqui ele vai procurar o ID que foi solicitado 

            if (categoriaAtualizada == null) return NotFound();// Aqui se ele nao achar o id ele vai dar erro 400

            return Ok(categoriaAtualizada); // Aqui ele vai retornar se achar ele vai atualizar o ID solicitado e se nao achar o id ele vai dar 404
        }

        [HttpDelete("{id}")]//Aqui seria o Endpoint de delete 
        public IActionResult Deletar(int id) //Aqui seria a metodologia de ID para fazer o teste no swagger ou no postman 
        {
            var categoriaDeletada = _repository.Deletar(id); //Aqui ele vai procurar o ID que foi solicitado 

            if (categoriaDeletada == null) return NotFound(); // Aqui se ele nao achar o id ele vai dar erro 400

            return Ok(categoriaDeletada); //Aqui ele vai retornar se achar ele vai deletar o ID solicitado e se nao achar o ID ele vai dar o erro 400
        }
        [HttpGet("{id}")] //Esse seria o Endpoint de leitura de dados, utilizado para os test de funcionalidade 
        public IActionResult ListaPorId(int id) //Aqui seria a metodologia de ID para fazer o teste no swagger ou no postman
        {
            var categoria = _repository.ListaPorId(id); //Aqui ele vai procurar o ID 
            if (categoria == null) return NotFound(); //Aqui ele vai verificar se o ID e existente se nao for ele vai voltar nulo
            return Ok(categoria); // Aqui ele vai retornar se achar ele vai retornar a lista do ID solicitado e se nao achar o id ele vai dar 404
        }
    }
}
