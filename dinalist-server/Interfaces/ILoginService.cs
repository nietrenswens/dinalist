public interface ILoginService
{
    Task<LoginResponse?> LoginAsync(LoginRequest request);
    Task<LogoutResponse> LogoutAsync(LogoutRequest request);
    bool IsTokenValid(TokenRequest request);
}