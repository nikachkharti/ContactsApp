
using ContactsApplication.API.Extensions;

namespace ContactsApplication.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddControllers();
            builder.AddOpenApi();
            builder.AddSwagger();
            builder.AddInfrastructureLayer();
            builder.AddApplicationLayer();

            var app = builder.Build();

            app.UseDataSeeder();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
