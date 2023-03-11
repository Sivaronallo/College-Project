using Microsoft.EntityFrameworkCore;
using CollegeProject.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeProject.Infrastructure.Data.Config;

public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(nameof(CollegeContext.Departments), schema: NamedConstants.MasterSchemaName,
                b => b.IsTemporal())
            .HasOne(d => d.User)
            .WithMany(c => c.Departments)
            .HasForeignKey(d => d.UserId);
    }
}