using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repostories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentPanelContext _context;

    public StudentRepository(StudentPanelContext context)
    {
        _context = context;
    }
    
    public async Task<List<Student>> GetStudents()
    {
        return await _context.Students.Include(p => p.Address)
            .Include(p => p.Gender).ToListAsync();
    }
}