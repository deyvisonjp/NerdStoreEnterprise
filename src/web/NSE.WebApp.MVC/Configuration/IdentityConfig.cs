﻿using Microsoft.AspNetCore.Authentication.Cookies;

namespace NSE.WebApp.MVC.Configuration;

public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                // Não logado, encaminha para login
                options.LoginPath = "/login";
                // Encaminha se não tiver permissão
                options.AccessDeniedPath = "/acesso-negado";
            });
    }

    public static void UseIdentityConfiguration(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}