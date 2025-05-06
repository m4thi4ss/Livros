using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ICategoria
    {
        List<Categoria> ListaTodos();
        Categoria BuscarPorId(int id);
        void Cadastrar(Categoria categoria);
        void Atualizar(int id, Categoria categoria);
        void Deletar(int id);
    }
}
