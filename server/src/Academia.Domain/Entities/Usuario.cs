using Academia.Domain.Entities;

public class Usuario : BaseEntity{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public long AcademiaId { get; set; }
    public AcademiaEntity Academia { get; set; }
}