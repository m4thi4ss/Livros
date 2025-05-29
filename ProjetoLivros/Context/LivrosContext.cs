using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoLivros.Models;

namespace ProjetoLivros.Context
{
    public class LivrosContext : DbContext
    {
        //No context voce vai criar as tabelas e as tabelas tem que ser criada com o DbSet, qualquer API no context e criado a tabela com o codigo DbSet.   
        public DbSet<Usuario> Usarios { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }

        public LivrosContext(DbContextOptions<LivrosContext>options) : base(options) //Aqui ele vai ler tudo e vai passar para o DbContext para mostrar todas informacoes
          //Seria uma construtor esse
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Ele seria o metodo que vai configurar a string de conexao
        {
            //optionsBuilder.UseSqlServer("Data Source=NOTE46-S28;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");//Esse seria qual a string de conexao de banco de dados que vamos utilizar 
            optionsBuilder.UseSqlServer("Data Source=ALIEN_PURPLE\\SQLEXPRESS2;Initial Catalog=Livros;User Id=sa;Password=senha123;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//Aqui e a configuracao das tipos de atributos(string, int...), quantos caracteres...
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(
                // Representacao da Tabela
                entity =>
                {
                    // Configuro a Primary Key
                    entity.HasKey(u => u.UsuarioId);//Para informar que e uma PK

                    entity.Property(u => u.NomeCompleto) // Property ele seria para selecionar o que vai ser configurado na coluna, que seria o Nome Completo
                    .IsRequired() //Ele informa que e obrigatorio preencher esse campo
                    .HasMaxLength(150) //Max de caracteres
                    .IsUnicode(false); //Esse ele ta informando que nao vai querer o alfabeto de outros paises, so o do latim.

                    entity.Property(u => u.Email)
                    .IsRequired() //Ele informa que e obrigatorio preencher esse campo
                    .HasMaxLength(150)//Max de caracteres
                    .IsUnicode(false);//Esse ele ta informando que nao vai querer o alfabeto de outros paises, so o do latim.

                    entity.HasIndex(u => u.Email)//Esse precisa para informar que o e-mail seria unico, so pode ter um so no banco de dados e nao pode ter duplicidade
                    .IsUnique();

                    entity.Property(u => u.Telefone)
                    .HasMaxLength(15)//Max de caracteres
                    .IsUnicode(false);//Esse ele ta informando que nao vai querer o alfabeto de outros paises, so o do latim

                    entity.Property(u => u.DataCadastro)
                    .IsRequired();//Ele informa que e obrigatorio preencher esse campo

                    entity.Property(u => u.DataAtualizacao)
                    .IsRequired();//Ele informa que e obrigatorio preencher esse campo

                    entity.HasOne(u => u.TipoUsuario) //Aqui ta informando que tem uma chave estrageira que seria o usuario tem TipoUsuario
                    .WithMany(t => t.Usuarios) //E nesse ta avisando que que no TipoUsuario tem muitos Usuarios.
                    .HasForeignKey(u => u.TipoUsuarioId)//Ta informando que essa e uma chave estrageira dentro do Usuario
                    .OnDelete(DeleteBehavior.Cascade);//Aqui esta informando o que vai acontecer quando apagar um Tipo. Tem 3 tipos de Delete cascade: Se apagar um TipoUsuario ele vai apagar todos os usuarios. NoAction: Nao faz nada, mas ele nao deixa voce apagar o TipoUsuario. SetNull: Apagou algum Tipo, ele nao apaga os usuarios do tipo que foi apagado, mas ele da Null nos usuarios e o usuario fica considerado como se nao fosse nada mais continuar na tabela. 
                }

            );
            modelBuilder.Entity<TipoUsuario>(entity => //Toda tabela quando vai ser configurada no context ela comeca assim.
            {
                entity.HasKey(t => t.TipoUsuarioId);//Para informar que e uma PK

                //Configurando o restante das colunas da tabela
                entity.Property(t => t.DescricaoTipo)// Property ele seria para selecionar o que vai ser configurado na coluna, que seria o DescricaoTipo
                .IsRequired()//Ele informa que e obrigatorio preencher esse campo
                .HasMaxLength(100)//Max de caracteres
                .IsUnicode();//Esse ele ta informando que nao vai querer o alfabeto de outros paises, so o do latim.

                entity.HasIndex(t => t.DescricaoTipo)//Esse precisa para informar que o e-mail seria unico, so pode ter um so no banco de dados e nao pode ter duplicidade
                   .IsUnique();
            });
            modelBuilder.Entity<Livro>(entity =>
            {
                // Configuro a Primary Key
                entity.HasKey(l => l.LivroId);//Para informar que e uma PK

                entity.Property(l => l.Titulo)// Property ele seria para selecionar o que vai ser configurado na coluna, que seria o Nome Completo
                .IsRequired()//Ele informa que e obrigatorio preencher esse campo
                .HasMaxLength(200)//Max de caracteres
                .IsUnicode();//Esse ele ta informando que nao vai querer o alfabeto de outros paises, so o do latim.

                entity.Property(l => l.Autor)// Property ele seria para selecionar o que vai ser configurado na coluna, que seria o Nome Completo
                .IsRequired()//Ele informa que e obrigatorio preencher esse campo
                .HasMaxLength(200)//Max de caracteres
                .IsUnicode();//Esse ele ta informando que nao vai querer o alfabeto de outros paises, so o do latim.

                entity.Property(l => l.Descricao)// Property ele seria para selecionar o que vai ser configurado na coluna, que seria o Nome Completo
                .HasMaxLength(255)//Ele informa que e obrigatorio preencher esse campo
                .IsUnicode();//Esse ele ta informando que nao vai querer o alfabeto de outros paises, so o do latim.

                entity.Property(l => l.DataPublicacao)// Property ele seria para selecionar o que vai ser configurado na coluna, que seria o Nome Completo
                .IsRequired();//Ele informa que e obrigatorio preencher esse campo

                //RELACIONAMENTO
                //LIVRO - CATEGORIA
                //RELACIONAMENTO DE 1 PARA MUITOS (1-N)
                entity.HasOne(l => l.Categoria) //Aqui ta informando que tem uma chave estrageira que seria o usuario tem Categoria
                   .WithMany(c => c.Livros) //E nesse ta avisando que que nCategoria tem muitos Livros.
                   .HasForeignKey(l => l.CategoriaId)//Ta informando que essa e uma chave estrageira dentro do Usuario
                   .OnDelete(DeleteBehavior.Cascade);//Aqui esta informando o que vai acontecer quando apagar um Tipo. Tem 3 tipos de Delete cascade: Se apagar um TipoUsuario ele vai apagar todos os usuarios. NoAction: Nao faz nada, mas ele nao deixa voce apagar o TipoUsuario. SetNull: Apagou algum Tipo, ele nao apaga os usuarios do tipo que foi apagado, mas ele da Null nos usuarios e o usuario fica considerado como se nao fosse nada mais continuar na tabela. 
            });
            modelBuilder.Entity<Categoria>(entity =>
            {
                // Configuro a Primary Key
                entity.HasKey(c => c.CategoriaId);//Para informar que e uma PK

                entity.Property(c => c.NomeCategoria)// Property ele seria para selecionar o que vai ser configurado na coluna, que seria o Nome Completo
                .IsRequired()//Ele informa que e obrigatorio preencher esse campo
                .HasMaxLength(200)//Ele informa que e obrigatorio preencher esse campo
                .IsUnicode();//Esse ele ta informando que nao vai querer o alfabeto de outros paises, so o do latim.
            });
            modelBuilder.Entity<Assinatura>(entity =>
            {
                entity.HasKey(a => a.AssinaturaId);//Para informar que e uma PK

                entity.Property(a => a.Status)// Property ele seria para selecionar o que vai ser configurado na coluna, que seria o Nome Completo
                .IsRequired()//Ele informa que e obrigatorio preencher esse campo
                .HasMaxLength(200)//Ele informa que e obrigatorio preencher esse campo
                .IsUnicode();//Esse ele ta informando que nao vai querer o alfabeto de outros paises, so o do latim.

                entity.Property(a => a.DataInicio)// Property ele seria para selecionar o que vai ser configurado na coluna, que seria o Nome Completo
                .IsRequired();//Ele informa que e obrigatorio preencher esse campo

                entity.Property(a => a.DataFim)// Property ele seria para selecionar o que vai ser configurado na coluna, que seria o Nome Completo
                .IsRequired();//Ele informa que e obrigatorio preencher esse campo

                entity.HasOne(a => a.Usuario) //Aqui ta informando que tem uma chave estrageira que seria o usuario tem Usuario
                   .WithMany() //Aqui esta vazio por que no models na parte de usuario nao tem a list Assinatura e so vai ter o TipoUsuario, nao tem problema de nao ter so deixar vazio
                   .HasForeignKey(a => a.UsuarioId)//Ta informando que essa e uma chave estrageira dentro do Usuario
                   .OnDelete(DeleteBehavior.Cascade);//Aqui esta informando o que vai acontecer quando apagar um Tipo. Tem 3 tipos de Delete cascade: Se apagar um TipoUsuario ele vai apagar todos os usuarios. NoAction: Nao faz nada, mas ele nao deixa voce apagar o TipoUsuario. SetNull: Apagou algum Tipo, ele nao apaga os usuarios do tipo que foi apagado, mas ele da Null nos usuarios e o usuario fica considerado como se nao fosse nada mais continuar na tabela.
            });


        }   
    }
    
}
