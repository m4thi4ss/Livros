using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListaTodos();
        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario usuario);
        void Atualizar(int id, Usuario usuario);
        void Deletar(int id);
    }
}
