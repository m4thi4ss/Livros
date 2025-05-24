namespace ProjetoLivros.Models
{
    public class Categoria
    {
        //Aqui sao criadas as tabelas no Banco de dados
        public int CategoriaId { get; set; } //Esse seria o ID da Categoria
        public int NomeCategoria { get; set; } //Esse seria o Nome da Categoria
        public List<Livro> Livros { get; set; }//Na hora de listar a Categoria ele vai mostrar as informacoes do Livro tambem.
    }
}
