using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.RegisterServices();

var app = builder.Build();
// Chamar a configuração de identidade
app.UseIdentityConfiguration();

// Configuração do pipeline de middleware
app.UseMvcConfiguration();

app.Run();
