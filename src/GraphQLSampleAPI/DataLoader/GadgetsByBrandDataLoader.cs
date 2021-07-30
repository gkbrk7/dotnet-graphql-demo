using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLSampleAPI.Contexts;
using GraphQLSampleAPI.Models;
using HotChocolate.Fetching;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSampleAPI.DataLoader
{
    public class GadgetsByBrandDataLoader : BatchDataLoader<string, IEnumerable<Gadget>>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        public GadgetsByBrandDataLoader(IDbContextFactory<ApplicationDbContext> dbContextFactory, BatchScheduler batchScheduler) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory;
        }
        protected override async Task<IReadOnlyDictionary<string, IEnumerable<Gadget>>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            await using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var gadgets = await dbContext.Gadgets.Where(g => keys.Select(_ => _.ToLower()).ToList().Contains(g.brandName.ToLower())).ToListAsync();

                return gadgets.GroupBy(_ => _.brandName.ToLower())
                    .Select(_ => new
                    {
                        key = _.Key,
                        Gadgets = _.AsEnumerable()
                    }).ToDictionary(k => k.key, v => v.Gadgets);
            }
        }
    }
}