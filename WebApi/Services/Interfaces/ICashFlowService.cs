using WebApi.Models;

namespace WebApi.Services.Interfaces;

public interface ICashFlowService
{
    Task<List<CashFlowResponseDto>> GetCashFlow(DateTime from, DateTime to);
}
