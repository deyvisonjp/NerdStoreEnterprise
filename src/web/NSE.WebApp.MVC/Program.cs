using Microsoft.AspNetCore.Authentication.Cookies;
using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner
builder.Services.AddControllersWithViews(); 
builder.Services.RegisterServices(); 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    { 
        options.LoginPath = "/Account/Login"; 
        options.LogoutPath = "/Account/Logout"; 
    });

var app = builder.Build();
// Chamar a configura��o de identidade
app.UseIdentityConfiguration();

// Configura��o do pipeline de middleware
app.UseMvcConfiguration();

app.Run();
