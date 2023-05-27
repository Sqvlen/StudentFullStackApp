using Core.Entities;

namespace Core.Specification;

public class StudentWithSpecificationParams : BaseSpecification<Student>
{
    public StudentWithSpecificationParams(StudentParams studentParams)
    {
        AddInclude(x => x.Address);
        AddInclude(x => x.Gender);

        ApplyPaging(studentParams.PageSize * (studentParams.PageNumber -1), studentParams.PageSize);
    }
    
    public StudentWithSpecificationParams()
    {
        AddInclude(x => x.Address);
        AddInclude(x => x.Gender);
    }
}