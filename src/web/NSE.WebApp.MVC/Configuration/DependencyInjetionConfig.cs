using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Configuration;

public static class DependencyInjetionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
    }
}
