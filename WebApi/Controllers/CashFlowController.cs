using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashFlowController : ControllerBase
    {
        private readonly ICashFlowService _cashFlowService;

        public CashFlowController(ICashFlowService cashFlowService)
        {
            _cashFlowService = cashFlowService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CashFlowResponseDto>>> GetData([FromQuery] CashFlowRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<CashFlowResponseDto> result = await _cashFlowService.GetCashFlow(request.From, request.To);
            return Ok(result);
        }
    }
}
