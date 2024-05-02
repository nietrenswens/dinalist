using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;
    public Guid? DiningRoomId { get; set; }
    [ForeignKey("DiningRoomId")]
    public DiningRoom? DiningRoom { get; set; }
}