
using GestionBiblioteca.Context;
using GestionBiblioteca.Interfaces;
using GestionBiblioteca.Models;
using GestionBiblioteca.Services;
using GestionBiblioteca.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GestionBiblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSqlServer<BibliotecaContext>(builder.Configuration.GetConnectionString("AppConnection"));

            builder.Services.AddScoped(typeof (IRepository<>),typeof(Repository<>));

            builder.Services.AddScoped<AutorServices>();
            builder.Services.AddScoped<LibroServices>();
            builder.Services.AddScoped<CategoriaServices>();
            builder.Services.AddScoped<UsuarioServices>();
            builder.Services.AddScoped<EncryptionHelper>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
