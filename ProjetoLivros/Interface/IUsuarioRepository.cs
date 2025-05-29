using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListaTodos(); //Esse seria o metodo de listar todos
        Usuario? BuscarPorId(int id); //Esse seria o metodo de buscar por id 
        void Cadastrar(Usuario usuario); //Esse seria o metodo de cadastrar 
        Usuario? Atualizar(int id, Usuario usuario); //Esse seria o metodo de atualizar
        Usuario? Deletar(int id); //Esse seria o metodo de deletar
    }
}
