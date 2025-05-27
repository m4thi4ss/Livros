using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository // Interface para o repositório de TipoUsuario
    {
        private readonly LivrosContext _context; // Contexto do banco de dados LivrosContext

        public TipoUsuarioRepository(LivrosContext context) // Construtor que recebe o contexto do banco de dados
        {
            _context = context; //Esse seria a insercao do ontext no construtor, para completar
        }

        public TipoUsuario? Atualizar(int id, TipoUsuario tipoUsuario) //Esse seria o método de atualizar no repository, onde ele se comunica com a interface e faz a logica de programação para o funcionamento do metodo atualizar
        {
            var tipoUsuarioAtualizar = _context.TiposUsuarios.FirstOrDefault(tp => tp.TipoUsuarioId == id); //Esta sendo criado uma variavel, onde ele vai pegar as informações em forma de lista no context, onde ele coloca o FirstOrDefault onde ele cria um parametro, onde pega o tp e verifica se o id informado existe na tabela do context onde fica os id.
            if (tipoUsuarioAtualizar == null) return null; //Aqui esta sendo que criado um if, onde ele vai verificar se o Id não for encontrado que seria nulo, ele vai retornar um erro.

            tipoUsuarioAtualizar.DescricaoTipo = tipoUsuario.DescricaoTipo;//Aqui esta informando que pode ser atualizado na tabela TipoUsuario a Descricao do Tipo de Usuario

            _context.SaveChanges(); //Aqui está informando que assim que for atualizado ele vai executar e salvar no banco de dados.

            return tipoUsuarioAtualizar; //Aqui ele vai retornar se deu certo com 200 e se deu errado 400 ou 500

        }

        public TipoUsuario BuscarPorId(int id) //Aqui seria uma metodologia de BuscarPorId, onde ele vai buscar pelo numero inteiro que seria o id 
        {
            var TipoUsuarioBuscar = _context.TiposUsuarios.FirstOrDefault(buscar => buscar.TipoUsuarioId == id); //Criei uma variavel onde ele vai fazer a leitura da tabela TipoUsuario e vai fazer um FisrtOrDefault e cria um parametro onde o buscar seria o id informado pelo usuario, para verificar se o Id que foi informado tem na tabela.

            if (TipoUsuarioBuscar == null) return null; //Aqui seria o if, onde ele vai verificar se o id informado da um resultado nulo, se ele retornar nulo ele vai gerar um erro.

            _context.SaveChanges(); //Aqui ele vai executar e salvar no banco de dados.
            return TipoUsuarioBuscar; //Aqui ele vai retornar se deu certo com 200 e se deu errado 400 ou 500
        }

        public void Cadastrar(TipoUsuario tipoUsuario) //Esse seria o começo da criação da metodologia cadastrar
        {
            _context.TiposUsuarios.Add(tipoUsuario); //Aqui ele vai entrar na pasta _context e vai criar um tipo de usuario
            _context.SaveChanges(); //Esse ele vai executar e salvar no banco de dados.
        }

        public TipoUsuario? Deletar(int id) //Aqui esta sendo criado uma metodologia deletar, onde ele vai procurar pelo numero inteiro que seria o id
        {
            var TipoUsuarioDeletar = _context.TiposUsuarios.Find(id); //Aqui ele ta criando uma variavel onde ele vai passar pela tabela de tipo usuario no context e vai verificar os id.

            if (TipoUsuarioDeletar == null) return null; //Aqui seria um if onde ele vai verificar se o id informado pelo usuario vai retornar nulo, se retornar nulo ele vai dar um erro.

            _context.SaveChanges(); //Aqui se der tudo certo na metodologia, ele vai executar e salvar no banco de dados.

            return TipoUsuarioDeletar; //Aqui ele vai retornar se deu certo com 200 e se deu errado 400 ou 500

        }

        public List<TipoUsuario> ListaTodos() //Aqui seria um metodo de listar todas informações do tipousuario.
        {
            return _context.TiposUsuarios.ToList(); //Aqui ele vai entrar na tabela context tipousuario e vai retornar uma lista com todas informações da tabela tipo usuario.
        }
    }
}
