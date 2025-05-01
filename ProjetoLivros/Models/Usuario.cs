namespace ProjetoLivros.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int TipoUsuarioId { get; set; }//Foi criado por que o tipo usuario tem relacao com usuario, entao tem que colocar uma chave estrangeira
        public TipoUsuario? TipoUsuario { get; set; } //Esse foi criado para voce poder ver as informacoes do tipo usuario quando voce for listar so usuario
        //TipoUsuario? O "?" informa que aquele atributo nao e obrigatorio e pode ser nulo
    }
}
