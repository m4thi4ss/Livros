using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface IAssinaturaRepository  
    {
        List<Assinatura> ListarTodos(); // Lista todas as assinaturas disponíveis
        Assinatura? ListarPorId(int id); // Lista uma assinatura específica pelo ID
        void Cadastrar(Assinatura assinatura); // Cadastra uma nova assinatura
        Assinatura? Atualizar(int id, Assinatura assinatura); // Atualiza uma assinatura existente pelo ID
        Assinatura? Deletar(int id); // Deleta uma assinatura existente pelo ID
    }
}
