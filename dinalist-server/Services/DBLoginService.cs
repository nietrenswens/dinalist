
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

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        if (request == null) return null;
        User? potentialUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (potentialUser == null) return null;
        if (potentialUser.Password != request.Password) return null;
        return new LoginResponse(tokenFactory.Create(potentialUser), potentialUser);
    }

    public Task<LogoutResponse> LogoutAsync(LogoutRequest request)
    {
        throw new NotImplementedException();
    }

}