using Core.Entities;

namespace Core.Interfaces;

public interface IStudentRepository
{
    Task<List<Student>> GetStudents();
}