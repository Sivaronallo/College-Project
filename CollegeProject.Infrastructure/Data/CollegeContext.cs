using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CollegeProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CollegeProject.Infrastructure.Data;

public class CollegeContext : IdentityDbContext<CollegeUser>
{
    public CollegeContext(DbContextOptions<CollegeContext> options) : base(options)
    {
    }

    public DbSet<Designation> Designations { get; set; }
    public DbSet<Department> Departments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}


