
using Microsoft.EntityFrameworkCore;
using TechnicalTask.Data;
using TechnicalTask.repoServices;

namespace TechnicalTask
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
            builder.Services.AddDbContext<taskDbContext>(option =>
           option.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
           );
            builder.Services.AddCors(options =>
             options.AddPolicy("MyPolicy", corsPolicy =>
             {
                 corsPolicy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
             }

           ));
            builder.Services.AddScoped<IOrder, orderService>();
            builder.Services.AddScoped<IInvoice, invoiceService>();
            builder.Services.AddScoped<IExecution, executionService>();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors("MyPolicy");
            app.MapControllers();

            app.Run();
        }
    }
}
