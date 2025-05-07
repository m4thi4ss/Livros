using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ICategoriaRepository
    {
        List<Categoria> ListaTodos();//Esse seria para listar todos as categorias disponiveis
        void Cadastrar(Categoria categoria); //Esse ele vai receber uma categoria nova 
        Categoria? Atualizar(int id, Categoria categoria); //Aqui ele esta informando que vai atualizar uma informacao ja existente //Na Categoria? esta informando que se nao achar a informacao que vai atualizar ele vai lancar o erro, ai nem precisa colocar no repository.
        Categoria? Deletar(int id);//Aqui e um metodo que vai de Deletar uma informacao existente 
    }
}
