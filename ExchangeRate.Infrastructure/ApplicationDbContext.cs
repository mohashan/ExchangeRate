using ExchangeRate.Application.Exceptions;
using ExchangeRate.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.Domain.ExchangeRates;

namespace ExchangeRate.Infrastructure;
public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly IPublisher publisher;
    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        this.publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Entity<ExchangeRate.Domain.ExchangeRates.ExchangeRate>().ToTable("ExchangeRate", b => b.IsTemporal());
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occured", ex);
        }

    }


}

