using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropellerheadCI.Business.Models;

namespace PropellerheadCI.Data.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Surname)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : 1 => Customer : Address
            builder.HasOne(a => a.Address)
                .WithOne(c => c.Customer);

            // 1 : N => Customer : Notes
            builder.HasMany(n => n.Notes)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);

            builder.ToTable("Customers");
        }
    }
}