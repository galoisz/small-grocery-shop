using System.ComponentModel.DataAnnotations;
using WebApi.Helpers;

namespace WebApi.Models;


public class CashFlowRequestDto
{
    [Required]
    public DateTime From { get; set; }

    [Required]
    [DateGreaterOrEqual("From", ErrorMessage = "The 'To' date must be greater or equal to 'From' date.")]
    public DateTime To { get; set; }
}
