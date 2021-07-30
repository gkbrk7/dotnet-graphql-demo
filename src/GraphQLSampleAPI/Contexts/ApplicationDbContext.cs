using GraphQLSampleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSampleAPI.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Gadget> Gadgets { get; set; }
    }
}