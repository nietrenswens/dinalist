public class StringTokenFactory : ITokenFactory<string>
{
    public IToken<string> Create(User user)
    {
        Guid guid = Guid.NewGuid();
        string token = $"{user.Id}.{guid}.{DateTime.UtcNow.ToString()}";
        return new Token() { Value = token, User = user, UserId = user.Id, ExpirationDate = DateTime.UtcNow.AddDays(4), IsRevoked = false };
    }
}