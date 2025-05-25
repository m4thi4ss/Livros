using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly LivrosContext _context;

        public TipoUsuarioRepository(LivrosContext context)
        {
            _context = context;
        }

        public TipoUsuario? Atualizar(int id, TipoUsuario tipoUsuario)
        {
            var tipoUsuarioAtualizar = _context.TiposUsuarios.FirstOrDefault(tp => tp.TipoUsuarioId == id);
            if (tipoUsuarioAtualizar == null) return null;

            tipoUsuarioAtualizar.DescricaoTipo = tipoUsuario.DescricaoTipo;

            _context.SaveChanges();

            return tipoUsuarioAtualizar;

        }

        public TipoUsuario BuscarPorId(int id)
        {
            var TipoUsuarioBuscar = _context.TiposUsuarios.FirstOrDefault(buscar => buscar.TipoUsuarioId == id);

            if (TipoUsuarioBuscar == null) return null;

            _context.SaveChanges();
            return TipoUsuarioBuscar;
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            _context.TiposUsuarios.Add(tipoUsuario);
            _context.SaveChanges();
        }

        public TipoUsuario? Deletar(int id)
        {
            var TipoUsuarioDeletar = _context.TiposUsuarios.Find(id);

            if (TipoUsuarioDeletar == null) return null;

            _context.SaveChanges();

            return TipoUsuarioDeletar;

        }

        public List<TipoUsuario> ListaTodos()
        {
            return _context.TiposUsuarios.ToList();
        }
    }
}
