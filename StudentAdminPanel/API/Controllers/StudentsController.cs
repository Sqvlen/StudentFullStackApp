using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class StudentsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IReadOnlyList<StudentDto>> GetStudents()
    {
        var students = await _unitOfWork.Repository<Student>().ListAllAsync();

        var studentsToReturn = _mapper.Map<IReadOnlyList<StudentDto>>(students);
        
        return studentsToReturn;
    }
}