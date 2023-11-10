using Microsoft.EntityFrameworkCore;
using WalletApp.API.Middlewares;
using WalletApp.Application;
using WalletApp.Application.Repositories;
using WalletApp.Application.Services;
using WalletApp.Infrastructure.DataAccess;
using WalletApp.Infrastructure.DbContexts;
using WalletApp.Infrastructure.Services;

namespace WalletApp.API.Extensions;

public static class ProgramExtensions
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IPointsService, PointsService>();
        builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
        builder.Services.AddDbContext<WalletDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("WalletDb")));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(ApplicationAssembly.GetAssembly()));

        return builder;
    }

    public static WebApplication UseMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.MigrateDatabase<WalletDbContext>();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

        return app;
    }

    public static IApplicationBuilder MigrateDatabase<TContext>(this IApplicationBuilder builder)
       where TContext : DbContext
    {
        using (var serviceScope = builder.ApplicationServices.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetService<TContext>();
            dbContext?.Database.Migrate();
        }

        return builder;
    }
}