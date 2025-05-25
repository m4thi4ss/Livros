using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListaTodos();
        TipoUsuario? BuscarPorId(int id);
        void Cadastrar(TipoUsuario tipoUsuario);
        TipoUsuario? Atualizar(int id, TipoUsuario tipoUsuario);
        TipoUsuario? Deletar(int id);
    }
}
