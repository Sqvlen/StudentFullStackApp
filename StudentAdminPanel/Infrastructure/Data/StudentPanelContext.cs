﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StudentPanelContext : DbContext
{
    public StudentPanelContext(DbContextOptions<StudentPanelContext> options) : base(options)
    {
        
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Address> Addresses { get; set; }
}