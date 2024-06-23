using ExchangeRate.Domain.ExchangeRates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.Configurations;
internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Domain.ExchangeRates.ExchangeRate>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.ExchangeRates.ExchangeRate> builder)
    {
        builder.ToTable("ExchangeRate");

        builder.HasKey(t => t.Id);

        //builder.OwnsOne(x => x.Pair, p =>
        //{
        //    p.Property(c => c.Code).HasMaxLength(6);
        //});

        builder.Property(c => c.Pair).IsRequired().HasMaxLength(6);

        builder.Property(c=>c.Pair)
            .IsRequired()
            .HasConversion(c=>c.Code,value=>CurrencyPair.FromCode(value));

        builder.Property(c => c.Rate).IsRequired();

        builder.Property(x => x.LastUpdateSource)
            .HasMaxLength(100)
            .HasConversion(c => c.value, value => new Source(value));
    }
}