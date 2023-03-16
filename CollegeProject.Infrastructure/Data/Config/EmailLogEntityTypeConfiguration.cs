using CollegeProject.Core.Entities.Message;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeProject.Infrastructure.Data.Config;

public class EmailLogEntityTypeConfiguration : IEntityTypeConfiguration<EmailLog>
{
    public void Configure(EntityTypeBuilder<EmailLog> builder)
    {
        builder.ToTable(nameof(CollegeContext.EmailLogs), schema: NamedConstants.MessageSchemaName);
    }
}