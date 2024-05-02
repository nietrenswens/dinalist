public interface IToken<T>
{
    T Value { get; set; }
    User User { get; set; }

}