using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();//Avisa que a aplicacao usa controllers

builder.Services.AddSwaggerGen();// Adiciono o Gerador de Swagger que seria app de teste da API


builder.Services.AddDbContext<LivrosContext>();//Essa linha seria para a migracao do banco de dados
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

var app = builder.Build();//Juntamente com essa

app.MapControllers();//Avisa para o .NET que eu tenho Controladores, ela importante para que as coisas do c# chegue nela

app.UseSwagger();//Aqui esta informando para o C# disponibilizar o Swagger para que possamos usar
app.UseSwaggerUI();//Aqui esta informando para o C# disponibilizar o Swagger para que possamos usar

app.Run();
