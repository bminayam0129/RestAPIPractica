
using Microsoft.EntityFrameworkCore;
using RestAPIPractica.RestAPI.Data;

namespace RestAPIPractica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar DbContext con la cadena de conexión
            builder.Services.AddDbContext<RestAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PracticaRestAPI")));

            IMvcBuilder mvcBuilder = builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configurar el pipeline HTTP
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
