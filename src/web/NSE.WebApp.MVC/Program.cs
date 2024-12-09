using Microsoft.AspNetCore.Authentication.Cookies;
using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddControllersWithViews(); 
builder.Services.RegisterServices(); 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    { 
        options.LoginPath = "/Account/Login"; 
        options.LogoutPath = "/Account/Logout"; 
    });

var app = builder.Build();
// Chamar a configuração de identidade
app.UseIdentityConfiguration();

// Configuração do pipeline de middleware
app.UseMvcConfiguration();

app.Run();
