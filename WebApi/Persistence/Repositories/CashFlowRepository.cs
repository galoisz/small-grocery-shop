using Microsoft.EntityFrameworkCore;
using WebApi.Persistence.Daos;
using WebApi.Persistence.Repositories.Interfaces;

namespace WebApi.Persistence.Repositories;


public class CashFlowRepository : ICashFlowRepository
{
    private readonly CashFlowDataContext _context;

    public CashFlowRepository(CashFlowDataContext context)
    {
        _context = context;
    }

    public async Task<List<CashFlowDao>> GetCashFlowAsync(DateTime from, DateTime to)
    {
        return await _context.CashFlows
            .Where(x => x.Date >= from && x.Date <= to)
            .OrderBy(x=> x.Date)
            .ToListAsync();
    }
}