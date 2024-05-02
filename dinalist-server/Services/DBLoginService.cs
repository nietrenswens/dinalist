
using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;

public class DBLoginService : ILoginService
{

    private readonly AppDbContext _context;
    private readonly ITokenFactory<string> tokenFactory;

    public DBLoginService(AppDbContext context)
    {
        _context = context;
        tokenFactory = new StringTokenFactory();
    }

    public bool IsTokenValid(TokenRequest request)
    {
        var token = _context.Tokens.FirstOrDefault(t => t.Value == request.Token);
        if (token == null) return false;
        if (token.ExpirationDate < DateTime.UtcNow) return false;
        if (token.IsRevoked) return false;
        return true;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        if (request == null) return null;
        User? potentialUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (potentialUser == null) return null;
        if (potentialUser.Password != request.Password) return null;
        var generatedToken = (Token)tokenFactory.Create(potentialUser);
        await _context.Tokens.AddAsync(generatedToken);
        _context.SaveChanges();
        return new LoginResponse(generatedToken, potentialUser);
    }

    public Task<LogoutResponse> LogoutAsync(LogoutRequest request)
    {
        throw new NotImplementedException();
    }

}