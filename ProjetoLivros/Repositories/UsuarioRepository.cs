using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LivrosContext _context;



        public UsuarioRepository(LivrosContext context)
        {
            _context = context;
        }
        public Usuario? Atualizar(int id, Usuario usuario)
        {
            var usuarioAtualizar = _context.Usarios.FirstOrDefault(u => u.UsuarioId == id);

            if (usuarioAtualizar == null) return null;

            usuarioAtualizar.NomeCompleto = usuario.NomeCompleto;
            usuarioAtualizar.Email = usuario.Email;
            usuarioAtualizar.Senha = usuario.Senha;
            usuarioAtualizar.Telefone = usuario.Telefone;
            usuarioAtualizar.DataCadastro = usuario.DataCadastro;
            usuarioAtualizar.DataAtualizacao = usuario.DataAtualizacao;

            _context.SaveChanges();

            return usuarioAtualizar;
        }

        public Usuario? BuscarPorId(int id)
        {
            var usuarioBuscar = _context.Usarios.FirstOrDefault(buscar => buscar.UsuarioId == id);
            if (usuarioBuscar == null) return null;
            _context.SaveChanges();
            return usuarioBuscar;
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario? Deletar(int id)
        {
            var usuarioDeletar = _context.Usarios.Find(id);

            if (usuarioDeletar == null) return null;

            _context.SaveChanges();

            return usuarioDeletar;

        }

        public List<Usuario> ListaTodos()
        {
            return _context.Usarios.ToList();
        }
    }
}
