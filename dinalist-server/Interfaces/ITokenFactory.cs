public interface ITokenFactory<T>
{
    IToken<T> Create(User user);
}