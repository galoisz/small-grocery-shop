using Microsoft.EntityFrameworkCore;
using WebApi.Persistence.Daos;

namespace WebApi.Persistence;


public class CashFlowDataContext : DbContext
{
    public DbSet<CashFlowDao> CashFlows { get; set; }

    public CashFlowDataContext(DbContextOptions<CashFlowDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
