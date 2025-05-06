using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ILivro
    {
        List<Livro> ListaTodos();
        Livro BuscarPorId(int id);
        void Cadastrar(Livro livro);
        void Atualizar(int id, Livro livro);
        void Deletar(int id);
    }
}
