using Core.Entities;

namespace API.Dtos;

public class StudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public long Mobile { get; set; }
    public string? ProfileImageUrl { get; set; }
    
    public Gender Gender { get; set; }
    public Address Address { get; set; }
}