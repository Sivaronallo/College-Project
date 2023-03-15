using CollegeProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeProject.Infrastructure.Data.Config;

public class DesignationEntityTypeConfiguration : IEntityTypeConfiguration<Designation>
{
    public void Configure(EntityTypeBuilder<Designation> builder)
    {
        builder.ToTable(nameof(CollegeContext.Designations), schema: NamedConstants.MasterSchemaName,
            b => b.IsTemporal()).HasOne(d => d.User).WithMany().HasForeignKey(d => d.UserId);
        builder.HasMany(d => d.CollegeUsers).WithOne(d => d.Designation).HasForeignKey(d => d.DesignationId);
    }
}
