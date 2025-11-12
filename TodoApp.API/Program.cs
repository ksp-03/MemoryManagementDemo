
using TodoApp.BLL;
using TodoApp.DAL;

namespace TodoApp.API
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
            builder.Services.AddScoped<ITodoAppRepository, SqlAdoTodoRepository>();
            builder.Services.AddScoped<ITodoAppService, TodoAppService>();
            builder.Services.AddScoped<IUnitOfWork, UnitofWork>();
            builder.Services.AddSingleton(new SqlConnectionFactory(
                builder.Configuration.GetConnectionString("TodoDb")));
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
