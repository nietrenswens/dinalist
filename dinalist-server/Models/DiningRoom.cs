using System.ComponentModel.DataAnnotations;

public class DiningRoom
{
    [Key]
    public Guid Id { get; set; }
    public List<User> Users { get; set; } = new();
}