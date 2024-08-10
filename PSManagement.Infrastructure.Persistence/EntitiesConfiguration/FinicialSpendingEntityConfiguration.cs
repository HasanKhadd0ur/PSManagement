using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Projects.Entities;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class FinicialSpendingEntityConfiguration :
        IEntityTypeConfiguration<FinancialSpending>

    {
        public void Configure(EntityTypeBuilder<FinancialSpending> builder)
        {
            builder.OwnsOne(e => e.ExternalPurchase, p =>
            {
                p.Property(e => e.Ammount).HasColumnName("ExternalPurchaseAmmount");
                p.Property(e => e.Currency).HasColumnName("ExternalPurchaseCurrency").HasDefaultValue("USD");

            });

        }
    }
}
