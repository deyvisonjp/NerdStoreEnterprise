using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services;

public interface IAutenticacaoService
{
    Task<UserLoginResponse> Login(UserLogin usuarioLogin);
    Task<UserLoginResponse> Registro(UserRegister usuarioRegistro);
}
