using AccountManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.DataAccess.Configurations
{
    public class ContractConfiguration : EntityTypeConfiguration<Contract>
    {
        public override void Map(EntityTypeBuilder<Contract> builder)
        {
            builder.Property(c => c.Description).IsRequired().HasMaxLength(100);
            builder.Property(c => c.StartDate).IsRequired();
        }
    }
}
