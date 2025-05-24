using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;


namespace ProjetoLivros.Repository
{
    public class CategoriaRepository : ICategoriaRepository //Aqui esta fazendo uma heranca para usar as informacoes da Categoria da interface, apos herdar voce implementa 
    {
        private readonly LivrosContext _context; // Criar uma variavel para guardar o context de da _context
        public CategoriaRepository(LivrosContext context) //Esse seria o construtor que e criado CTOR e apos ele ser criado colocar o _context = context;.
        {
            _context = context; //Esse seria a insercao do ontext no construtor, para completar
        }

        public List<Categoria> ListaTodos()//Aqui esta informando que vai ter uma funcao de Listar Todos 
        {
            return _context.Categorias.ToList();//Esse seria o codigo para gerar a lista da categoria quando solicitado. Ele esta retornando as informacoes da tabela que foi pega no context Categoria e essas informacoes serao mostradas como lista.
        }

        public void Cadastrar(Categoria categoria) //Aqui seria o metodo que foi pego da interface de cadastrar uma informcao na tabela Categoria 
        {
            _context.Categorias.Add(categoria);//Aqui esta informando que ele vai na tabela Categoria no context e vai adicionar uma informacao 

            _context.SaveChanges(); // Aqui ele esta salvando no banco de dados esse metodo.
        }

        Categoria? ICategoriaRepository.Atualizar(int id, Categoria categoria)//Aqui seria o metodo que foi pego da interface de atualizar uma informacao na tabela Categoria
        {
            // 1 - Procuro quem atualizar 
            var categoriaEcontrado = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id); // Esse ele esta buscando na tabela Categoria no context se tem o ID informado, e o FirstOrDefault ele e a mesma coisa que o Find so que no Find so pode ser usado na primaria e o FirstOrDefault pode ser usado para qualquer campo.
            // 2 - Se nao acho, retorno nulo
            if (categoriaEcontrado == null) return null;//Aqui esta informando se ele nao achar a informacao ele vai dar um erro jsson
            // 3 - Se acho eu atualizo as informacoes 
            categoriaEcontrado.NomeCategoria = categoria.NomeCategoria; //Aqui esta informando que so pode ser atualizado na tabela Categoria NomeCategoria.
            _context.SaveChanges();// Aqui ele esta salvando no banco de dados esse metodo.

            return categoriaEcontrado;//Tem o return para a retornar o metodo delete se achar a informacao e se nao achar uma informacao ele vai retornar o NULL

        }

        Categoria? ICategoriaRepository.Deletar(int id) //Aqui seria o metodo que foi pego da interface e deletar uma informacao na tabela Categoria
        {
            // 1 - Procuro a informacao que eu quero apagar 
            var categoria = _context.Categorias.Find(id); //Esse codigo seria uma busca na tabela categoria no context a informacao que eu quero apagar pelo ID, por isso que usei o Find ponde busco pelo ID que seria a chave primaria onde ele so pode ser usado se for chave primaria 
            // 2 - Se nao achei, retorno nulo
            if(categoria == null) return null; //Aqui esta informando se ele nao achar a informacao ele vai dar um erro jsson
            // 3 - Se achar ele vai deletar
            _context.Categorias.Remove(categoria); //E esse seria se ele achar a informacao ele vai deletar a mesma 
            _context.SaveChanges();// Aqui ele esta salvando no banco de dados esse metodo.

            return categoria;//Tem o return para a retornar o metodo delete se achar a informacao e se nao achar uma informacao ele vai retornar o NULL

            
        }

        public Categoria? ListaPorId(int id) //Esse seria o metodo que foi pego da interface de listar uma informacao na tabela Categoria
        {
            return _context.Categorias //Esse seria o codigo para gerar a lista da categoria quando solicitado. Ele esta retornando as informacoes da tabela que foi pega no context Categoria e essas informacoes serao mostradas como lista.
                             .FirstOrDefault(c => c.CategoriaId == id); ; //Aqui ele esta buscando na tabela Categoria no context se tem o ID informado, e o FirstOrDefault ele e a mesma coisa que o Find so que o FirstOrDefault pode ser usado para qualquer campo.
        }
    }
}
