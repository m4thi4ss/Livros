namespace ProjetoLivros.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public int NomeCategoria { get; set; }
        public List<Livro> Livros { get; set; }//Esse seria igual o Tipo usuario aparecer na lista de usuario, porem tem varios usuarios para cada tipo de usuario e por esse motivo foi colocado list e nao colocou de uma vez o usuario, para aparecer em lista os usarios.
    }
}
