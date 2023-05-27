using Core.Entities;

namespace Core.Specification;

public class StudentWithFiltersForCountSpecification : BaseSpecification<Student>
{
    public StudentWithFiltersForCountSpecification(StudentParams studentParams)
    : base(x => (string.IsNullOrEmpty(studentParams.Search) || x.FirstName.ToLower().Contains(studentParams.Search))
    && (string.IsNullOrEmpty(studentParams.Search) || x.LastName.ToLower().Contains(studentParams.Search)))
    {
        
    }

    public StudentWithFiltersForCountSpecification()
    {
        
    }
}