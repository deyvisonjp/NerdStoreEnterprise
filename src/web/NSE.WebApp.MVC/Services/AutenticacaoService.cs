using NSE.WebApp.MVC.Models;
using System.Text;
using System.Text.Json;

namespace NSE.WebApp.MVC.Services;

public class AutenticacaoService : IAutenticacaoService
{
    private readonly HttpClient _httpClient;

    public AutenticacaoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<UserLoginResponse> Login(UserLogin usuarioLogin)
    {
        var loginContent = new StringContent(
            JsonSerializer.Serialize(usuarioLogin),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(
            "https://localhost:44343/api/identidade/autenticar",
            loginContent);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        var retornoPosJson = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserLoginResponse>(await response.Content.ReadAsStringAsync(), options);
    }

    public async Task<UserLoginResponse> Registro(UserRegister usuarioRegistro)
    {
        var registroContent = new StringContent(
            JsonSerializer.Serialize(usuarioRegistro),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(
            "https://localhost:44343/api/identidade/nova-conta",
            registroContent);

        return JsonSerializer.Deserialize<UserLoginResponse>(await response.Content.ReadAsStringAsync());

    }
}
