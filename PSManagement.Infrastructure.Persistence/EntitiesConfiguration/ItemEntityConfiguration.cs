using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Steps.Entities;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {

            builder.OwnsOne(c => c.Price, 
                p => {
                    p.Property(e => e.Ammount).HasColumnName("Ammount");
                    p.Property(e => e.Currency).HasColumnName("Currency");
                }
            );
        }
    }
}
