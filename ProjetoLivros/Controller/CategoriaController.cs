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
            return Ok(); //E quando for cadastrado ele vai dar um retorno OK
        }
    }
}
