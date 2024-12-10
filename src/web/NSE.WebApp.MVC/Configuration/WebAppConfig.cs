using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NSE.WebApp.MVC.Extensions;

namespace NSE.WebApp.MVC.Configuration;

public static class WebAppConfig
{
    public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();

        // Configuração de proteção de dados
        services.AddDataProtection()
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"/var/data_protection_keys/"))
                .SetApplicationName("DevStoreEnterprise");

        // Configuração para encaminhar cabeçalhos em ambientes por trás de proxy reverso
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });

        // Configuração de AppSettings
        //services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

        // Health Check (exemplo de implementação)
        services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy()); // Verificação básica de saúde.
    }

    public static void UseMvcConfiguration(this WebApplication app)
    {
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseDeveloperExceptionPage();
        //} else
        //{
        //    app.UseExceptionHandler("/erro/500"); // Erro não detectado, algo com o servidor
        //    app.UseStatusCodePagesWithRedirects("/erro/{0}");
        //    app.UseHsts();
        //}

        app.UseExceptionHandler("/erro/500"); // Erro não detectado, algo com o servidor
        app.UseStatusCodePagesWithRedirects("/erro/{0}");
        app.UseHsts();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Middlewares para autenticação/Autorização
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<ExceptionMiddleware>();

        // Configuração de Health Checks (descomentado se necessário)
        // app.MapHealthChecks("/health");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }

}
