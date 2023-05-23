using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<Gender, GenderDto>();
        CreateMap<Address, AdressDto>();
    }
}