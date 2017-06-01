using AccountManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.DataAccess.Configurations
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public override void Map(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c => c.Identifier).HasMaxLength(10);
            builder.HasIndex(c => c.Identifier).IsUnique();
        }
    }
}
