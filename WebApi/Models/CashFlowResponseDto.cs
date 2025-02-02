namespace WebApi.Models;

public class CashFlowResponseDto
{
    public DateTime Date { get; set; }
    public decimal Income { get; set; }
    public decimal Outcome { get; set; }
    public decimal Revenue => Income - Outcome;

}