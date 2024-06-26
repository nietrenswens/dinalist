using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Token : IToken<string>
{
    [Key]
    public string Value { get; set; } = null!;
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    public Guid UserId { get; set; }
    public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(4);
    public bool IsRevoked { get; set; } = false;

    public override string ToString()
    {
        return Value;
    }
}