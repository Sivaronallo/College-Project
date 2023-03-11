using CollegeProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeProject.Infrastructure.Data.Config;

public class CollegeUserEntityTypeConfiguration : IEntityTypeConfiguration<CollegeUser>
{
    public void Configure(EntityTypeBuilder<CollegeUser> builder)
    {
        builder.ToTable(b => b.IsTemporal()).HasOne(u => u.Designation).WithMany(d => d.CollegeUser)
            .HasForeignKey(u => u.DesignationId);
        builder.HasOne(u => u.Department).WithMany(d => d.CollegeUser).HasForeignKey(u => u.DepartmentId);
    }
}