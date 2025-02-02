using WebApi.Persistence.Daos;

namespace WebApi.Persistence.Repositories.Interfaces;

public interface ICashFlowRepository
{
    Task<List<CashFlowDao>> GetCashFlowAsync(DateTime from, DateTime to);
}
