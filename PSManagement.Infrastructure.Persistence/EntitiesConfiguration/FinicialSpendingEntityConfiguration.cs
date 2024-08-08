using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Projects.Entities;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class FinicialSpendingEntityConfiguration :
        IEntityTypeConfiguration<FinincialSpending>

    {
        public void Configure(EntityTypeBuilder<FinincialSpending> builder)
        {
            builder.OwnsOne(e => e.ExternalPurchase, p =>
            {
                p.Property(e => e.Ammount).HasColumnName("ExternalPurchaseAmmount");
                p.Property(e => e.Currency).HasColumnName("ExternalPurchaseCurrency").HasDefaultValue("USD");

            });

            builder.OwnsOne(e => e.LocalPurchase, p =>
            {
                p.Property(e => e.Ammount).HasColumnName("LocalPurchaseAmmount");
                p.Property(e => e.Currency).HasColumnName("LocalPurchaseCurrency").HasDefaultValue("SP");

            });

        }
    }
}
