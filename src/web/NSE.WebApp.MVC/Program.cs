using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.RegisterServices();

var app = builder.Build();
// Chamar a configura��o de identidade
app.UseIdentityConfiguration();

// Configura��o do pipeline de middleware
app.UseMvcConfiguration();

app.Run();
