using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
        
            builder.OwnsOne(c => c.Address, address =>
            {
                address.Property(a => a.StreetName).HasColumnName("StreetName");
                address.Property(a => a.City).HasColumnName("City");
                address.Property(a => a.StreetNumber).HasColumnName("StreetNumber");
            }
            );

            builder.HasMany(c => c.ContactInfo);
            
        }
    }
}
