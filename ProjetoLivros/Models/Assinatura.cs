namespace ProjetoLivros.Models
{
    public class Assinatura
    {
        //Aqui sao criadas as tabelas no Banco de dados
        public int AssinaturaId { get; set; }
        public string Status { get; set; } //
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
