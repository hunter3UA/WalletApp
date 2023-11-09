using WalletApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();
app.UseMiddlewares();
