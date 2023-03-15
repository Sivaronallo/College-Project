using Microsoft.EntityFrameworkCore;
using CollegeProject.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeProject.Infrastructure.Data.Config;

public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(nameof(CollegeContext.Departments), schema: NamedConstants.MasterSchemaName,
                b => b.IsTemporal()).HasOne(d => d.User).WithMany().HasForeignKey(d => d.UserId);
        builder.HasMany(d => d.CollegeUsers).WithOne(d => d.Department).HasForeignKey(d => d.DepartmentId);
    }
}