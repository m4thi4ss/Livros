using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repositories
{
    public class AssinaturaRepository : IAssinaturaRepository
    {
        private readonly LivrosContext _context;

        public AssinaturaRepository(LivrosContext context)
        {
            _context = context;
        }
        public Assinatura? Atualizar(int id, Assinatura assinatura)
        {
            var assinaturaAtualizar = _context.Assinaturas.FirstOrDefault(a => a.AssinaturaId == id);

            if (assinaturaAtualizar == null) return null;

            assinaturaAtualizar.UsuarioId = assinatura.UsuarioId;
            assinaturaAtualizar.Status = assinatura.Status;
            assinaturaAtualizar.DataInicio = assinatura.DataInicio;
            assinaturaAtualizar.DataFim = assinatura.DataFim;

            _context.SaveChanges();

            return assinaturaAtualizar;
        }

        public void Cadastrar(Assinatura assinatura)
        {
            _context.Assinaturas.Add(assinatura);

            _context.SaveChanges();
        }

        public Assinatura? Deletar(int id)
        {
            var assinaturaDeletar = _context.Assinaturas.Find();
            if (assinaturaDeletar == null) return null;
            _context.Assinaturas.Remove(assinaturaDeletar);
            _context.SaveChanges();
            return assinaturaDeletar;
        }

        public Assinatura? ListarPorId(int id)
        {
            return _context.Assinaturas.FirstOrDefault(a => a.AssinaturaId == id);
            
        }

        public List<Assinatura> ListarTodos()
        {
            return _context.Assinaturas.ToList(); // Retorna uma lista de todas as assinaturas disponíveis
        }
    }
}
