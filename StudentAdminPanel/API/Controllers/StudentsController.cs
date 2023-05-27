using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
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
    public async Task<ActionResult<IReadOnlyList<StudentDto>>> GetStudents([FromQuery] StudentParams studentParams)
    {
        var spec = new StudentWithSpecificationParams(studentParams);
        var countSpec = new StudentWithFiltersForCountSpecification(studentParams);
        var totalItems = await _unitOfWork.Repository<Student>().CountAsync(countSpec);
        
        var students = await _unitOfWork.Repository<Student>().ListAsync(spec);

        var data = _mapper
            .Map<IReadOnlyList<Student>, IReadOnlyList<StudentDto>>(students);

        return Ok(new Pagination<StudentDto>(studentParams.PageNumber, studentParams.PageSize, totalItems, data));
    }
}