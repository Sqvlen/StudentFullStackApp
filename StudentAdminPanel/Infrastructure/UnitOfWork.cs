﻿using System.Collections;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repostories;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly StudentPanelContext _dataBaseContext;
    private Hashtable _repositories;
    
    public UnitOfWork(StudentPanelContext context)
    {
        _dataBaseContext = context;
    }

    public async Task<bool> Complete()
    {
        return await _dataBaseContext.SaveChangesAsync() > 0;
    }

    public bool HasChanges()
    {
        return _dataBaseContext.ChangeTracker.HasChanges();
    }

    public void Dispose()
    {
        _dataBaseContext.Dispose();
    }

    public IStudentRepository StudentRepository => new StudentRepository(_dataBaseContext);

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        if(_repositories == null) 
            _repositories = new Hashtable();
    
        var type = typeof(TEntity).Name;
    
        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dataBaseContext);
    
            _repositories.Add(type, repositoryInstance);
        }
    
        return (IGenericRepository<TEntity>) _repositories[type];
    }
}