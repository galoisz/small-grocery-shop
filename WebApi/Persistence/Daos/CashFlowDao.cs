using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Persistence.Daos;


[Table("CashFlow")]
public class CashFlowDao
{
    [Key]
    public int Id { get; set; } 
    public DateTime Date { get; set; }
    public decimal Income { get; set; }
    public decimal Outcome { get; set; }
}
