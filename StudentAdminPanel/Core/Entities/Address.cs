namespace Core.Entities;

public class Address : BaseEntity
{
    public string? PhysicalAddress { get; set; }
    public string? PostalAddress { get; set; }
    public Guid StudentId { get; set; }
}