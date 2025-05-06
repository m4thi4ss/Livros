namespace ProjetoLivros.Models
{
    public class TipoUsuario
    {
        //Aqui sao criadas as tabelas no Banco de dados
        public int TipoUsuarioId { get; set; }
        public int DescricaoTipo { get; set; }
        public List<Usuario> Usuarios { get; set; } = new();//Esse seria igual o Tipo usuario aparecer na lista de usuario, porem tem varios usuarios para cada tipo de usuario e por esse motivo foi colocado list e nao colocou de uma vez o usuario, para aparecer em lista os usarios.
    }
}
