using AutoMapper;
using WebApi.Models;
using WebApi.Persistence.Daos;

namespace WebApi.Helpers;

public class CashFlowProfile : Profile
{
    public CashFlowProfile()
    {
        CreateMap<CashFlowDao, CashFlowResponseDto>();
    }
}