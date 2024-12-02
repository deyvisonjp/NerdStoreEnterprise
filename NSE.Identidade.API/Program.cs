using NSE.Identidade.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Secrets
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Configuração de Serviços
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configuração do Pipeline de Solicitação
Configure(app, app.Environment);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllersWithViews();
    services.AddApiConfiguration();
    services.AddIdentityConfiguration(configuration);
    services.AddEndpointsApiExplorer();
    services.AddSwaggerConfiguration(configuration);
}

void Configure(WebApplication app, IWebHostEnvironment environment)
{
    app.UseApiConfiguration(environment);
}
