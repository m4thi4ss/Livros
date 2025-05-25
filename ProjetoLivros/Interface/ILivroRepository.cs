using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ILivroRepository
    {
        List<Livro> ListaTodos(); //Esse seria para listar todos os livros disponiveis
        Livro? BuscarPorId(int id); //Esse seria para listar um livro especifico, passando o id dela como parametro
        void Cadastrar(Livro livro); //Esse ele vai receber um livro novo
        Livro? Atualizar(int id, Livro livro); //Aqui ele esta informando que vai atualizar uma informacao ja existente //Na Livro? esta informando que se nao achar a informacao que vai atualizar ele vai lancar o erro, ai nem precisa colocar no repository.
        Livro? Deletar(int id); //Aqui e um metodo que vai de Deletar uma informacao existente
    }
}
