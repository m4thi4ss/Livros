using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    public class UsuarioRepository : IUsuarioRepository //Aqui ele esta herdando da interface os metodos
    {
        private readonly LivrosContext _context; //Aqui ele basicamente vai fazer uma leitura na tabela Livros no context



        public UsuarioRepository(LivrosContext context) //Esse seria o CTOR que pega o context no banco de dados 
        {
            _context = context; //Esse seria a insercao do ontext no construtor, para completar
        }
        public Usuario? Atualizar(int id, Usuario usuario) //Aqui estou criando a metodo de atualizar, onde ele vai pegar na tabela Usuario o numero inteiro que seria o id para atualizar/editar 
        {
            var usuarioAtualizar = _context.Usarios.FirstOrDefault(u => u.UsuarioId == id); //Aqui seria uma variavel onde vai verificar as informações na tabela usuario do context no banco de dados. Onde vai ter um FirstOrDefault com um parametro que vaiverificar se aquele id e igual ou maior na tabela de id no usuario

            if (usuarioAtualizar == null) return null; //Aqui ele vai verificar se o id informado pelo usuario, se o resultado de nulo ele vai gerar um erro 

            usuarioAtualizar.NomeCompleto = usuario.NomeCompleto; //Aqui ele vai poder editar/atualizar essa tabela informada
            usuarioAtualizar.Email = usuario.Email; //Aqui ele vai poder editar/atualizar essa tabela informada
            usuarioAtualizar.Senha = usuario.Senha; //Aqui ele vai poder editar/atualizar essa tabela informada
            usuarioAtualizar.Telefone = usuario.Telefone; //Aqui ele vai poder editar/atualizar essa tabela informada
            usuarioAtualizar.DataCadastro = usuario.DataCadastro; //Aqui ele vai poder editar/atualizar essa tabela informada
            usuarioAtualizar.DataAtualizacao = usuario.DataAtualizacao; //Aqui ele vai poder editar/atualizar essa tabela informada

            _context.SaveChanges(); //Aqui ele vai executar e salvar as informações no banco de dados.

            return usuarioAtualizar; //Aqui ele vai retornar se der certo o 200 se der errado 400 ou 500
        }

        public Usuario? BuscarPorId(int id) //Aqui ele vai criar um metodo da interface de buscar por id, buscando pelo numero inteiro que seria o id
        {
            var usuarioBuscar = _context.Usarios.FirstOrDefault(buscar => buscar.UsuarioId == id); //Ele vai criar uma variavel onde ele vai entrar pelo context na tabela usuario e vai criar um parametro com o firstOrDefault que vai ser o buscar, onde ele vai verificar o id que foi informado pelo usuario
            if (usuarioBuscar == null) return null; //Aqui seria um if onde ele vai verificar se o id informado da resultado nulo, se sim ele vai retornar um erro.
            _context.SaveChanges(); //Aqui ele vai executar e salvar no banco de dados.
            return usuarioBuscar; //Aqui ele vai retornar se der certo o 200 se der errado 400 ou 500
        }

        public void Cadastrar(Usuario usuario) // Aqui seria um metodo da interface onde ele vai cadastrar um usuario na tabela usuario
        {
            _context.Usarios.Add(usuario); //Aqui ele vai entrar na tabela usuario pelo context e vai adicionar o usuario 
            _context.SaveChanges();//Aqui ele vai executar e salvar no banco de dados.
        }

        public Usuario? Deletar(int id) //Esse seria um metodo da interface onde ele vai deletar um usuario na tabela
        {
            var usuarioDeletar = _context.Usarios.Find(id); //ele vai criar uma varivael para entrar na tabela usuario no banco de dados pelo context, e vai usar o find com o parametro id 

            if (usuarioDeletar == null) return null; //O if ele vai analisar se o id informado tem na coluna de id na tabela usuario no banco de dados, se o resultado for nulo ele vai gerar um erro 

            _context.SaveChanges(); //Aqui ele vai salvar e executar no banco de dados esse metodo

            return usuarioDeletar; //Aqui ele vai executar e salvar no banco de dados.

        }

        public List<Usuario> ListaTodos() //Aqui seria um metodo de listar todas informações do usuario.
        {
            return _context.Usarios.ToList();//Aqui ele vai entrar na tabela context usuario e vai retornar uma lista com todas informações da tabela usuario.
        }
    }
}
