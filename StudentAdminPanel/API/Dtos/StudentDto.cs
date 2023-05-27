using Core.Entities;

namespace API.Dtos;

public class StudentDto : BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public long Mobile { get; set; }
    public string? ProfileImageUrl { get; set; }

    public GroupDto Group { get; set; }
    public GenderDto Gender { get; set; }
    public AdressDto Address { get; set; }
}