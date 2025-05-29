using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repositories
{
    public class AssinaturaRepository : IAssinaturaRepository //Aqui ele ta herdando no repository a interface
    {
        private readonly LivrosContext _context; //Aqui ele vai fazer uma leitura na tabela Livros pelo context  

        public AssinaturaRepository(LivrosContext context) //Esse seria a inserção do construtor com o context
        {
            _context = context;
        }
        public Assinatura? Atualizar(int id, Assinatura assinatura) //Aqui seria o metodo de atualizar da interface 
        {
            var assinaturaAtualizar = _context.Assinaturas.FirstOrDefault(a => a.AssinaturaId == id); //Aqui e uma variavel onde ele vai entrar na tabela pelo context assinatura, usando o firstOrDefault pra verificar o id na tabela de assinatura

            if (assinaturaAtualizar == null) return null; //Aqui ele vai verificar se a variavel acima esta retornando nulo, se estiver ele vai gerar um erro

            //Aqui ele esta informando os dados que podem ser editados
            assinaturaAtualizar.UsuarioId = assinatura.UsuarioId; 
            assinaturaAtualizar.Status = assinatura.Status;
            assinaturaAtualizar.DataInicio = assinatura.DataInicio;
            assinaturaAtualizar.DataFim = assinatura.DataFim;

            _context.SaveChanges(); //Aqui ele está salvando e executando no banco de dados 
             
            return assinaturaAtualizar; //Aqui ele esta retornando a metodologia 
        }

        public void Cadastrar(Assinatura assinatura) //Aqui seria o metodo de cadastrar 
        {
            _context.Assinaturas.Add(assinatura); //Ele vai entrar na tabela assinatura pelo o context e vai cadastrar as informações

            _context.SaveChanges(); //Aqui ele esta retornando a metodologia 
        }

        public Assinatura? Deletar(int id) //Metodo de deletar 
        {
            var assinaturaDeletar = _context.Assinaturas.Find(id); //Criou uma variavel onde ele vai entrar na tabela assinatura pelo o context e vai usar o find para verificar os id
            if (assinaturaDeletar == null) return null; //Aqui ele esta informando se a variavel acima retornar nulo ele lançara um erro 
            _context.Assinaturas.Remove(assinaturaDeletar); //Aqui esta informando se a variavel der certo, ele vai remover a informação na tabela de assinatura
            _context.SaveChanges(); //Aqui ele esta retornando a metodologia
            return assinaturaDeletar; //Aqui ele esta retornando a metodologia 
        }

        public Assinatura? ListarPorId(int id) //Aqui ele vai criar um metodo listar por id 
        {
            return _context.Assinaturas.FirstOrDefault(a => a.AssinaturaId == id); //Aqui ele vai verificar a tabela assinatura pelo o context e vai usar o FirstOrDefault para buscar a informação pelo id se ele achar ele vai lançar a informação na tela 
            
        }

        public List<Assinatura> ListarTodos() //Aqui vai ser criado um metodo de listar todas as informações.
        {
            return _context.Assinaturas.ToList(); // Retorna uma lista de todas as assinaturas disponíveis
        }
    }
}
