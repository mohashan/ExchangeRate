using ExchangeRate.Domain.ExchangeRates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.Repositories;
internal sealed class ExchangeRateRepository : Repository<Domain.ExchangeRates.ExchangeRate>, IExchangeRateRepository
{
    private readonly ApplicationDbContext dbContext;

    public ExchangeRateRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Domain.ExchangeRates.ExchangeRate?> GetByCodeAsync(CurrencyPair code, CancellationToken cancellationToken = default)
    {
        var exRate = await context.Set<Domain.ExchangeRates.ExchangeRate>().OrderByDescending(c=>c.LastUpdateOnUtc).FirstOrDefaultAsync(c => c.Pair == code);
        return exRate;
    }
}
