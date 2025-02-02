using AutoMapper;
using WebApi.Models;
using WebApi.Persistence.Repositories.Interfaces;
using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class CashFlowService : ICashFlowService
{
    private readonly ICashFlowRepository _cashFlowRepository;
    private readonly IMapper _mapper;

    public CashFlowService(ICashFlowRepository cashFlowRepository, IMapper mapper)
    {
        _cashFlowRepository = cashFlowRepository;
        _mapper = mapper;
    }

    public async Task<List<CashFlowResponseDto>> GetCashFlow(DateTime from, DateTime to)
    {
        var result = await _cashFlowRepository.GetCashFlowAsync(from, to);
        return _mapper.Map<List<CashFlowResponseDto>>(result);
    }
}
