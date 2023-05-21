using Core.Entities;

namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository StudentRepository { get; }
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<bool> Complete();
    bool HasChanges();
    void Dispose();
}