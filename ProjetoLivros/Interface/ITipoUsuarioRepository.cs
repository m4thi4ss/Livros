using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListaTodos();  //Esse seria um metodo de listar todas as informações
        TipoUsuario? BuscarPorId(int id); //Esse seria um metodo de Buscar Por Id
        void Cadastrar(TipoUsuario tipoUsuario); //Esse seria um metodo de cadastrar
        TipoUsuario? Atualizar(int id, TipoUsuario tipoUsuario); //Esse seria um metodo de atualizar
        TipoUsuario? Deletar(int id); //Esse seria um metodo de deletar
    }
}
