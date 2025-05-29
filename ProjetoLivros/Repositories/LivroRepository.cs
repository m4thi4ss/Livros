using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    public class LivroRepository : ILivroRepository //Aqui ele esta herdando metodologia da Interface Livros
    {
        private readonly LivrosContext _context; // Criar uma variavel para guardar o context de da _context
        public LivroRepository(LivrosContext context) //Esse seria o construtor que e criado CTOR e apos ele ser criado colocar o _context = context;.
        {
            _context = context; //Esse seria a insercao do ontext no construtor, para completar
        }
        public Livro? Atualizar(int id, Livro livro) //Aqui ele esta criando um void de atualizar sendo uma metodologia de editar puxada da interface
        {
            // 1 - Procuro quem atualizar 
            var livroEncontrado = _context.Livros.FirstOrDefault(l => l.LivroId == id); // Esse ele esta buscando na tabela Livro no context se tem o ID informado, e o FirstOrDefault ele e a mesma coisa que o Find so que no Find so pode ser usado na primaria e o FirstOrDefault pode ser usado para qualquer campo.

            // 2 - Se nao acho, retorno nulo
            if (livroEncontrado == null) return null; //Aqui ele vai verificar se a variavel acima esta retornando nulo, se estiver ele vai gerar um erro

            // 3 - Se acho eu atualizo as informacoes
            livroEncontrado.Titulo = livro.Titulo; //Aqui esta informando que so pode ser atualizado na tabela Livro NomeLivro.
            livroEncontrado.Autor = livro.Autor;//Aqui esta informando que so pode ser atualizado na tabela Livro Autor.
            livroEncontrado.Descricao = livro.Descricao;//Aqui esta informando que so pode ser atualizado na tabela Livro Descrição
            livroEncontrado.DataPublicacao = livro.DataPublicacao;//Aqui esta informando que so pode ser atualizado na tabela Livro DataPublicacao
            livroEncontrado.CategoriaId = livro.CategoriaId;//Aqui esta informando que so pode ser atualizado na tabela livro CategoriaId

            _context.SaveChanges(); //Aqui esta informando que vai salvar no banco de dados

            return livroEncontrado; //Aqui ele vai retornar a metodologia que foi feito acima


        }

        public Livro BuscarPorId(int id) //Aqui esta informando que vai ser criado uma metodologia de buscar por Id
        {
            var livro = _context.Livros.FirstOrDefault(l => l.LivroId == id); //Esse seria o codigo para gerar a lista do livro quando solicitado. Ele esta retornando as informacoes da tabela que foi pega no context Livro e essas informacoes serao mostradas como lista.
            if (livro == null) return null; //Aqui ele vai verificar se a variavel acima esta retornando nulo, se estiver ele vai gerar um erro
            _context.SaveChanges(); // Aqui ele esta salvando no banco de dados esse metodo.
            return livro; // Aqui ele vai retornar se achar ele vai retornar a lista do ID solicitado e se nao achar o id ele vai dar 404
        }

        public void Cadastrar(Livro livro) // Aqui ele vai ter uma metodologia que pega da interface um cadastrar.
        {
            _context.Livros.Add(livro); //Aqui esta informando que ele vai na tabela Livro no context e vai adicionar uma informacao
            _context.SaveChanges(); // Aqui ele esta salvando no banco de dados esse metodo.
        }

        Livro? ILivroRepository.Deletar(int id)
        {
            // 1 - Primeiro procuro a informação que eu quero procurar
            var livro = _context.Livros.Find(id); //Esse codigo seria uma busca na tabela livro no context a informacao que eu quero apagar pelo ID, por isso que usei o Find ponde busco pelo ID que seria a chave primaria onde ele so pode ser usado se for chave primaria

            //2 - Se eu não achar vou retornar Nulo
            if (livro == null) return null; //Aqui ele vai verificar se a variavel acima esta retornando nulo, se estiver ele vai gerar um erro

            //3 - Se ele achar ele vai deletar 
            _context.Livros.Remove(livro); //Aqui se ele achar, ele vai remover as informação do livro  

            //4 - Se ele achar o id e remover, ele vai ter que salvar no banco de dados 
            _context.SaveChanges(true); //Aqui ele vai salvar as informações e vai executar no banco de dados

            //5 - Aqui seria o retorno de todo codigo
            return livro;

        }

        public List<Livro> ListaTodos() //Aqui ele esta fazendo uma metodologia que vem da interface de listar todos os intens salvos no livro.
        {
            return _context.Livros.ToList(); // Aqui ele vai retornar uma lista que vai ser puxado no _context a tabela livros.
        }
    }
}
