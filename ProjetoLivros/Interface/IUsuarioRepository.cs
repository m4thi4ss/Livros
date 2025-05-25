using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListaTodos();
        Usuario? BuscarPorId(int id);
        void Cadastrar(Usuario usuario);
        Usuario? Atualizar(int id, Usuario usuario);
        Usuario? Deletar(int id);
    }
}
