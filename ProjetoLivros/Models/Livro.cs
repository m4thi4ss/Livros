namespace ProjetoLivros.Models
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int CategoriaId { get; set; }//Foi criado por que o tipo usuario tem relacao com usuario, entao tem que colocar uma chave estrangeira
        public Categoria? Categoria { get; set; }//Esse foi criado para voce poder ver as informacoes do tipo usuario quando voce for listar so usuario
        //TipoUsuario? O "?" informa que aquele atributo nao e obrigatorio e pode ser nulo
    }
}
